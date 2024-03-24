import { Outlet, useNavigate } from "react-router-dom";
import { ProfileContext } from "../context/ProfileContext";
import React, { useContext, useEffect } from "react";

const ProtectedRoutes = () => {
  const navigate = useNavigate();
  const { profile, setProfile } = useContext(ProfileContext);

  useEffect(() => {
    //const profile = response.data.profile;
    setProfile(profile);
  }, [setProfile]);

  return profile ? (
    <Outlet />
  ) : (
    navigate("/login")
    // Implementera någon loading spinner som ersätter vita flickern som syns vid redirect
  );
};

export default ProtectedRoutes;
