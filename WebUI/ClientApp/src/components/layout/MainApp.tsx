import { Outlet } from 'react-router'

const MainApp = () => {
  return (
    <div>
      <div>header</div>
      <div>navbar</div>
      <Outlet />
    </div>
  )
}

export default MainApp
