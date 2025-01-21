import React, { useEffect, useState } from "react";
import { Container, Row, Col, Card, CardBody, CardTitle, CardText, Button, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import { getDays, getDaysByUser } from "../../managers/dayManager";
import { getMealTimes, getMealTimesByUser, addFoodToMealTime, deleteFoodFromMealTime } from "../../managers/mealTimeManager";
import { getFoods, getUsersFoods } from "../../managers/foodManager";
import './WeeklyPlanner.css'; // Import custom CSS

export default function WeeklyPlanner({ loggedInUser }) {
  const [days, setDays] = useState([]);
  const [mealTimes, setMealTimes] = useState([]);
  const [foods, setFoods] = useState([]);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [selectedMealTime, setSelectedMealTime] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const daysData = await getDaysByUser();
        setDays(daysData);

        const mealTimesData = await getMealTimesByUser();
        setMealTimes(mealTimesData);

        const foodsData = await getUsersFoods();
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
      await addFoodToMealTime(selectedMealTime, foodId);
      const updatedMealTimes = await getMealTimesByUser();
      setMealTimes(updatedMealTimes);
      setDropdownOpen(false);
    } catch (error) {
      console.error("Error adding food to mealtime:", error);
    }
  };

  const handleDeleteFood = async (mealTimeId, foodId) => {
    try {
      await deleteFoodFromMealTime(mealTimeId, foodId);
      const updatedMealTimes = await getMealTimesByUser();
      setMealTimes(updatedMealTimes);
    } catch (error) {
      console.error("Error deleting food from mealtime:", error);
    }
  };

  return (
    <Container fluid>
      <h1>Welcome to the Weekly Planner</h1>
      {loggedInUser && <p>Hello, {loggedInUser.userName}, here's your weekly meals!</p>}
      {days.map((day) => (
        <Row key={day.id} className="mb-4">
          <Col>
            <Card>
              <CardBody>
                <Row>
                  <Col>
                    <CardTitle tag="h5" className="text-right day-name">{day.name}</CardTitle>
                  </Col>
                </Row>
                <Row>
                  {mealTimes
                    .filter(meal => meal.dayId === day.id)
                    .map((meal) => (
                      <Col key={meal.id} className="text-center">
                        <CardText>{meal.name}</CardText>
                        <Dropdown isOpen={dropdownOpen && selectedMealTime === meal.id} toggle={() => toggleDropdown(meal.id)}>
                          <DropdownToggle caret>
                            Select Food
                          </DropdownToggle>
                          <DropdownMenu>
                            {foods.map((food) => (
                              <DropdownItem key={food.id} onClick={() => handleAddFood(food.id)}>
                                {food.name}
                              </DropdownItem>
                            ))}
                          </DropdownMenu>
                        </Dropdown>
                        {meal.foods && meal.foods.length > 0 && (
                          <ul>
                            {meal.foods.map((food) => (
                              <li key={food.id}>
                                {food.name}
                                <Button color="danger" size="sm" onClick={() => handleDeleteFood(meal.id, food.id)}>Delete</Button>
                              </li>
                            ))}
                          </ul>
                        )}
                      </Col>
                    ))}
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>
      ))}
    </Container>
  );
}