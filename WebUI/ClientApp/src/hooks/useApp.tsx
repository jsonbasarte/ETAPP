import httpHelper from "../services/axios";
import { useNavigate } from "react-router-dom";

const useApp = () => {
    const navigate = useNavigate();
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

      return {
        getCurrentUser
      }
};

export default useApp;
