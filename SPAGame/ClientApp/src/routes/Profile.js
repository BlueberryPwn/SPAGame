import axios from "../lib/axios";
import { List } from "flowbite-react";
import { useEffect, useState } from "react";

function Profile() {
  const [error, setError] = useState(null);
  const [profileData, setProfileData] = useState(null);

  useEffect(() => {
    try {
      const fetchData = async () => {
        const response = await axios.get(
          "https://localhost:44487/profile/page"
        );
        console.log(response);
        setProfileData(response.data);
      };
      fetchData();
    } catch (error) {
      console.log(error);
      setError(error);
    }
  }, [error]);

  return (
    <div className="flex h-screen w-screen flex-col items-center justify-center bg-gradient-to-br from-cyan-500">
      <div className="container-md box-content rounded p-4 border-2 bg-white">
        <h2 className="m-4 p-4 flex items-center justify-center text-xl font-bold">
          Profile
        </h2>
        <List unstyled>
          <List.Item>Games completed: {profileData.GamesCompleted}</List.Item>
          <List.Item>Games won: {profileData.GamesWon}</List.Item>
          <List.Item>Games lost: {profileData.GamesLost}</List.Item>
        </List>
      </div>
    </div>
  );
}

export default Profile;
