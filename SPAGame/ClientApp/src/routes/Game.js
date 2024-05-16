import axios from "../lib/axios";
import { Button, Spinner } from "flowbite-react";
import { jwtDecode } from "jwt-decode";
import { useEffect, useState } from "react";
import { LoadGame } from "./../components/LoadGame";
import { StartGame } from "./../components/StartGame";

function parseToken() {
  try {
    const token = localStorage.getItem("token");
    const decoded = jwtDecode(token);
    return decoded.AccountId;
  } catch (error) {
    console.error(error);
  }
}

const Game = () => {
  const [GameComponent, setGameComponent] = useState(null);
  const [gameActive, setGameActive] = useState();
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      setIsLoading(true);
      try {
        const token = localStorage.getItem("token");
        const retrievedAccountId = parseToken(token);
        const response = await axios.get(
          `https://localhost:44487/Game/gamecheck?AccountId=${retrievedAccountId}`
        );
        setGameActive(response.data);
        console.log(response.data);
      } catch (error) {
        console.error(error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchData();
  }, []);

  const handleLoadGame = () => {
    setGameComponent(() => <LoadGame />);
  };

  const handleStartGame = () => {
    setGameComponent(() => <StartGame />);
  };

  return (
    <div className="flex h-screen w-screen flex-col items-center justify-center bg-gradient-to-br from-cyan-500">
      <div className="container-md box-content rounded p-4 border-2 bg-white">
        <div className="m-2 p-2 flex items-center justify-center">
          {isLoading ? (
            <div className="p-2 text-center flex items-center justify-center">
              <Spinner aria-label="Loading game data." />
            </div>
          ) : (
            GameComponent === null &&
            (gameActive ? (
              <Button type="submit" onClick={handleLoadGame}>
                Play
              </Button>
            ) : (
              <Button type="submit" onClick={handleStartGame}>
                Play
              </Button>
            ))
          )}
        </div>
        {GameComponent}
      </div>
    </div>
  );
};

export default Game;
