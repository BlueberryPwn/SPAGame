import { AuthContext } from "../context/AuthContext";
import React, { useContext, useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";

const ProtectedRoutes = () => {
  const navigate = useNavigate();
  const { authToken, setAuthToken } = useContext(AuthContext);

  useEffect(() => {
    const token = localStorage.getItem("token");
    setAuthToken(token);
  }, [setAuthToken]);

  return authToken ? <Outlet /> : navigate("/login", { replace: true });
};

export default ProtectedRoutes;
