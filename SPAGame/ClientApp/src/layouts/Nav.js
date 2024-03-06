import AuthContext from "../context/AuthContext";
import { Avatar, Dropdown, Navbar } from "flowbite-react";
import Home from "../assets/home.png";
import Logout from "../components/Logout";
import React, { useContext } from "react";
import User from "../assets/user.png";

function Nav() {
  const { authToken } = useContext(AuthContext);

  if (authToken) {
    return (
      <Navbar fluid rounded>
        <Navbar.Brand href="/">
          <img src={Home} className="h-5" alt="Home" />
        </Navbar.Brand>
        <Navbar.Collapse>
          <Navbar.Link href="/highscores">Highscores</Navbar.Link>
          <Navbar.Link className="hidden lg:block" href="/profile">
            {" "}
            {/*try to fix it so that it only shows up on large sized window, maybe by not using Navbar.Collapse for small screen links only*/}
            Profile
          </Navbar.Link>
          <Navbar.Link className="hidden lg:block" onClick={Logout}>
            {" "}
            {/*try to fix it so that it only shows up on large sized window, maybe by not using Navbar.Collapse for small screen links only*/}
            Logout
          </Navbar.Link>
        </Navbar.Collapse>
        <div className="flex md:order-2">
          <Dropdown
            arrowIcon={false}
            inline
            label={
              <Avatar
                className="h-5 hidden md:flex"
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
    );
  }

  return (
    <Navbar fluid rounded>
      <Navbar.Brand href="/">
        <img src={Home} className="mr-3 h-6 sm:h-9" alt="Home" />
      </Navbar.Brand>
      <Navbar.Toggle />
      <Navbar.Collapse>
        <Navbar.Link href="/login">Login</Navbar.Link>
        <Navbar.Link href="/register">Register</Navbar.Link>
      </Navbar.Collapse>
    </Navbar>
  );
}

export default Nav;
