import { lazy } from 'react'
import { Route, Routes } from 'react-router-dom'
import MainApp from '../components/layout/MainApp'

const Login = lazy(() => import('../pages/auth/Login'))
const Home  = lazy(() => import('../pages/Home/Home'));
const Transaction = lazy(() => import('../pages/Transaction/Transaction'));
const Wallet = lazy(() => import('../pages/Wallet/Wallet'));

const AppRoutes = () => {
  return (
    <Routes>
    <Route path='login' element={<Login />} />
      <Route path='/' element={<MainApp />}>
        <Route path='home' element={<Home />} />
        <Route path='transaction' element={<Transaction />} />
        <Route path='wallet' element={<Wallet />} />
      </Route>
    </Routes>
  )
}

export default AppRoutes
 