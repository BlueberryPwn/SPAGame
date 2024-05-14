import axios from "../lib/axios";
import {
  Button,
  ButtonGroup,
  Spinner,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeadCell,
  TableRow,
} from "flowbite-react";
import { useEffect, useState } from "react";

function Highscore() {
  const [highscoreData, setHighscoreData] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  const handleButtonClick = async (type) => {
    setIsLoading(true);
    try {
      const response = await axios.get(
        `https://localhost:44487/Highscore/${type}`
      );
      setHighscoreData([response.data]);
    } catch (error) {
      console.error(error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    console.log(highscoreData);
  }, [highscoreData]);

  return (
    <div className="flex h-screen w-screen flex-col items-center justify-center bg-gradient-to-br from-cyan-500">
      <div className="container-md box-content rounded p-4 border-2 bg-white">
        <div className="flex items-center justify-center text-xl font-bold">
          <div>
            <p className="p-2 flex items-center justify-center font-medium">
              Highscore
            </p>
          </div>
        </div>
        <ButtonGroup className="p-2 flex items-center justify-center">
          <Button color="gray" onClick={() => handleButtonClick("today")}>
            Today
          </Button>
          <Button color="gray" onClick={() => handleButtonClick("alltime")}>
            All-time
          </Button>
        </ButtonGroup>
        {isLoading && (
          <div className="p-2 text-center flex items-center justify-center">
            <Spinner aria-label="Loading highscores" />
          </div>
        )}
        {highscoreData.length > 0 && (
          <Table striped>
            <TableHead>
              <TableHeadCell>Player</TableHeadCell>
              <TableHeadCell>Score</TableHeadCell>
            </TableHead>
            <TableBody>
              {highscoreData.map((item) =>
                item.$values.map((subItem) => (
                  // The contents are inside the nested array $values and cannot be displayed right away
                  // The nested array $values is accessed and its contents are mapped; they can then be displayed
                  <TableRow
                    key={subItem.accountId}
                    className="bg-white dark:border-gray-700 dark:bg-gray-800"
                  >
                    <TableCell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                      {subItem.accountName}
                    </TableCell>
                    <TableCell>{subItem.score}</TableCell>
                  </TableRow>
                ))
              )}
            </TableBody>
          </Table>
        )}
      </div>
    </div>
  );
}

export default Highscore;
