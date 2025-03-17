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
import Security from "./components/Security.tsx";
import Requirements from "./components/Requirements.tsx";
import EditProfile from "./components/EditProfile.tsx";
import { LanguageProvider } from "./contexts/LanguageContext.tsx";
import NotFound from "./components/404.tsx";
import { Toaster } from "@/components/ui/sonner"

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <LanguageProvider defaultNamespaces={["common"]}>
      <UserProvider>
        <BrowserRouter>
          <Nav />
          <Routes>
            <Route path="/" element={<App />} /> {/* FŐOLDAL */}
            <Route path="/register" element={<Reg />} /> {/*  REGISZTRÁCIÓ */}
            <Route path="/login" element={<Login />} /> {/*  BEJELENTKEZÉS */}
            <Route path="/logout" element={<Logout />} /> {/*  KIJELENTKEZÉS */}
            <Route path="/profil" element={<Profil />} />{" "}
            {/*  FELHASZNÁLÓ PROFILJA */}
            <Route
              path="/profil/jelszo-modositas"
              element={<Password />}
            />{" "}
            {/*  JELSZÓ MÓDOSÍTÁS */}
            <Route path="/osszesauto" element={<AllCar />} />{" "}
            {/*  ÖSSZES AUTÓ AMIT KIADUNK */}
            <Route path="/adatlap/:id" element={<CarData />} />{" "}
            {/*  AUTÓK ADATLAPJAI */}
            <Route path="/feladas" element={<CarUpload />} />{" "}
            {/*  AUTÓ FELTÖLTÉS */}
            <Route path="/kapcsolat" element={<Contact />} /> {/*  KAPCSOLAT */}
            <Route path="/rolunk" element={<AboutUs />} /> {/*  RÓLUNK */}
            <Route path="/berles" element={<CarRent />} /> {/*  AUTÓ BÉRLÉS */}
            <Route path="/gyik" element={<FAQ />} /> {/*  GYAKORI KÉRDÉSEK */}
            <Route path="/biztonsag" element={<Security />} />{" "}
            {/*  BIZTONSÁG */}
            <Route path="/kovetelmenyek" element={<Requirements />} />{" "}
            {/*  KÖVETELMENYEK */}
            <Route path="/profil/modositas" element={<EditProfile />} />{" "}
            {/*  FELAHSZNÁLÓI PROFIL MÓDOSÍTÁS */}
            <Route path="*" element={<NotFound />} />
          </Routes>
          <Toaster theme="light"
            className="bg-white"
            toastOptions={{
              className: "bg-white border border-gray-200 shadow-md",
              style: {
                background: "white",
                color: "black",
              },
            }} />
          <Footer />
        </BrowserRouter>
      </UserProvider>
    </LanguageProvider>
  </StrictMode>
);
