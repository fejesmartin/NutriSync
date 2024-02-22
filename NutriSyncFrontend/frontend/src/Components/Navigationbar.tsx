import { useEffect, useState } from "react";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import { useNavigate } from "react-router-dom";
import { User } from "../Models/User";
import { jwtDecode } from "jwt-decode";
import { Alert } from "react-bootstrap";
import { Avatar } from "@mui/material";
import { getUserProfileFromLocalStorage } from '../Utils/getUserProfileFromLocalStorage';


const Navigationbar: React.FC = () => {
  const [userProfile, setUserProfile] = useState<User | null>(null);
  const [loggedOut, setLoggedOut] = useState<boolean>(false);
  const navigate = useNavigate();


  useEffect(() => {
    const userProfileString: string | null = localStorage.getItem("profile");

    if (userProfileString) {
      const userProfileData: User = JSON.parse(userProfileString);
      setUserProfile(userProfileData);
      console.log(userProfileData && userProfileData.profilePictureUrl);
    } else {
      setUserProfile(null);
    }
  }, [localStorage.getItem("profile")]);

  return (
    <>
      <Navbar collapseOnSelect expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Brand>NutriSync</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link onClick={() => navigate("/")}>Home</Nav.Link>
              <Nav.Link href="#plans">Plans</Nav.Link>
              <Nav.Link onClick={() => navigate("/products")}>
                Products
              </Nav.Link>
              <Nav.Link href="#workout">Workout</Nav.Link>
              <Nav.Link href="#healthyfoods">Healthy Foods</Nav.Link>
              <Nav.Link href="#calorie" onClick={()=> navigate("/calories")}>Calorie Counter</Nav.Link>
              <Nav.Link href="#plans">About Us</Nav.Link>
            </Nav>
            <Nav>
              {userProfile != undefined ? (
                <>
                <Avatar src={`${userProfile && userProfile.profilePictureUrl}`}/>
                <NavDropdown
                  title={userProfile && userProfile.userName}
                  id="collapsible-nav-dropdown"
                  style={{zIndex: 10000}}
                >
                  <NavDropdown.Item onClick={()=> navigate("/myprofile")}>Profile</NavDropdown.Item>
                  <NavDropdown.Item>Settings</NavDropdown.Item>
                  <NavDropdown.Item
                    onClick={() => {
                      localStorage.removeItem("profile");
                      setLoggedOut(true);
                      setTimeout(() => {
                        navigate("/login");
                        setLoggedOut(false);
                      }, 5000);
                    }}
                  >
                    Log out
                  </NavDropdown.Item>
                  <NavDropdown.Divider />
                </NavDropdown>
                </>
              ) : (
                <>
                  <Nav.Link onClick={() => navigate("/login")}>Login</Nav.Link>
                  <Nav.Link onClick={() => navigate("/register")}>
                    Register
                  </Nav.Link>
                </>
              )}
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      {loggedOut && (
        <Alert variant="success" className="mt-3">
          Logged out. Redirecting to Login page in 5 seconds.
        </Alert>
      )}
    </>
  );
};

export default Navigationbar;
