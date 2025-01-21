import React, { useEffect, useState } from 'react';
import { getUsersFoods, updateFood, deleteFood, addFood } from '../../managers/foodManager';
import { Button, Input, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export default function UserFoodsList({ loggedInUser }) {
  const [usersFoods, setUsersFoods] = useState([]);
  const [editingFoodId, setEditingFoodId] = useState(null);
  const [editingFoodName, setEditingFoodName] = useState('');
  const [editingFoodDescription, setEditingFoodDescription] = useState('');
  const [newFoodName, setNewFoodName] = useState('');
  const [newFoodDescription, setNewFoodDescription] = useState('');
  const [modal, setModal] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const usersFoodsData = await getUsersFoods();
        setUsersFoods(usersFoodsData);
      } catch (error) {
        console.error("Error fetching user's foods:", error);
      }
    };

    fetchData();
  }, [loggedInUser]); // Refetch data when loggedInUser changes

  const toggleModal = () => setModal(!modal);

  const handleEditClick = (food) => {
    setEditingFoodId(food.id);
    setEditingFoodName(food.name);
    setEditingFoodDescription(food.description);
  };

  const handleSaveClick = async () => {
    try {
      await updateFood(editingFoodId, { name: editingFoodName, description: editingFoodDescription });
      const updatedFoods = await getUsersFoods();
      setUsersFoods(updatedFoods);
      setEditingFoodId(null);
      setEditingFoodName('');
      setEditingFoodDescription('');
    } catch (error) {
      console.error("Error updating food:", error);
    }
  };

  const handleDeleteClick = async (foodId) => {
    try {
      await deleteFood(foodId);
      const updatedFoods = await getUsersFoods();
      setUsersFoods(updatedFoods);
    } catch (error) {
      console.error("Error deleting food:", error);
    }
  };

  const handleCreateClick = async () => {
    try {
      await addFood({ name: newFoodName, description: newFoodDescription });
      const updatedFoods = await getUsersFoods();
      setUsersFoods(updatedFoods);
      setNewFoodName('');
      setNewFoodDescription('');
      toggleModal();
    } catch (error) {
      console.error("Error creating food:", error);
    }
  };

  return (
    <div>
      <h2>User's Foods</h2>
      <ul>
        {usersFoods.map((food) => (
          <li key={food.id}>
            {editingFoodId === food.id ? (
              <div>
                <Input
                  type="text"
                  value={editingFoodName}
                  onChange={(e) => setEditingFoodName(e.target.value)}
                />
                <Input
                  type="text"
                  value={editingFoodDescription}
                  onChange={(e) => setEditingFoodDescription(e.target.value)}
                />
                <Button color="primary" size="sm" onClick={handleSaveClick}>Save</Button>
                <Button color="secondary" size="sm" onClick={() => setEditingFoodId(null)}>Cancel</Button>
              </div>
            ) : (
              <div>
                {food.name}
                <Button color="secondary" size="sm" onClick={() => handleEditClick(food)}>Edit</Button>
                <Button color="danger" size="sm" onClick={() => handleDeleteClick(food.id)}>Delete</Button>
              </div>
            )}
          </li>
        ))}
      </ul>
      <Button color="primary" className="create-button" onClick={toggleModal}>Create Food</Button>
      <Modal isOpen={modal} toggle={toggleModal}>
        <ModalHeader toggle={toggleModal}>Create New Food</ModalHeader>
        <ModalBody>
          <Input
            type="text"
            placeholder="Food Name"
            value={newFoodName}
            onChange={(e) => setNewFoodName(e.target.value)}
          />
          <Input
            type="text"
            placeholder="Food Description"
            value={newFoodDescription}
            onChange={(e) => setNewFoodDescription(e.target.value)}
          />
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={handleCreateClick}>Create</Button>
          <Button color="secondary" onClick={toggleModal}>Cancel</Button>
        </ModalFooter>
      </Modal>
      <style>
        {`
          .create-button {
            position: fixed;
            bottom: 20px;
            right: 20px;
          }
        `}
      </style>
    </div>
  );
}