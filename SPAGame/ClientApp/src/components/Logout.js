import AuthContext from "../context/AuthContext";
import axios from "../lib/axios";
import Cookies from "js-cookie";
import { Navigate } from "react-router-dom";
import { toast } from "react-toastify";
import { useContext } from "react";

const Logout = () => {
  const { setAuthToken } = useContext(AuthContext);

  try {
    const response = axios.post("https://localhost:44487/auth/logout");
    console.log(response);
    Cookies.remove("token");
    setAuthToken(null);
    toast.success("Logged out successfully.", {
      position: "bottom-right",
    });
    <Navigate to="/login" />;
  } catch (error) {
    console.log(error);
    toast.error("ERROR: Something went wrong.", {
      position: "bottom-right",
    });
  }
};

export default Logout;

// fixa protectedroutes så att du inte har en route inuti en route.
// det gör att hooks inte funkar som det ska,
// och har du inte state hooks så kan inte sidan renderas om automatiskt
