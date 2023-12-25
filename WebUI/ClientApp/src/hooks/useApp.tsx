import { useNavigate } from "react-router-dom";
import { getCurrentAuthUser } from "../services/auth/auth";

const useApp = () => {
  
    const navigate = useNavigate();

    const getCurrentUser = async () => {
        try {
          await getCurrentAuthUser();
        } catch (error) {
          navigate("/login");
        }
      };

      return {
        getCurrentUser
      }
};

export default useApp;
