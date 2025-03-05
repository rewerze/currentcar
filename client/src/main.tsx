import { createRoot } from 'react-dom/client'
import App from './App.tsx'
import Nav from "./components/Nav.tsx"
import Footer from "./components/Footer.tsx"
import { StrictMode } from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Reg from './components/Reg.tsx'
import Login from './components/Login.tsx'
import { UserProvider } from './contexts/UserContext.tsx'
import Logout from './components/Logout.tsx'
import Profil from './components/Profile.tsx'
import Password from './components/Password.tsx'
import AllCar from './components/AllCar.tsx'
import CarData from './components/CarData.tsx'
import CarUpload from './components/CarUpload.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <UserProvider>
      <BrowserRouter>
        <Nav />
        <Routes>
          <Route path='/' element={<App />} />                       {/* FŐOLDAL */}
          <Route path="/register" element={<Reg />} />               {/*  REGISZTRÁCIÓ */}
          <Route path="/login" element={<Login />} />                {/*  BEJELENTKEZÉS */}
          <Route path='/logout' element={<Logout />} />              {/*  KIJELENTKEZÉS */}
          <Route path='/profil' element={<Profil />} />              {/*  FELHASZNÁLÓ PROFILJA */}
          <Route path='/jelszo-modositas' element={<Password />} />  {/*  JELSZÓ MÓDOSÍTÁS */}
          <Route path='/osszesauto' element={<AllCar />} />          {/*  ÖSSZES AUTÓ AMIT KIADUNK */}
          <Route path='/adatlap' element={<CarData />} />            {/*  AUTÓK ADATLAPJAI */}
          <Route path='/auto-feltoltes' element={<CarUpload />} />   {/*  AUTÓ FELTÖLTÉS */}
        </Routes>
        <Footer />
      </BrowserRouter>
    </UserProvider>
  </StrictMode>
)
