import { buildApiUrl } from "@/lib/utils";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

function Invoice() {
    const { id } = useParams<{ id: string }>();
    const [invoiceHtml, setInvoiceHtml] = useState("");
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        const fetchInvoiceData = async () => {
            try {
                const response = await fetch(buildApiUrl(`/invoice/${id}`), {
                    credentials: "include",
                });

                if (!response.ok) {
                    throw new Error(`Failed to fetch invoice data: ${response.status}`);
                }

                const htmlContent = await response.text();
                setInvoiceHtml(htmlContent);
                setLoading(false);
            } catch (error) {
                setError(error as string);
                setLoading(false);
            }
        };

        fetchInvoiceData();
    }, [id]);

    return (
        <main className="nav-gap">
            {loading ? (
                <div className="text-center p-5">Loading invoice...</div>
            ) : error ? (
                <div className="text-center p-5 text-danger">{error.toString()}</div>
            ) : (
                <div className="invoice-container">
                    <iframe
                        srcDoc={invoiceHtml}
                        style={{
                            width: "100%",
                            height: "800px",
                            border: "none",
                            overflow: "auto"
                        }}
                        title="Invoice"
                    />
                </div>
            )}
        </main>
    );
}

export default Invoice;
