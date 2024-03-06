import AuthContext from "../context/AuthContext";
import React, { useContext } from "react";
import { Navigate } from "react-router-dom";

const ProtectedRoutes = ({ children }) => {
  const { authToken } = useContext(AuthContext);

  if (!authToken) {
    // this successfully redirects the user when not they're logged in but otherwise fails
    return <Navigate to="/login" />;
  }

  return children;
};

/*useEffect(() => {
  if (!authToken) {
    console.log(authToken);
    <Navigate to="/login" />;
  }
}, [authToken, children]);*/

export default ProtectedRoutes;
