import axios from "../lib/axios";
import { jwtDecode } from "jwt-decode";
import { List, Spinner } from "flowbite-react";
import { useEffect, useState } from "react";

function parseToken() {
  try {
    const token = localStorage.getItem("token");
    const decoded = jwtDecode(token);
    return decoded.AccountId;
  } catch (error) {
    console.error(error);
  }
}

function Profile() {
  const [profileData, setProfileData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const token = localStorage.getItem("token");
        const retrievedAccountId = parseToken(token);
        const response = await axios.get(
          `https://localhost:44487/account/profile?AccountId=${retrievedAccountId}`,
          {
            headers: {
              Authorization: `${token}`,
            },
          }
        );
        setProfileData([response.data]);
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
  }, []); // Empty dependency array for initial render only

  useEffect(() => {
    console.log(profileData); // Log profileData when it changes
  }, [profileData]); // Dependency array with profileData

  return (
    <div className="flex h-screen w-screen flex-col items-center justify-center bg-gradient-to-br from-cyan-500">
      <div className="container-md box-content rounded p-6 border-2 bg-white">
        <h2 className="m-4 p-4 flex items-center justify-center text-xl font-bold">
          Profile
        </h2>
        <List className="p-4">
          {profileData.length > 0 && (
            <>
              <List.Item>Games played: {profileData[0].gamesPlayed}</List.Item>
              <List.Item>Games won: {profileData[0].gamesWon}</List.Item>
              <List.Item>Games lost: {profileData[0].gamesLost}</List.Item>
            </>
          )}
          {!profileData.length && (
            <div className="text-center">
              <Spinner aria-label="Default status example" />
            </div>
          )}
        </List>
      </div>
    </div>
  );
}

export default Profile;
