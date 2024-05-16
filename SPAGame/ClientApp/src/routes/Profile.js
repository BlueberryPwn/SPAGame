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
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      setIsLoading(true);
      try {
        const token = localStorage.getItem("token");
        const retrievedAccountId = parseToken(token);
        const response = await axios.get(
          `https://localhost:44487/Account/profile?AccountId=${retrievedAccountId}`,
          {
            headers: {
              Authorization: `${token}`,
            },
          }
        );
        setProfileData([response.data]);
        console.log(response.data);
      } catch (error) {
        console.error(error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="flex h-screen w-screen flex-col items-center justify-center bg-gradient-to-br from-cyan-500">
      <div className="container-md box-content rounded p-4 border-2 bg-white">
        <h2 className="p-2 flex items-center justify-center text-xl font-bold">
          Profile
        </h2>
        {isLoading && (
          <div className="p-2 text-center flex items-center justify-center">
            <Spinner aria-label="Loading profile data." />
          </div>
        )}
        {profileData.length > 0 && (
          <>
            <List className="p-2">
              <List.Item>Games played: {profileData[0].gamesPlayed}</List.Item>
              <List.Item>Games won: {profileData[0].gamesWon}</List.Item>
              <List.Item>Games lost: {profileData[0].gamesLost}</List.Item>
            </List>
          </>
        )}
      </div>
    </div>
  );
}

export default Profile;
