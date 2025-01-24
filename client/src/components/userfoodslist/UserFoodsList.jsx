import React, { useEffect, useState } from 'react';
import { getUsersFoods, updateFood, deleteFood, addFood } from '../../managers/foodManager';
import { Button, Input, Modal, ModalHeader, ModalBody, ModalFooter, Container, Row, Col, ListGroup, ListGroupItem } from 'reactstrap';
import './UserFoodsList.css';

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
      const foods = await getUsersFoods();
      setUsersFoods(foods);
    };
    fetchData();
  }, []);

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
    <Container className="mt-5 container-full-width">
      <Row className="justify-content-center full-width">
        <Col md={8} className="center-content full-width">
          <h2>Your Foods</h2>
          <ListGroup className="full-width">
            {usersFoods.map((food) => (
              <ListGroupItem key={food.id} className="center-content full-width">
                {editingFoodId === food.id ? (
                  <div className="center-content full-width">
                    <Input
                      type="text"
                      value={editingFoodName}
                      onChange={(e) => setEditingFoodName(e.target.value)}
                      className="full-width"
                    />
                    <Input
                      type="text"
                      value={editingFoodDescription}
                      onChange={(e) => setEditingFoodDescription(e.target.value)}
                      className="full-width"
                    />
                    <div className="button-group">
                      <Button color="primary" size="sm" className="smaller-button" onClick={handleSaveClick}>Save</Button>
                      <Button color="secondary" size="sm" className="smaller-button" onClick={() => setEditingFoodId(null)}>Cancel</Button>
                    </div>
                  </div>
                ) : (
                  <div className="center-content full-width">
                    {food.name}
                    <div className="button-group">
                      <Button color="secondary" size="sm" className="smaller-button" onClick={() => handleEditClick(food)}>Edit</Button>
                      <Button color="danger" size="sm" className="smaller-button" onClick={() => handleDeleteClick(food.id)}>Delete</Button>
                    </div>
                  </div>
                )}
              </ListGroupItem>
            ))}
          </ListGroup>
          <Button color="primary" className="create-button" onClick={toggleModal}>Create Food</Button>
          <Modal isOpen={modal} toggle={toggleModal}>
            <ModalHeader toggle={toggleModal}>Create New Food</ModalHeader>
            <ModalBody>
              <Input
                type="text"
                placeholder="Food Name"
                value={newFoodName}
                onChange={(e) => setNewFoodName(e.target.value)}
                className="full-width"
              />
              <Input
                type="text"
                placeholder="Food Description"
                value={newFoodDescription}
                onChange={(e) => setNewFoodDescription(e.target.value)}
                className="full-width"
              />
            </ModalBody>
            <ModalFooter>
              <Button color="primary" onClick={handleCreateClick}>Create</Button>
              <Button color="secondary" onClick={toggleModal}>Cancel</Button>
            </ModalFooter>
          </Modal>
        </Col>
      </Row>
    </Container>
  );
}