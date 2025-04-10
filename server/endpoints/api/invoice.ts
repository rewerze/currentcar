import { Request, Response } from "express";
import { AuthenticatedRequest } from "../../interfaces/User";
import db from "../../db/connection";

export const getInvoice = async (
    req: Request,
    res: Response
): Promise<void> => {
    try {
        const { orderId } = req.params;
        const userId = (req as AuthenticatedRequest).user.user_id;

        const order = await db.query(
            `SELECT o.*, c.car_brand, c.car_model, c.car_regnumber, 
                u.user_name, u.user_email, u.u_phone_number,
                l.location,
                COALESCE(po.amount, i.payment_amount) as total_amount,
                i.tax_amount,
                ins.insurance_provider, ins.coverage_details, ins.insurance_fee
         FROM orders o
         JOIN car c ON o.car_id = c.car_id
         JOIN user u ON o.user_id = u.user_id
         JOIN location l ON o.location_id = l.location_id
         LEFT JOIN payment_orders po ON o.car_id = po.car_id AND o.user_id = po.user_id
         LEFT JOIN invoice i ON o.orders_id = i.orders_id
         LEFT JOIN insurance ins ON c.insurance_id = ins.insurance_id
         WHERE o.orders_id = ? AND (o.user_id = ? OR ? IN (
           SELECT user_id FROM car_user WHERE car_id = o.car_id
         ))`,
            [orderId, userId, userId]
        );

        if (!order || !Array.isArray(order) || order.length === 0) {
            res.status(404).json({ error: "Invoice not found or access denied" });
            return;
        }

        const invoiceData = (order[0] as any);

        const totalAmount = Math.abs(Number(invoiceData.total_amount) || 0);
        const taxAmount = Math.abs(Number(invoiceData.tax_amount) || 0);
        const insuranceFee = Math.abs(Number(invoiceData.insurance_fee) || 0);

        const baseRentalAmount = totalAmount - taxAmount - insuranceFee;

        const invoiceNumber = `INV-${orderId}-${Date.now().toString().substr(-6)}`;

        const startDate = new Date(invoiceData.start_date);
        const endDate = new Date(invoiceData.end_date);
        const days = Math.max(1, Math.ceil(Math.abs(endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24)));

        const displayDates = [startDate, endDate].sort((a, b) => a.getTime() - b.getTime());
        const displayStartDate = displayDates[0];
        const displayEndDate = displayDates[1];

        const htmlInvoice = `
        <!DOCTYPE html>
        <html>
        <head>
          <meta charset="utf-8">
          <title>Invoice #${invoiceNumber}</title>
          <style>
            body {
              font-family: Arial, sans-serif;
              margin: 0;
              padding: 20px;
            }
            .invoice-container {
              max-width: 800px;
              margin: 0 auto;
              border: 1px solid #eee;
              padding: 20px;
            }
            .invoice-header {
              display: flex;
              justify-content: space-between;
              margin-bottom: 20px;
              padding-bottom: 20px;
              border-bottom: 1px solid #eee;
            }
            .invoice-body {
              margin-bottom: 30px;
            }
            .invoice-footer {
              text-align: right;
              font-weight: bold;
              margin-top: 30px;
              padding-top: 10px;
              border-top: 1px solid #eee;
            }
            table {
              width: 100%;
              border-collapse: collapse;
            }
            table th, table td {
              padding: 10px;
              text-align: left;
              border-bottom: 1px solid #eee;
            }
            .total-row td {
              font-weight: bold;
            }
            .print-button {
              background: #4CAF50;
              color: white;
              border: none;
              padding: 10px 20px;
              cursor: pointer;
              font-size: 16px;
              margin-top: 20px;
            }
            @media print {
              .print-button {
                display: none;
              }
            }
          </style>
        </head>
        <body>
        <div class="invoice-container">
          <div class="invoice-header">
            <!-- header remains the same -->
          </div>
          
          <div class="invoice-body">
            <div style="display: flex; justify-content: space-between; margin-bottom: 20px;">
              <div>
                <h3>Bill To:</h3>
                <p>Name: ${invoiceData.user_name}</p>
                <p>Email: ${invoiceData.user_email}</p>
                <p>Phone: ${invoiceData.u_phone_number || 'N/A'}</p>
              </div>
              <div>
                <h3>Rental Details:</h3>
                <p>Start Date: ${displayStartDate.toLocaleDateString()}</p>
                <p>End Date: ${displayEndDate.toLocaleDateString()}</p>
                <p>Duration: ${days} day(s)</p>
                <p>Pickup Location: ${invoiceData.location}</p>
              </div>
            </div>
            
            <table>
              <thead>
                <tr>
                  <th>Description</th>
                  <th>Details</th>
                  <th>Amount</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>Car Rental</td>
                  <td>${invoiceData.car_brand} ${invoiceData.car_model} (${invoiceData.car_regnumber})</td>
                  <td>${baseRentalAmount.toFixed(2)} HUF</td>
                </tr>
                ${invoiceData.insurance_provider ? `
                <tr>
                  <td>Insurance</td>
                  <td>${invoiceData.insurance_provider} - ${invoiceData.coverage_details}</td>
                  <td>${insuranceFee.toFixed(2)} HUF</td>
                </tr>` : ''}
                ${taxAmount > 0 ? `
                <tr>
                  <td>Tax</td>
                  <td></td>
                  <td>${taxAmount.toFixed(2)} HUF</td>
                </tr>` : ''}
                <tr class="total-row">
                  <td colspan="2">Total</td>
                  <td>${totalAmount.toFixed(2)} HUF</td>
                </tr>
              </tbody>
            </table>
          </div>
            
            <button class="print-button" onclick="window.print()">Print Invoice</button>
            <button class="print-button" onclick="generatePDF()">Download PDF</button>
          </div>
          
          <script>
            // Simple function to trigger PDF download using browser's print functionality
            function generatePDF() {
              // Add a stylesheet for printing
              const style = document.createElement('style');
              style.textContent = '@page { size: auto; margin: 0mm; }';
              document.head.appendChild(style);
              
              // Hide the buttons
              const buttons = document.querySelectorAll('.print-button');
              buttons.forEach(btn => btn.style.display = 'none');
              
              // Print with a different name
              const originalTitle = document.title;
              document.title = 'Invoice_${invoiceNumber}.pdf';
              
              window.print();
              
              // Restore elements
              buttons.forEach(btn => btn.style.display = 'block');
              document.title = originalTitle;
              document.head.removeChild(style);
            }
          </script>
        </body>
        </html>
      `;

        res.setHeader('Content-Type', 'text/html');
        res.send(htmlInvoice);

    } catch (error) {
        console.error("Error generating invoice:", error);
        res.status(500).json({ error: "Failed to generate invoice" });
    }
};