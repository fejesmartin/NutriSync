import React from "react";
import { Container, Row, Col, Card } from "react-bootstrap";
import YouTube from "react-youtube";

const Workout: React.FC = () => {
  return (
    <Container fluid className="text-center">
      <h1 className="mb-4">Workout videos</h1>
      <Row className="justify-content-center">
        <Col md={6}>
          <Card className="mb-4">
            <Card.Body>
              <Card.Title>The PERFECT Beginner Workout</Card.Title>
              <Card.Subtitle className="mb-2 text-muted">
                ATHLEAN-X™
              </Card.Subtitle>
              <YouTube videoId="ixkQaZXVQjs" />
            </Card.Body>
          </Card>
        </Col>

        <Col md={6}>
          <Card className="mb-4">
            <Card.Body>
              <Card.Title>The Best Workout Routine for Beginners</Card.Title>
              <Card.Subtitle className="mb-2 text-muted">
                Magnus Method
              </Card.Subtitle>
              <YouTube videoId="GPq1_yGsa04" />
            </Card.Body>
          </Card>
        </Col>

        <Col md={6}>
          <Card className="mb-4">
            <Card.Body>
              <Card.Title>
                CARDIO WORKOUT FOR BEGINNERS From Home In 10 Minutes | No
                Equipment
              </Card.Title>
              <Card.Subtitle className="mb-2 text-muted">
                HealthifyMe
              </Card.Subtitle>
              <YouTube videoId="dj03_VDetdw" />
            </Card.Body>
          </Card>
        </Col>

        <Col md={6}>
          <Card className="mb-4">
            <Card.Body>
              <Card.Title>
                Complete Beginner’s Gym Guide (GYM EQUIPMENT TOUR / WORKOUT
                ROUTINES FOR FIRST TIMERS)
              </Card.Title>
              <Card.Subtitle className="mb-2 text-muted">
                KevTheTrainer
              </Card.Subtitle>
              <YouTube videoId="m1UF4RgGoY0" />
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default Workout;
