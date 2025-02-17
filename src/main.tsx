import { createRoot } from 'react-dom/client'
import App from './App.tsx'
import Nav from "./components/Nav.tsx"
import Footer from "./components/Footer.tsx"
import { StrictMode } from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Reg from './components/Reg.tsx'
import Login from './components/Login.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <BrowserRouter>
      <Nav />
      <Routes>
        <Route path='/' element={<App />} />
        <Route path="/register" element={<Reg />} />
        <Route path="/login" element={<Login />} />
      </Routes>
      <Footer />
    </BrowserRouter>
  </StrictMode>
)
