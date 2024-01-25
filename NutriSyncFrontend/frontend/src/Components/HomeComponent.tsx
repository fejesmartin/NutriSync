import React from 'react';
import { Container, Row, Col, Button } from 'react-bootstrap';
//import '../Styles/Home.css'; // Import the custom CSS file

const HomeComponent: React.FC = () => {
  return (
    <Container fluid className="home-container text-center">
          <div className="content">
            <h1 className="title">Welcome to NutriSync!</h1>
            <p className="subtitle">
              Start your journey to a healthier life!
            </p>
          </div>
    </Container>
  );
};

export default HomeComponent;