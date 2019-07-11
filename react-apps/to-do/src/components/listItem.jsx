import React, { Component } from "react";

class ListItem extends Component {
  state = { message: this.props.message, id: this.props.id };

  render() {
    return (
      <div>
        <p>{this.state.message}</p>
        <button
          type="button"
          onClick={() => this.props.onDelete(this.state.id)}
        >
          Delete
        </button>
      </div>
    );
  }
}

export default ListItem;
