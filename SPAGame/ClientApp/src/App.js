import "./styles/app.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "react-toastify/dist/ReactToastify.css";
import { ToastContainer } from "react-toastify";
import Foot from "./layouts/Foot";
import { Nav } from "./layouts/Nav";
import ProtectedRoutes from "./utils/ProtectedRoutes";
import Highscore from "./routes/Highscore";
import Home from "./routes/Home";
import Login from "./routes/Login";
import PageNotFound from "./routes/PageNotFound";
import Profile from "./routes/Profile";
import Register from "./routes/Register";

function App() {
  return (
    <div>
      <Router>
        <Nav />
        <ToastContainer />
        <Routes>
          <Route element={<Home />} path="/" exact />
          <Route element={<Login />} path="/login" />
          <Route element={<Register />} path="/register" />
          <Route element={<ProtectedRoutes />}>
            <Route element={<Highscore />} path="/highscore" />
            <Route element={<Profile />} path="/profile" />
          </Route>
          <Route element={<PageNotFound />} path="*" />
        </Routes>
        <Foot />
      </Router>
    </div>
  );
}

export default App;
