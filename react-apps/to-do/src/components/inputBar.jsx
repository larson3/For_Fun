import React, { Component } from "react";

class InputBar extends Component {
  state = {
    value: ""
  };
  handleChange = event => {
    const { id } = this.props;
    const value = event.target.value;
    this.setState({ value, error: "" });
  };

  submitItem = event => {
    event.preventDefault();
    let newItem = this.state.value;
    this.props.onEnter(newItem);
    console.log("new");
  };
  render() {
    return (
      <form>
        <div className="form-group">
          <label htmlFor="newID">New Item</label>
          <input
            className="form-control"
            id="newID"
            placeholder="Enter item to do"
            onChange={this.handleChange}
          />
          <button type="button" onClick={this.submitItem}>
            Enter
          </button>
        </div>
      </form>
    );
  }
}

export default InputBar;
