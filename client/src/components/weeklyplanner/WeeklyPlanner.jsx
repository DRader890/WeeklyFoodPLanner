import React, { useEffect, useState } from "react";
import { Container, Row, Col, Card, CardBody, CardTitle, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import { getMealTimesByUser, assignFoodsToMealTime } from "../../managers/mealTimeManager";
import { getUsersFoods } from "../../managers/foodManager";
import './WeeklyPlanner.css'; // Import custom CSS

export default function WeeklyPlanner({ loggedInUser }) {
  const [mealTimes, setMealTimes] = useState([]);
  const [foods, setFoods] = useState([]);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [selectedMealTime, setSelectedMealTime] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const mealTimesData = await getMealTimesByUser();
        console.log("Meal Times Data:", mealTimesData); // Debugging
        setMealTimes(mealTimesData);

        const foodsData = await getUsersFoods();
        console.log("Foods Data:", foodsData); // Debugging
        setFoods(foodsData);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, [loggedInUser]); // Refetch data when loggedInUser changes

  const toggleDropdown = (mealTimeId) => {
    setSelectedMealTime(mealTimeId);
    setDropdownOpen(!dropdownOpen);
  };

  const handleAddFood = async (foodId) => {
    try {
      const mealTime = mealTimes.find(mt => mt.id === selectedMealTime);
      const updatedFoods = [...mealTime.meals.map(m => m.foodId), foodId];
      await assignFoodsToMealTime(selectedMealTime, updatedFoods);
      const updatedMealTimes = await getMealTimesByUser();
      setMealTimes(updatedMealTimes);
    } catch (error) {
      console.error("Error adding food:", error);
    }
  };

  const daysOfWeek = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

  // Group meal times by day
  const mealTimesByDay = daysOfWeek.map((day, index) => ({
    day,
    mealTimes: mealTimes.slice(index * 3, index * 3 + 3) // Assuming 3 meal times per day
  }));

  const getFoodNameById = (foodId) => {
    const food = foods.find(f => f.id === foodId);
    return food ? food.name : "Unknown Food";
  };

  return (
    <Container>
      {mealTimesByDay.map(({ day, mealTimes }, index) => (
        <Row key={index} className="mb-4">
          <Col>
            <Card>
              <CardBody>
                <CardTitle tag="h5">{day}</CardTitle>
                {mealTimes.map((mealTime, idx) => (
                  <div key={idx}>
                    <strong>{mealTime.name}</strong>
                    <ul>
                      {mealTime.meals.map((meal, mealIdx) => (
                        <li key={mealIdx}>{getFoodNameById(meal.foodId)}</li>
                      ))}
                    </ul>
                    <Dropdown isOpen={dropdownOpen && selectedMealTime === mealTime.id} toggle={() => toggleDropdown(mealTime.id)}>
                      <DropdownToggle caret>
                        Select Food
                      </DropdownToggle>
                      <DropdownMenu>
                        {foods.map(food => (
                          <DropdownItem key={food.id} onClick={() => handleAddFood(food.id)}>
                            {food.name}
                          </DropdownItem>
                        ))}
                      </DropdownMenu>
                    </Dropdown>
                  </div>
                ))}
              </CardBody>
            </Card>
          </Col>
        </Row>
      ))}
    </Container>
  );
}