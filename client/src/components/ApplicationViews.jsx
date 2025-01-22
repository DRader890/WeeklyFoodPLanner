import { Route, Routes } from "react-router-dom";
import Login from "./auth/Login";
import Register from "./auth/Register";
import UserFoodsList from "./userfoodslist/UserFoodsList";
import WeeklyPlanner from "./weeklyplanner/WeeklyPlanner";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/" element={<WeeklyPlanner loggedInUser={loggedInUser} />} />
      <Route path="/foods" element={<UserFoodsList loggedInUser={loggedInUser} />} />
      <Route path="/login" element={<Login setLoggedInUser={setLoggedInUser} />} />
      <Route path="/register" element={<Register setLoggedInUser={setLoggedInUser} />} />
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}