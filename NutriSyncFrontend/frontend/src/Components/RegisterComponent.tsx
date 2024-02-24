import axios from "axios";
import backendUrl from "../Secrets/backendurl";
import React, { useState } from "react";
import { Form, Button, Container, Alert } from "react-bootstrap";
import { RegistrationFormData } from "../Models/RegistrationFormData";
import { useNavigate } from "react-router-dom";

const RegisterComponent: React.FC = () => {
  const [formData, setFormData] = useState<RegistrationFormData>({
    username: "",
    email: "",
    password: "",
  });
  const [successful, setSuccessful] = useState<boolean>(false);
  const navigate = useNavigate();

  const registerUser = async (userData: RegistrationFormData) => {
    try {
      const response = await axios.post(
        `${backendUrl}/Auth/Register`,
        userData
      );
      console.log(response.data);

      if (response.status === 201) {
        setSuccessful(true);
        setTimeout(() => {
          navigate("/login");
        }, 5000);
      }
    } catch (error) {
      console.error("Registration failed", error);
    }
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    registerUser(formData);
  };

  return (
    <>
    <Container className="d-flex justify-content-center align-items-center ">
      <Form className="w-50" onSubmit={handleSubmit}>
        <h2 className="mb-3 text-center">Register</h2>
        <Form.Group className="mb-3" controlId="formUsername">
          <Form.Label>Username</Form.Label>
          <Form.Control
            type="text"
            placeholder="example"
            name="username"
            value={formData.username}
            onChange={handleChange}
            required
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control
            type="email"
            placeholder="example@example.com"
            name="email"
            value={formData.email}
            onChange={handleChange}
            required
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control
            type="password"
            placeholder="Ex@mple123"
            name="password"
            value={formData.password}
            onChange={handleChange}
            required
          />
        </Form.Group>
        <div className="text-center">
          <Button variant="primary" type="submit">
            Register
          </Button>
        </div>
      </Form>
    </Container>
      {successful && (
        <Alert variant="success">
          Registration successful! Redirecting to Login page in 5 seconds.
        </Alert>
      )}
    </>
  );
};

export default RegisterComponent;
