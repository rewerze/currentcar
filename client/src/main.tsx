import { createRoot } from "react-dom/client";
import App from "./App.tsx";
import Nav from "./components/Nav.tsx";
import Footer from "./components/Footer.tsx";
import { StrictMode } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Reg from "./components/Reg.tsx";
import Login from "./components/Login.tsx";
import { UserProvider } from "./contexts/UserContext.tsx";
import Logout from "./components/Logout.tsx";
import Profil from "./components/Profile.tsx";
import Password from "./components/Password.tsx";
import AllCar from "./components/AllCar.tsx";
import CarData from "./components/CarData.tsx";
import CarUpload from "./components/CarUpload.tsx";
import Contact from "./components/Contact.tsx";
import AboutUs from "./components/AboutUs.tsx";
import CarRent from "./components/CarRent.tsx";
import FAQ from "./components/FAQ.tsx";
import Requirements from "./components/Requirements.tsx";
import EditProfile from "./components/EditProfile.tsx";
import { LanguageProvider } from "./contexts/LanguageContext.tsx";
import NotFound from "./components/404.tsx";
import { Toaster } from "@/components/ui/sonner";
import ProfilePicture from "./components/ProfilePicture.tsx";
import { NotificationProvider } from "./contexts/NotificationContext.tsx";
import Notification from "./components/Notification.tsx";
import EditCar from "./components/EditCar.tsx";
import Success from "./components/Status.tsx";
import Invoice from "./components/Invoice.tsx";

const ToasterWrapper = () => {
  return (
    <div
      style={{
        position: "fixed",
        bottom: "4rem",
        right: "1rem",
        zIndex: 9999,
        pointerEvents: "none",
      }}
    >
      <Toaster
        theme="light"
        className="bg-white pointer-events-auto"
        toastOptions={{
          className: "bg-white border border-gray-200 shadow-md",
          style: {
            background: "white",
            color: "black",
          },
        }}
      />
    </div>
  );
};

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <LanguageProvider defaultNamespaces={["common"]}>
      <UserProvider>
        <NotificationProvider>
          <BrowserRouter>
            <Nav />
            <Routes>
              <Route path="/" element={<App />} /> {/* FŐOLDAL */}
              <Route path="/register" element={<Reg />} /> {/*  REGISZTRÁCIÓ */}
              <Route path="/login" element={<Login />} /> {/*  BEJELENTKEZÉS */}
              <Route path="/logout" element={<Logout />} />{" "}
              {/*  KIJELENTKEZÉS */}
              <Route path="/profil" element={<Profil />} />{" "}
              {/*  FELHASZNÁLÓ PROFILJA */}
              <Route
                path="/profil/jelszo-modositas"
                element={<Password />}
              />{" "}
              {/*  JELSZÓ MÓDOSÍTÁS */}
              <Route path="/osszesauto" element={<AllCar />} />{" "}
              {/*  ÖSSZES AUTÓ AMIT KIADUNK */}
              <Route path="/adatlap/edit/:id" element={<EditCar />} />{" "}
              <Route path="/adatlap/:id" element={<CarData />} />{" "}
              <Route path="/status/:id" element={<Success />} />{" "}
              {/*  AUTÓK ADATLAPJAI */}
              <Route path="/feladas" element={<CarUpload />} />{" "}
              {/*  AUTÓ FELTÖLTÉS */}
              <Route path="/kapcsolat" element={<Contact />} />{" "}
              {/*  KAPCSOLAT */}
              <Route path="/rolunk" element={<AboutUs />} /> {/*  RÓLUNK */}
              <Route path="/berles" element={<CarRent />} />{" "}
              {/*  AUTÓ BÉRLÉS */}
              <Route path="/gyik" element={<FAQ />} /> {/*  GYAKORI KÉRDÉSEK */}
              <Route path="/kovetelmenyek" element={<Requirements />} />{" "}
              {/*  KÖVETELMENYEK */}
              <Route path="/profil/modositas" element={<EditProfile />} />{" "}
              {/*  FELAHSZNÁLÓI PROFIL MÓDOSÍTÁS */}
              <Route path="/profil/ertesitesek" element={<Notification />} />{" "}
              <Route path="/profil/profilkep" element={<ProfilePicture />} />{" "} {/*  PROFILKÉP MÓDOSÍTÁS */}
              <Route path="/invoice/:id" element={<Invoice />} />{" "}
              <Route path="*" element={<NotFound />} />
            </Routes>
            <Footer />
            <ToasterWrapper />
          </BrowserRouter>
        </NotificationProvider>
      </UserProvider>
    </LanguageProvider>
  </StrictMode>
);
