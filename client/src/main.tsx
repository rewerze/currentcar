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

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <UserProvider>
      <BrowserRouter>
        <Nav />
        <Routes>
          <Route path='/' element={<App />} />
          <Route path="/register" element={<Reg />} />
          <Route path="/login" element={<Login />} />
          <Route path='/logout' element={<Logout />} />
          <Route path='/profil' element={<Profil />} />
          <Route path='/jelszo-modositas' element={<Password />} />
        </Routes>
        <Footer />
      </BrowserRouter>
    </UserProvider>
  </StrictMode>
)
