import React, { Component } from "react";
import logo from "./logo.svg";
import "./App.css";
import InputBar from "./components/inputBar";
import NavBar from "./components/navBar";
import ToDoList from "./components/todoList";
import ListItem from "./components/listItem";

class App extends Component {
  state = { myList: [], currentId: 0 };

  handleEnter = value => {
    {
      const message = value;
      let newList = this.state.myList;
      newList.push({ message: message, id: this.state.currentId });
      let newId = (this.state.currentId += 1);
      this.setState({ currentId: newId });
      this.setState({ myList: newList });
    }
  };

  handleDelete = listId => {
    const listItems = this.state.myList.filter(
      oneItem => oneItem.id !== listId
    );
    this.setState({ myList: listItems });
  };
  render() {
    return (
      <div>
        <NavBar />
        <InputBar onEnter={this.handleEnter} />
        <ToDoList myList={this.state.myList} onDelete={this.handleDelete} />
      </div>
    );
  }
}

export default App;
