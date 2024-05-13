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

function Highscores() {
  return (
    <div className="flex h-screen w-screen flex-col items-center justify-center bg-gradient-to-br from-cyan-500">
      <div className="container-md box-content rounded p-6 border-2 bg-white">
        <div className="flex items-center justify-center text-xl font-bold">
          <div>
            <p className="p-1 flex items-center justify-center font-medium">
              Highscores
            </p>
            <p className="flex items-center justify-center font-medium text-sm">
              Top 10 scores!
            </p>
            <p className="flex items-center justify-center font-medium text-sm">
              Sort by today or all-time!
            </p>
          </div>
        </div>
        <ButtonGroup className="p-4 flex items-center justify-center">
          <Button color="gray">Today</Button>
          <Button color="gray">All-time</Button>
        </ButtonGroup>
        <Table>
          <TableHead>
            <TableHeadCell>Player</TableHeadCell>
            <TableHeadCell>Score</TableHeadCell>
          </TableHead>
          <TableBody className="divide-y">
            <TableRow className="bg-white dark:border-gray-700 dark:bg-gray-800">
              <TableCell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                Pizza1
              </TableCell>
              <TableCell>100</TableCell>
            </TableRow>
            <TableRow className="bg-white dark:border-gray-700 dark:bg-gray-800">
              <TableCell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                Burrito2
              </TableCell>
              <TableCell>50</TableCell>
            </TableRow>
            <TableRow className="bg-white dark:border-gray-700 dark:bg-gray-800">
              <TableCell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                Soup3
              </TableCell>
              <TableCell>5</TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </div>
    </div>
  );
}

export default Highscores;
