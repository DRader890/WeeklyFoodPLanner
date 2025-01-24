const _apiUrl = "/api/auth";

export async function login(credentials) {
  try {
    const response = await fetch('/api/auth/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(credentials),
    });

    if (!response.ok) {
      console.error(`Login failed with status: ${response.status}`);
      throw new Error('Login failed');
    }

    const user = await response.json();
    return user;
  } catch (error) {
    console.error('Error logging in:', error);
    throw error;
  }
}

export const logout = async () => {
  try {
    const response = await fetch(_apiUrl + "/logout", {
      method: "GET",
      credentials: "include" // Ensure cookies are sent with the request
    });

    if (!response.ok) {
      throw new Error('Logout failed');
    }

    localStorage.removeItem('token'); // Remove the token from local storage
  } catch (error) {
    console.error('Error logging out:', error);
    throw error;
  }
};

export const tryGetLoggedInUser = async () => {
  try {
    const response = await fetch(_apiUrl + "/me", {
      method: 'GET',
      credentials: "include" // Ensure cookies are sent with the request
    });

    if (!response.ok) {
      throw new Error('Failed to fetch user');
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Error fetching logged in user:', error);
    return null;
  }
};

export const register = async (user) => {
  try {
    const response = await fetch(`${_apiUrl}/register`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user),
      credentials: "include" // Ensure cookies are sent with the request
    });
    if (!response.ok) {
      throw new Error("Failed to register user");
    }
    return await response.json();
  } catch (error) {
    console.error("Error registering user:", error);
    throw error;
  }
};
