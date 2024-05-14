import { AuthContext } from "../context/AuthContext";
import { Spinner } from "flowbite-react";
import React, { useContext, useEffect, useState } from "react";
import { Outlet, useNavigate } from "react-router-dom";

const ProtectedRoutes = () => {
  const navigate = useNavigate();
  const { authToken, setAuthToken } = useContext(AuthContext);
  const [isLoading, setIsLoading] = useState(true);
  const [shouldNavigate, setShouldNavigate] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const token = localStorage.getItem("token");
        setAuthToken(token);
        if (!token) {
          setShouldNavigate(true);
        }
      } catch (error) {
        console.error(error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchData();
  }, [setAuthToken]);

  if (shouldNavigate) {
    navigate("/login", { replace: true });
    return null;
  }

  return isLoading ? (
    <div className="flex h-screen w-screen flex-col items-center justify-center bg-gradient-to-br from-cyan-500">
      {/*<div className="text-center">
        <Spinner aria-label="Loading" />
      </div>*/}
    </div>
  ) : (
    <Outlet />
  );
};

export default ProtectedRoutes;
