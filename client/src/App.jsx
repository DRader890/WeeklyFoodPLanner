import React, { useEffect, useState } from 'react';
import { Route, Routes, Navigate } from 'react-router-dom';
import { Spinner } from 'reactstrap';
import { tryGetLoggedInUser } from './managers/authManager';
import NavBar from './components/NavBar';
import ApplicationViews from './components/ApplicationViews';
import Login from './components/auth/Login';
import Register from './components/auth/Register';
import WeeklyPlanner from './components/weeklyplanner/WeeklyPlanner'; 

function App() {
  const [loggedInUser, setLoggedInUser] = useState(undefined);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const user = await tryGetLoggedInUser();
        setLoggedInUser(user);
      } catch (error) {
        console.error('Error fetching logged in user:', error);
        setLoggedInUser(null);
      }
    };
  
    fetchUser();
  }, []);

  // Wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      {loggedInUser ? (
        <>
          <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
          <ApplicationViews loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
        </>
      ) : (
        <Routes>
          <Route path="/login" element={<Login setLoggedInUser={setLoggedInUser} />} />
          <Route path="/register" element={<Register setLoggedInUser={setLoggedInUser} />} />
          <Route path="/" element={<Navigate to="/login" />} /> {/* Redirect to login */}
        </Routes>
      )}
    </>
  );
}

export default App;
