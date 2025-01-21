const apiUrl = "/api/day";

export const getDays = async () => {
  try {
    const response = await fetch(apiUrl);
    if (!response.ok) {
      throw new Error("Failed to fetch days");
    }
    return await response.json();
  } catch (error) {
    console.error("Error fetching days:", error);
    throw error;
  }
};

export const getDaysByUser = async () => {
  try {
    const response = await fetch(`${apiUrl}/user`, {
      credentials: "same-origin",
    });
    if (!response.ok) {
      throw new Error("Failed to fetch days by user");
    }
    return await response.json();
  } catch (error) {
    console.error("Error fetching days by user:", error);
    throw error;
  }
};

