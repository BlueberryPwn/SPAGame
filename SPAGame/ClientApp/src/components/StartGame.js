import * as yup from "yup";
import axios from "../lib/axios";
import { Button, Spinner, TextInput } from "flowbite-react";
import { jwtDecode } from "jwt-decode";
import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import { yupResolver } from "@hookform/resolvers/yup";
import GameOver from "./GameOver";

function parseToken() {
  try {
    const token = localStorage.getItem("token");
    const decoded = jwtDecode(token);
    return decoded.AccountId;
  } catch (error) {
    console.error(error);
  }
}

const validationSchema = yup.object().shape({
  Guess: yup
    .number("Your guess has to be a number.")
    .min(1, "Your guess has to contain at least 1 number.")
    .max(100, "Your guess cannot contain more than 3 numbers.")
    .required("Please enter your guess."),
});

export const StartGame = () => {
  const [gameActive, setGameActive] = useState("");
  const [gameAttempts, setGameAttempts] = useState("");
  const [gameId, setGameId] = useState("");
  const [guess, setGuess] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const Guess = { guess };

  const {
    register,
    handleSubmit,
    formState: { errors, isValid, isSubmitting },
  } = useForm({
    resolver: yupResolver(validationSchema),
    defaultValues: {
      Guess: "",
    },
  });

  useEffect(() => {
    const fetchData = async () => {
      setIsLoading(true);
      try {
        const token = localStorage.getItem("token");
        const retrievedAccountId = parseToken(token);
        const response = await axios.post(
          `https://localhost:44487/Game/playgame?AccountId=${retrievedAccountId}`
        );
        setGameActive(response.data.gameActive);
        setGameAttempts(response.data.gameAttempts);
        setGameId(response.data.gameId);
        console.log(response.data);
      } catch (error) {
        console.error(error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchData();
  }, []);

  const onSubmitHandler = async (data) => {
    setIsLoading(true);
    try {
      const token = localStorage.getItem("token");
      const retrievedAccountId = parseToken(token);
      const response = await axios.post(
        `https://localhost:44487/Game/makeguess?AccountId=${retrievedAccountId}&GameId=${gameId}&GameGuess=${guess}`
      );
      setGameActive(response.data.gameActive);
      setGameAttempts(response.data.gameAttempts);
      console.log(response.data);
    } catch (error) {
      console.error(error);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div>
      {isLoading ? (
        <div className="p-2 text-center flex items-center justify-center">
          <Spinner aria-label="Loading profile data" />
        </div>
      ) : (
        <>
          {gameActive ? (
            <>
              <h1 className="m-2 p-2 text-sm font-medium flex items-center justify-center">
                Guess the correct number between 1-100.
              </h1>
              <form
                className="max-w-md"
                onSubmit={handleSubmit(onSubmitHandler)}
              >
                <div className="mb-4 block">
                  <p className="mb-2 font-medium text-sm flex items-center justify-center">
                    You have {gameAttempts} attempt(s) left!
                  </p>
                  <TextInput
                    {...register("Guess")}
                    shadow
                    type="int"
                    placeholder="Number..."
                    onChange={(e) => setGuess(e.target.value)}
                  />
                  <p className="text-sm italic">{errors.Guess?.message}</p>
                </div>
                <div className="m-2 p-2 flex items-center justify-center">
                  <Button type="submit" disabled={!isValid || isSubmitting}>
                    Guess!
                  </Button>
                </div>
              </form>
            </>
          ) : (
            <GameOver />
          )}
        </>
      )}
    </div>
  );
};

export default StartGame;
