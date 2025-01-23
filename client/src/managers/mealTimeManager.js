const apiUrl = "/api/mealtime";

export const getMealTimes = async () => {
  try {
    const response = await fetch(apiUrl, {
      credentials: "include", // Ensure cookies are sent with the request
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
      credentials: "include", // Ensure cookies are sent with the request
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

export const assignFoodsToMealTime = async (mealTimeId, foodIds) => {
  try {
    const response = await fetch(`${apiUrl}/assign`, {
      method: "POST",
      credentials: "include", // Ensure cookies are sent with the request
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ MealTimeId: mealTimeId, FoodIds: foodIds }),
    });
    if (!response.ok) {
      throw new Error("Failed to assign foods to mealtime");
    }
  } catch (error) {
    console.error("Error assigning foods to mealtime:", error);
    throw error;
  }
};