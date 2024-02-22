import React from "react";
import { Outlet } from "react-router-dom";
import { Container, Row } from "react-bootstrap";
import Navigationbar from "../Components/Navigationbar";
import "../Styles/Layout.css";

const Layout: React.FC = () => {
  return (
    <Container fluid className="min-vh-100 main">
      <Row className="h-10">
        <Navigationbar />
      </Row>
      <Row className="flex-grow-1">
        <Outlet />
      </Row>
    </Container>
  );
};

export default Layout;
