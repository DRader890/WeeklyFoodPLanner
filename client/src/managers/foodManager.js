const apiUrl = "/api/food";

export const getFoods = async () => {
  try {
    const response = await fetch(apiUrl);
    if (!response.ok) {
      throw new Error("Failed to fetch foods");
    }
    return await response.json();
  } catch (error) {
    console.error("Error fetching foods:", error);
    throw error;
  }
};

export const getUsersFoods = async () => {
  try {
    const response = await fetch(apiUrl, {
      credentials: "same-origin",
    });
    if (!response.ok) {
      throw new Error("Failed to fetch user's foods");
    }
    return await response.json();
  } catch (error) {
    console.error("Error fetching user's foods:", error);
    throw error;
  }
};

export const updateFood = async (foodId, food) => {
  try {
    const response = await fetch(`${apiUrl}/${foodId}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(food),
    });
    if (!response.ok) {
      throw new Error("Failed to update food");
    }
  } catch (error) {
    console.error("Error updating food:", error);
    throw error;
  }
};

export const deleteFood = async (foodId) => {
  try {
    const response = await fetch(`${apiUrl}/${foodId}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Failed to delete food");
    }
  } catch (error) {
    console.error("Error deleting food:", error);
    throw error;
  }
};

export const addFood = async (food) => {
  try {
    const response = await fetch(apiUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(food),
    });
    if (!response.ok) {
      throw new Error("Failed to add food");
    }
  } catch (error) {
    console.error("Error adding food:", error);
    throw error;
  }
};