import React from 'react';
import { Container, Carousel } from 'react-bootstrap';
import CarouselImage1 from '../Images/carousel1.png';
import CarouselImage2 from '../Images/carousel2.png';
import CarouselImage3 from '../Images/carousel3.png';
import '../Styles/Home.css';

function HomeCarousel() {
  return (
    <Container className="home-carousel mx-auto">
      <Carousel>
        <Carousel.Item interval={2000}>
          <img className="d-block w-100 img-fluid home-carousel-image" src={CarouselImage1} alt="First slide" />
          <Carousel.Caption className="caption">
            <h1>Plan your workout!</h1>
            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
          </Carousel.Caption >
        </Carousel.Item>
        <Carousel.Item interval={2000}>
          <img className="d-block w-100 img-fluid home-carousel-image" src={CarouselImage2} alt="Second slide" />
          <Carousel.Caption className="caption">
            <h1>Count your calorie intake!</h1>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item interval={2000}>
          <img className="d-block w-100 img-fluid home-carousel-image" src={CarouselImage3} alt="Third slide" />
          <Carousel.Caption className="caption">
            <h1>Check out our workout videos and products!</h1>
            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>
    </Container>
  );
}

export default HomeCarousel;
