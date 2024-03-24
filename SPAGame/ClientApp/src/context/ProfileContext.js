import React, { createContext, useEffect, useState } from "react";

export const ProfileContext = createContext({ profile: null });

export const ProfileProvider = ({ children }) => {
  const [profile, setProfile] = useState(null);

  const profileValue = { profile, setProfile };

  useEffect(() => {
    const loadProfile = () => {
      if (profile) setProfile(profile);
    };

    loadProfile();
  }, [profile]);

  return (
    <ProfileContext.Provider value={profileValue}>
      {children}
    </ProfileContext.Provider>
  );
};
