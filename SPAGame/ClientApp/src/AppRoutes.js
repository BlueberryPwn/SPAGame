import { Highscores } from "./components/Highscores";
import { Home } from "./components/Home";
import { Login } from "./components/Login";
import { Profile } from "./components/Profile";
import { Register } from "./components/Register";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/highscores",
    element: <Highscores />,
  },
  {
    path: "/login",
    element: <Login />,
  },
  {
    path: "/profile",
    element: <Profile />,
  },
  {
    path: "/register",
    element: <Register />,
  },
];

export default AppRoutes;
