import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { login } from "../../managers/authManager";
import { Button, FormFeedback, FormGroup, Input, Label, Form, Container, Row, Col } from "reactstrap";
import '../styles/styles.css';

export default function Login({ setLoggedInUser }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [failedLogin, setFailedLogin] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const user = await login({ email, password });
      setLoggedInUser(user);
      navigate("/");
    } catch (error) {
      setFailedLogin(true);
    }
  };

  return (
    <Container className="mt-5 center-content full-width">
      <Row className="justify-content-center full-width">
        <Col md={6} className="center-content full-width">
          <h3>Login</h3>
          <Form onSubmit={handleSubmit} className="full-width">
            <FormGroup>
              <Label>Email</Label>
              <Input
                invalid={failedLogin}
                type="text"
                value={email}
                onChange={(e) => {
                  setFailedLogin(false);
                  setEmail(e.target.value);
                }}
                className="full-width"
              />
            </FormGroup>
            <FormGroup>
              <Label>Password</Label>
              <Input
                invalid={failedLogin}
                type="password"
                value={password}
                onChange={(e) => {
                  setFailedLogin(false);
                  setPassword(e.target.value);
                }}
                className="full-width"
              />
              <FormFeedback>Login failed.</FormFeedback>
            </FormGroup>
            <Button color="primary" type="submit" className="full-width">Login</Button>
          </Form>
          <p>
            Don't have an account? <Link to="/register">Register here</Link>
          </p>
        </Col>
      </Row>
    </Container>
  );
}