import { useRef, useState } from "react";
import axios from "axios";
import upload from "../assets/img/upload.svg";
import '../assets/css/profilepicture.css'

function ProfilePicture() {
    const [file, setFile] = useState<File | null>(null);
    const [previewUrl, setPreviewUrl] = useState<string | null>(null);
    const [isDragging, setIsDragging] = useState(false);
    const [isUploading, setIsUploading] = useState(false);
    const fileInputRef = useRef<HTMLInputElement>(null);

    // Handle file selection
    const handleFileSelect = (selectedFile: File) => {
        // Validate file type
        const allowedTypes = ['image/jpeg', 'image/png', 'image/webp'];
        if (!allowedTypes.includes(selectedFile.type)) {
            alert('Kérjük, érvényes képet töltsön fel (JPG, PNG, WEBP)');
            return;
        }

        // Validate file size (5MB max)
        const maxSize = 5 * 1024 * 1024; // 5MB
        if (selectedFile.size > maxSize) {
            alert('A fájl túl nagy. A maximális méret 5MB');
            return;
        }

        setFile(selectedFile);

        // Create file preview
        const reader = new FileReader();
        reader.onloadend = () => {
            setPreviewUrl(reader.result as string);
        };
        reader.readAsDataURL(selectedFile);

        // Reset the input value to allow re-uploading the same file
        if (fileInputRef.current) {
            fileInputRef.current.value = '';
        }
    };

    // File input change handler
    const handleFileInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const selectedFile = e.target.files?.[0];
        if (selectedFile) {
            handleFileSelect(selectedFile);
        }
    };

    // Drag and drop handlers
    const handleDragOver = (e: React.DragEvent<HTMLDivElement>) => {
        e.preventDefault();
        e.stopPropagation();
        setIsDragging(true);
    };

    const handleDragLeave = (e: React.DragEvent<HTMLDivElement>) => {
        e.preventDefault();
        e.stopPropagation();
        setIsDragging(false);
    };

    const handleDrop = (e: React.DragEvent<HTMLDivElement>) => {
        e.preventDefault();
        e.stopPropagation();
        setIsDragging(false);

        const selectedFile = e.dataTransfer.files[0];
        if (selectedFile) {
            handleFileSelect(selectedFile);
        }
    };

    // Trigger file input click
    const handleClickUpload = () => {
        fileInputRef.current?.click();
    };

    // Upload file to server
    const handleUploadToServer = async () => {
        if (!file) {
            alert('Kérjük, először válasszon ki egy képet');
            return;
        }

        setIsUploading(true);

        const formData = new FormData();
        formData.append('profile_picture', file);

        try {
            const response = await axios.post('/api/upload-profile-picture', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });

            alert('Profilkép sikeresen feltöltve!');
            // Optionally, you can do something with the response, 
            // like updating the UI or storing the new profile picture path
        } catch (error) {
            console.error('Hiba a feltöltés során:', error);
            alert('Hiba történt a feltöltés során');
        } finally {
            setIsUploading(false);
        }
    };

    // Remove selected file
    const handleRemoveFile = () => {
        setFile(null);
        setPreviewUrl(null);

        // Reset the input value
        if (fileInputRef.current) {
            fileInputRef.current.value = '';
        }
    };

    return (
        <main className="nav-gap">
            <input
                type="file"
                ref={fileInputRef}
                onChange={handleFileInputChange}
                accept=".jpg,.jpeg,.png,.webp"
                style={{ display: 'none' }}
            />

            <div
                className={`drop-zone d-flex justify-content-center ${isDragging ? 'dragging' : ''}`}
                onClick={handleClickUpload}
                onDragOver={handleDragOver}
                onDragLeave={handleDragLeave}
                onDrop={handleDrop}
            >
                {previewUrl ? (
                    <div className="preview-container">
                        <img
                            src={previewUrl}
                            alt="Előnézet"
                            className="preview-image"
                        />
                    </div>
                ) : (
                    <>
                        <img src={upload} alt="Feltöltés" />
                        <p>Húzz ide egy fájlt vagy válassz ki egyet!</p>
                    </>
                )}
            </div>

            {file && (
                <div className="file-details">
                    <p>Kiválasztva: {file.name}</p>
                    <button onClick={handleRemoveFile}>
                        Eltávolítás
                    </button>
                    <button
                        onClick={handleUploadToServer}
                        disabled={isUploading}
                        className="upload-button"
                    >
                        {isUploading ? 'Feltöltés folyamatban...' : 'Feltöltés'}
                    </button>
                </div>
            )}
        </main>
    );
}

export default ProfilePicture;