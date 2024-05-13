import { AuthContext } from "../context/AuthContext";
import { Avatar, Dropdown, Navbar } from "flowbite-react";
import axios from "../lib/axios";
import Home from "../assets/home.png";
import { useNavigate } from "react-router-dom";
import React, { useContext } from "react";
import { toast } from "react-toastify";
import User from "../assets/user.png";

export const Nav = () => {
  const { authToken, setAuthToken } = useContext(AuthContext);
  const navigate = useNavigate();

  const Logout = async () => {
    try {
      const response = await axios.post("https://localhost:44487/auth/logout");
      console.log(response);
      localStorage.removeItem("token");
      setAuthToken(null);
      navigate("/login", { replace: true });
      toast.success("Logged out successfully.", {
        position: "bottom-right",
      });
    } catch (error) {
      console.error(error);
      toast.error("ERROR: Something went wrong.", {
        position: "bottom-right",
      });
    }
  };

  return authToken ? (
    <Navbar fluid rounded>
      <Navbar.Brand href="/">
        <img src={Home} className="h-5" alt="Home" />
      </Navbar.Brand>
      <Navbar.Collapse>
        <Navbar.Link href="/highscores">Highscores</Navbar.Link>
        <Navbar.Link href="/profile">Profile</Navbar.Link>
      </Navbar.Collapse>
      <div className="flex md:order-2">
        <Dropdown
          arrowIcon={false}
          inline
          label={
            <Avatar
              className="h-5" // hidden md:flex
              alt="User settings"
              img={User}
              rounded
              size="xs"
            />
          }
        >
          <Dropdown.Item href="/profile">Profile</Dropdown.Item>
          <Dropdown.Divider />
          <Dropdown.Item onClick={Logout}>Logout</Dropdown.Item>
        </Dropdown>
        <Navbar.Toggle />
      </div>
    </Navbar>
  ) : (
    <Navbar fluid rounded>
      <Navbar.Brand href="/">
        <img src={Home} className="h-5" alt="Home" />
      </Navbar.Brand>
      <Navbar.Toggle />
      <Navbar.Collapse>
        <Navbar.Link href="/login">Login</Navbar.Link>
        <Navbar.Link href="/register">Register</Navbar.Link>
      </Navbar.Collapse>
    </Navbar>
  );
};
