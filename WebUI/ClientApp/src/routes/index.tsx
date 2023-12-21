import { lazy } from 'react'
import { Route, Routes } from 'react-router-dom'
import MainApp from '../components/layout/MainApp'

const Login = lazy(() => import('../pages/auth/Login'))

const AppRoutes = () => {
  return (
    <Routes>
    <Route path='login' element={<Login />} />
      <Route path='/' element={<MainApp />}>
      </Route>
    </Routes>
  )
}

export default AppRoutes
