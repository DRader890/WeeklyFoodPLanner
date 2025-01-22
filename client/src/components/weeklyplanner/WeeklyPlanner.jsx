import React, { useEffect, useState } from "react";
import { Container, Row, Col, Card, CardBody, CardTitle, CardText, Button, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
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
      setDropdownOpen(false);
    } catch (error) {
      console.error("Error adding food to mealtime:", error);
    }
  };

  const handleDeleteFood = async (mealTimeId, foodId) => {
    try {
      const mealTime = mealTimes.find(mt => mt.id === mealTimeId);
      const updatedFoods = mealTime.meals.map(m => m.foodId).filter(id => id !== foodId);
      await assignFoodsToMealTime(mealTimeId, updatedFoods);
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
      <Row>
        {mealTimes.map((mealTime) => (
          <Col key={mealTime.id} sm="4">
            <Card>
              <CardBody>
                <CardTitle tag="h5">{mealTime.name}</CardTitle>
                <CardText>
                  {mealTime.meals.map((meal) => (
                    <div key={meal.id}>
                      {foods.find((food) => food.id === meal.foodId)?.name}
                      <Button
                        color="danger"
                        size="sm"
                        onClick={() => handleDeleteFood(mealTime.id, meal.foodId)}
                      >
                        Delete
                      </Button>
                    </div>
                  ))}
                </CardText>
                <Dropdown isOpen={dropdownOpen && selectedMealTime === mealTime.id} toggle={() => toggleDropdown(mealTime.id)}>
                  <DropdownToggle caret>Add Food</DropdownToggle>
                  <DropdownMenu>
                    {foods.map((food) => (
                      <DropdownItem key={food.id} onClick={() => handleAddFood(food.id)}>
                        {food.name}
                      </DropdownItem>
                    ))}
                  </DropdownMenu>
                </Dropdown>
              </CardBody>
            </Card>
          </Col>
        ))}
      </Row>
    </Container>
  );
}