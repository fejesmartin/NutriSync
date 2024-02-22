import React, { useState } from "react";
import { Form, Button, Container } from "react-bootstrap";
import { LoginFormData } from "../Models/LoginFormData";
import backendUrl from "../Secrets/backendurl";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import { jwtDecode, JwtPayload } from "jwt-decode";
import { User } from "../Models/User";

const LoginComponent: React.FC = () => {
  const navigate = useNavigate();
  const cookies = new Cookies();

  const [formData, setFormData] = useState<LoginFormData>({
    email: "",
    password: "",
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const loginUser = async (userData: LoginFormData) => {
    try {
      const response = await axios.post(`${backendUrl}/Auth/Login`, userData);

      if (response.status == 200) {
        const responseData = response.data;

        // Create a new User object with the extracted username, email, and token
        const profile = new User(
          responseData.username,
          responseData.email,
          responseData.token
        );

        // Store the JWT token in a cookie with an expiration date
        cookies.set("token", responseData.token, {
          expires: new Date(30 * 60 * 1000),
        });

        // Store the user profile data in local storage
        localStorage.setItem("profile", JSON.stringify(profile));

        // Navigate the user to the home page ("/")
        navigate("/");
      }
    } catch (error) {
      console.error("Login failed", error);
    }
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    loginUser(formData);
  };

  return (
    <Container className="d-flex justify-content-center align-items-center ">
      <Form className="w-50" onSubmit={handleSubmit}>
        <h2 className="mb-3 text-center">Login</h2>
        <Form.Group className="mb-3" controlId="formEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control
            type="email"
            placeholder="Enter email"
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
            placeholder="Password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            required
          />
        </Form.Group>

        <div className="text-center">
          <Button variant="primary" type="submit">
            Login
          </Button>
        </div>
      </Form>
    </Container>
  );
};

export default LoginComponent;
