import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import APIKey from '../Secrets/APIKey';

interface CalorieCheckResponse {
    
          name: string,
          calories: number,
          serving_size_g: number,
          fat_total_g: number,
          fat_saturated_g: number,
          protein_g: number,
          sodium_mg: number,
          potassium_mg: number,
          cholesterol_mg: number,
          carbohydrates_total_g: number,
          fiber_g: number,
          sugar_g: number
    
}

interface ArrayCalorieCheckResponse extends Array<CalorieCheckResponse> {}

const CalorieCounter: React.FC = () => {
  const [itemName, setItemName] = useState<string>('');
  const [calories, setCalories] = useState<number | null>(null);
  const baseURL: string = "https://api.api-ninjas.com/v1/nutrition?query=";


  const handleCheckCalories = async () => {
    try {
      
      const response = await fetch(`${baseURL + itemName}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'X-Api-Key': APIKey
        }
      });

      if (response.ok) {
        const data: ArrayCalorieCheckResponse = await response.json();
        
        setCalories(data[0].calories);
      } else {
        console.error('Error fetching calorie information');
      }
    } catch (error) {
      console.error('Error fetching calorie information:', error);
    }
  };

  return (
    <div>
      <Form>
        <Form.Group controlId="itemName">
          <Form.Label>Item Name:</Form.Label>
          <Form.Control
            type="text"
            placeholder="Enter item name"
            value={itemName}
            onChange={(e) => setItemName(e.target.value)}
          />
        </Form.Group>
        <Button variant="primary" onClick={handleCheckCalories}>
          Check Calories
        </Button>
      </Form>
      {calories && (
        <div>
          <p>Calories for {itemName}: {calories}</p>
        </div>
      )}
    </div>
  );
};

export default CalorieCounter;
