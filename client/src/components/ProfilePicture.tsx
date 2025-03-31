import { useEffect, useRef, useState } from "react";
import axios from "axios";
import upload from "../assets/img/upload.svg";
import "../assets/css/profilepicture.css";
import { toast } from "sonner";
import { buildApiUrl } from "@/lib/utils";
import { useUser } from "@/contexts/UserContext";
import { useNavigate } from "react-router-dom";

function ProfilePicture() {
  const [file, setFile] = useState<File | null>(null);
  const [previewUrl, setPreviewUrl] = useState<string | null>(null);
  const [isDragging, setIsDragging] = useState(false);
  const [isUploading, setIsUploading] = useState(false);
  const fileInputRef = useRef<HTMLInputElement>(null);
  const { user, loading } = useUser();
  const navigate = useNavigate();

  useEffect(() => {
    if (!loading && !user) {
      navigate('/register');
    }
  }, [user, loading])

  const handleFileSelect = (selectedFile: File) => {
    const allowedTypes = ["image/jpeg", "image/png", "image/webp"];
    if (!allowedTypes.includes(selectedFile.type)) {
      toast.error("Kérjük, érvényes képet töltsön fel (JPG, PNG, WEBP)");
      return;
    }

    const maxSize = 5 * 1024 * 1024;
    if (selectedFile.size > maxSize) {
      toast.error("A fájl túl nagy. A maximális méret 5MB");
      return;
    }

    setFile(selectedFile);

    const reader = new FileReader();
    reader.onloadend = () => {
      setPreviewUrl(reader.result as string);
    };
    reader.readAsDataURL(selectedFile);

    if (fileInputRef.current) {
      fileInputRef.current.value = "";
    }
  };

  const handleFileInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const selectedFile = e.target.files?.[0];
    if (selectedFile) {
      handleFileSelect(selectedFile);
    }
  };

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

  const handleClickUpload = () => {
    fileInputRef.current?.click();
  };

  const handleUploadToServer = async () => {
    if (!file) {
      toast.error("Kérjük, először válasszon ki egy képet");
      return;
    }

    setIsUploading(true);

    const formData = new FormData();
    formData.append("profile_picture", file);

    try {
      await axios.post(
        buildApiUrl("/upload-profile-picture"),
        formData,
        {
          withCredentials: true,
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );

      toast.success("Profilkép sikeresen feltöltve!");
    } catch (error) {
      console.error("Hiba a feltöltés során:", error);
      toast.error("Hiba történt a feltöltés során");
    } finally {
      setIsUploading(false);
    }
  };

  const handleRemoveFile = () => {
    setFile(null);
    setPreviewUrl(null);

    if (fileInputRef.current) {
      fileInputRef.current.value = "";
    }
  };

  return (
    <main className="nav-gap">
      {file &&
        <p className="text-center"><b>Kiválasztva:</b> {file.name}</p>
      }
      <input
        type="file"
        ref={fileInputRef}
        onChange={handleFileInputChange}
        accept=".jpg,.jpeg,.png,.webp"
        style={{ display: "none" }}
      />

      <div
        className={`drop-zone d-flex justify-content-center ${isDragging ? "dragging" : ""
          }`}
        onClick={handleClickUpload}
        onDragOver={handleDragOver}
        onDragLeave={handleDragLeave}
        onDrop={handleDrop}
      >
        {previewUrl ? (
          <div className="preview-container">
            <img src={previewUrl} alt="Előnézet" className="preview-image" />
          </div>
        ) : (
          <>
            <img src={upload} alt="Feltöltés" />
            <p className="text-center">Húzz ide egy fájlt vagy válassz ki egyet!</p>
          </>
        )}
      </div>

      {file && (
        <div className="file-details mx-auto">
          <button onClick={handleRemoveFile}>Eltávolítás</button>
          <button
            onClick={handleUploadToServer}
            disabled={isUploading}
            className="upload-button"
          >
            {isUploading ? "Feltöltés folyamatban..." : "Feltöltés"}
          </button>
        </div>
      )}
    </main>
  );
}

export default ProfilePicture;
