import { Navbar } from "flowbite-react";

function Nav() {
  return (
    <Navbar fluid rounded>
      <Navbar.Toggle />
      <Navbar.Collapse>
        <Navbar.Link href="/">Home</Navbar.Link>
        <Navbar.Link href="/login">Login</Navbar.Link>
        <Navbar.Link href="/register">Register</Navbar.Link>
      </Navbar.Collapse>
    </Navbar>
  );
}

export default Nav;
