import React, { useState } from 'react';
import { Form, Button, Container, Row, Col, Alert, Spinner } from 'react-bootstrap';
import APIKey from '../Secrets/APIKey';
import CaloriePic from '../Images/caloriecounter.jpg'

interface NutritionData {
  name: string;
  calories: number;
  serving_size_g: number;
  fat_total_g: number;
  fat_saturated_g: number;
  protein_g: number;
  sodium_mg: number;
  potassium_mg: number;
  cholesterol_mg: number;
  carbohydrates_total_g: number;
  fiber_g: number;
  sugar_g: number;
}

const CalorieCounter: React.FC = () => {
  const [itemName, setItemName] = useState<string>('');
  const [nutritionData, setNutritionData] = useState<NutritionData | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  const baseURL: string = "https://api.api-ninjas.com/v1/nutrition?query=";

  const handleCheckCalories = async () => {
    setLoading(true);
    try {
      const response = await fetch(`${baseURL + itemName}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'X-Api-Key': APIKey
        }
      });

      if (response.ok) {
        const data: NutritionData[] = await response.json();
        setLoading(false); // Set loading to false when fetching is completed
        if (data.length > 0) {
          setNutritionData(data[0]);
          setError(null);
        } else {
          setNutritionData(null);
          setError('No data found for the item.');
        }
      } else {
        setError('Error fetching calorie information');
      }
    } catch (error: any) {
      setError('Error fetching calorie information: ' + error.message);
    }
  };

  return (
    <Container fluid>
      <Row>
        <Col md={6} style={{ backgroundImage: `url(${CaloriePic})`, backgroundSize: 'cover', backgroundPosition: 'center', height: '100vh' }}>
        </Col>
        <Col md={6}>
          <Container className="h-100">
            <Row className="justify-content-center align-items-center h-100">
              <Col md={8}>
                <Form>
                  <Form.Group controlId="itemName">
                  <h1>Calorie Counter</h1>
                    <Form.Label>Item Name:</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="Enter item name"
                      value={itemName}
                      onChange={(e) => setItemName(e.target.value)}
                    />
                  </Form.Group>
                  <Button variant="primary" onClick={handleCheckCalories}>
                    Check Nutrition
                  </Button>
                </Form>
                {error && <Alert variant="danger">{error}</Alert>}
                {loading && (
                  <div className="text-center mt-4">
                    <Spinner animation="border" variant="primary" />
                  </div>
                )}
                {nutritionData && !loading && (
                  <div className="mt-4">
                   
                    <h5>Nutrition Information for {itemName}</h5>
                    <ul>
                      <li>Calories: {nutritionData.calories} cal</li>
                      <li>Serving Size: {nutritionData.serving_size_g} g</li>
                      <li>Total Fat: {nutritionData.fat_total_g} g</li>
                      <li>Saturated Fat: {nutritionData.fat_saturated_g} g</li>
                      <li>Protein: {nutritionData.protein_g} g</li>
                      <li>Sodium: {nutritionData.sodium_mg} mg</li>
                      <li>Potassium: {nutritionData.potassium_mg} mg</li>
                      <li>Cholesterol: {nutritionData.cholesterol_mg} mg</li>
                      <li>Total Carbohydrates: {nutritionData.carbohydrates_total_g} g</li>
                      <li>Fiber: {nutritionData.fiber_g} g</li>
                      <li>Sugar: {nutritionData.sugar_g} g</li>
                    </ul>
                  </div>
                )}
              </Col>
            </Row>
          </Container>
        </Col>
      </Row>
    </Container>
  );
};

export default CalorieCounter;
