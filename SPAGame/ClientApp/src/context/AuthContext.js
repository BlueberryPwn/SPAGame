import Cookies from "js-cookie";
import React, { createContext, useEffect, useState } from "react";

export const AuthContext = createContext({ authToken: null });

export const AuthProvider = ({ children }) => {
  const [authToken, setAuthToken] = useState(null);

  const authValue = { authToken, setAuthToken };

  useEffect(() => {
    const checkAuthToken = () => {
      const token = Cookies.get("token");
      if (token) setAuthToken(token);
    };

    checkAuthToken();
  }, []);

  return (
    <AuthContext.Provider value={authValue}>{children}</AuthContext.Provider>
  );
};
