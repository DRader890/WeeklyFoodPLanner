import { useState } from "react";
import { useNavigate, NavLink as RRNavLink } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);
  const navigate = useNavigate();

  const toggleNavbar = () => setOpen(!open);

  const handleLogout = async (e) => {
    e.preventDefault();
    setOpen(false);
    try {
      await logout();
      setLoggedInUser(null);
      navigate("/login"); // Navigate to the login page after logout
    } catch (error) {
      console.error("Logout error:", error);
    }
  };

  return (
    <div>
      <Navbar color="light" light fixed="true" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          Food-Planner
        </NavbarBrand>
        {loggedInUser ? (
          <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
              <Nav navbar>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/">
                    Weekly Planner
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/foods">
                    Your Foods
                  </NavLink>
                </NavItem>
              </Nav>
            </Collapse>
            <Button color="primary" onClick={handleLogout}>
              Logout
            </Button>
          </>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}