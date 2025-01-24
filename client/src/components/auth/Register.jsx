import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { FormGroup, Label, Input, Button, Form, Container, Row, Col } from "reactstrap";
import { register } from "../../managers/authManager";
import '../styles/styles.css';

export default function Register({ setLoggedInUser }) {
  const [email, setEmail] = useState("");
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [passwordMismatch, setPasswordMismatch] = useState(false);
  const [registrationFailure, setRegistrationFailure] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (password !== confirmPassword) {
      setPasswordMismatch(true);
      return;
    }
    try {
      const user = await register({ email, userName, password });
      setLoggedInUser(user);
      navigate("/");
    } catch (error) {
      setRegistrationFailure(true);
    }
  };

  return (
    <Container className="mt-5 center-content full-width">
      <Row className="justify-content-center full-width">
        <Col md={6} className="center-content full-width">
          <h3>Sign Up</h3>
          <Form onSubmit={handleSubmit} className="full-width">
            <FormGroup>
              <Label>Email</Label>
              <Input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                className="full-width large-input"
              />
            </FormGroup>
            <FormGroup>
              <Label>User Name</Label>
              <Input
                type="text"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
                className="full-width large-input"
              />
            </FormGroup>
            <FormGroup>
              <Label>Password</Label>
              <Input
                invalid={passwordMismatch}
                type="password"
                value={password}
                onChange={(e) => {
                  setPasswordMismatch(false);
                  setPassword(e.target.value);
                }}
                className="full-width large-input"
              />
            </FormGroup>
            <FormGroup>
              <Label>Confirm Password</Label>
              <Input
                invalid={passwordMismatch}
                type="password"
                value={confirmPassword}
                onChange={(e) => {
                  setPasswordMismatch(false);
                  setConfirmPassword(e.target.value);
                }}
                className="full-width large-input"
              />
            </FormGroup>
            {passwordMismatch && <p className="text-danger">Passwords do not match</p>}
            {registrationFailure && <p className="text-danger">Registration failed</p>}
            <Button color="primary" type="submit" className="full-width">Register</Button>
          </Form>
          <p>
            Already have an account? <Link to="/login">Login here</Link>
          </p>
        </Col>
      </Row>
    </Container>
  );
}