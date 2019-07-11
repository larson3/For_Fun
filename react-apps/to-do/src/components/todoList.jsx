import React, { Component } from "react";
import ListItem from "./listItem.jsx";

class ToDoList extends Component {
  state = {};

  render() {
    return (
      <div>
        {
          <ul>
            {this.props.myList.map(message => {
              return (
                <li key={message.id}>
                  {
                    <ListItem
                      message={message.message}
                      id={message.id}
                      onDelete={this.props.onDelete}
                    />
                  }
                </li>
              );
            })}
          </ul>
        }
      </div>
    );
  }
}

export default ToDoList;
