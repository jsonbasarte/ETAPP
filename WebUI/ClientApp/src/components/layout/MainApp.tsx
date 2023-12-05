import { useEffect } from "react";
import { Outlet } from "react-router";
import httpHelper from "../../services/axios";
import { useNavigate } from "react-router-dom";

const MainApp = () => {
  const navigate = useNavigate();
  useEffect(() => {
    const getCurrentUser = async () => {
      try {
        const response = await httpHelper.get(
          "/api/authentication/current-user"
        );
        console.log("response: ", response);
      } catch (error) {
        navigate("/login");
      }
    };
    getCurrentUser();
  }, []);
  return (
    <div>
      <div>header</div>
      <div>navbar</div>
      <Outlet />
    </div>
  );
};

export default MainApp;
