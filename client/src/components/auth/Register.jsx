import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { FormGroup, Label, Input, Button, Form } from "reactstrap";
import { register } from "../../managers/authManager";

export default function Register({ setLoggedInUser }) {
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const [passwordMismatch, setPasswordMismatch] = useState(false);
  const [registrationFailure, setRegistrationFailure] = useState(false);

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setPasswordMismatch(true);
    } else {
      const newUser = {
        userName,
        email,
        password,
      };
      register(newUser).then((user) => {
        if (user) {
          setLoggedInUser(user);
          navigate("/"); // navigate to the weeklyplanner page after successful registration
        } else {
          setRegistrationFailure(true);
        }
      }).catch(() => {
        setRegistrationFailure(true);
      });
    }
  };

  return (
    <div className="container" style={{ maxWidth: "500px" }}>
      <h3>Sign Up</h3>
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label>Email</Label>
          <Input
            type="email"
            value={email}
            onChange={(e) => {
              setEmail(e.target.value);
            }}
          />
        </FormGroup>
        <FormGroup>
          <Label>User Name</Label>
          <Input
            type="text"
            value={userName}
            onChange={(e) => {
              setUserName(e.target.value);
            }}
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
          />
        </FormGroup>
        {passwordMismatch && <p className="text-danger">Passwords do not match</p>}
        {registrationFailure && <p className="text-danger">Registration failed</p>}
        <Button color="primary" type="submit">Register</Button>
      </Form>
      <p>
        Already have an account? <Link to="/login">Login here</Link>
      </p>
    </div>
  );
}