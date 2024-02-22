import { Col, Container, Row } from "react-bootstrap";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import { useNavigate } from "react-router-dom";

const HomeCards: React.FC = () => {
  const navigate = useNavigate();

  return (
    <Container>
      <Row>
      <Col>
        {/*first card*/}
        <Card className="text-center" style={{ width: "50rem" }}>
          <Card.Header>Why NutriSync?</Card.Header>
          <Card.Body>
            <Card.Title>FREE</Card.Title>
            <Card.Text>
              Most websites give you help to start your healthy lifestyle and
              workout for money. <br />
              NutriSync doesn't.
            </Card.Text>
            <Button variant="primary" onClick={() => navigate("/register")}>
              Register now!
            </Button>
          </Card.Body>
          <Card.Footer className="text-muted"></Card.Footer>
        </Card>
        </Col>
        {/*second card*/}
        <Col>
        <Card className="text-center" style={{ width: "50rem" }}>
          <Card.Header>What do we offer?</Card.Header>
          <Card.Body>
            <Card.Title>Our features</Card.Title>
            <Card.Text>
              Personalized Eating Plans
              <br />
              Tailor your nutrition journey with customizable eating plans to
              meet your unique dietary needs.
              <br />
              <br />
              Calorie Tracking Made Easy
              <br />
              Utilize an external API to effortlessly calculate and monitor the
              daily calorie intake.
              <br />
              <br />
              Diverse Workout Videos
              <br />
              Access a vast library of workout videos catering to various
              fitness levels and preferences.
            </Card.Text>
            <Button variant="primary">Check it out!</Button>
          </Card.Body>
          <Card.Footer className="text-muted"></Card.Footer>
        </Card>
        </Col>

        {/*third card*/}
        <Col>
          <Card className="text-center" style={{ width: "50 rem" }}>
            <Card.Header>Boost your progress!</Card.Header>
            <Card.Body>
              <Card.Title>Workout Products</Card.Title>
              <Card.Text>
                We have what you need to start! <br />
                Check out our products!
              </Card.Text>
              <Button variant="primary" onClick={() => navigate("/products")}>
                Browse
              </Button>
            </Card.Body>
            <Card.Footer className="text-muted"></Card.Footer>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default HomeCards;
