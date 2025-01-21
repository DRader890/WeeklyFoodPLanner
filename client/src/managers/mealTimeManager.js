const apiUrl = "/api/mealtime";

export const getMealTimes = async () => {
  try {
    const response = await fetch(apiUrl, {
      credentials: "same-origin",
    });
    if (!response.ok) {
      throw new Error("Failed to fetch meal times");
    }
    return await response.json();
  } catch (error) {
    console.error("Error fetching meal times:", error);
    throw error;
  }
};

export const getMealTimesByUser = async () => {
  try {
    const response = await fetch(`${apiUrl}/user`, {
      credentials: "same-origin",
    });
    if (!response.ok) {
      throw new Error("Failed to fetch meal times by user");
    }
    return await response.json();
  } catch (error) {
    console.error("Error fetching meal times by user:", error);
    throw error;
  }
};

export const addFoodToMealTime = async (mealTimeId, foodId) => {
  try {
    const response = await fetch(`${apiUrl}/${mealTimeId}/foods/${foodId}`, {
      method: "POST",
      credentials: "same-origin",
    });
    if (!response.ok) {
      throw new Error("Failed to add food to mealtime");
    }
  } catch (error) {
    console.error("Error adding food to mealtime:", error);
    throw error;
  }
};

export const deleteFoodFromMealTime = async (mealTimeId, foodId) => {
  try {
    const response = await fetch(`${apiUrl}/${mealTimeId}/foods/${foodId}`, {
      method: "DELETE",
      credentials: "same-origin",
    });
    if (!response.ok) {
      throw new Error("Failed to delete food from mealtime");
    }
  } catch (error) {
    console.error("Error deleting food from mealtime:", error);
    throw error;
  }
};