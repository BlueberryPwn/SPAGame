import Cookies from "js-cookie";
import React, { createContext, useContext, useEffect, useState } from "react";

const AuthContext = createContext({ authToken: null });

export const useAuth = () => useContext(AuthContext);

export const AuthProvider = ({ children }) => {
  const [authToken, setAuthToken] = useState(null);

  useEffect(() => {
    const token = Cookies.get("token", "valid");
    if (token) setAuthToken(token);
  }, []);

  const contextValue = { authToken, setAuthToken };

  return (
    <AuthContext.Provider value={contextValue}>{children}</AuthContext.Provider>
  );
};

export default AuthContext;
