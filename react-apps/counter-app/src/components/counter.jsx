import React, { Component } from "react";

class Counter extends Component {
  render() {
    return (
      <div>
        <span className={this.chooseType()}>{this.formatValue()}</span>
        <button
          onClick={() => this.props.onIncrement(this.props.counter)}
          className="btn btn-outline-primary"
        >
          Primary
        </button>
        <button
          onClick={() => this.props.onDelete(this.props.counter.id)}
          className="btn btn-danger btn-sm m-2"
        >
          Delete
        </button>
      </div>
    );
  }

  formatValue() {
    const value = this.props.counter.value;
    return value === 0 ? <h1>Zero</h1> : value;
  }

  chooseType() {
    let classes = "badge m-2 badge-";
    return (classes += this.props.counter.value === 0 ? "warning" : "primary");
  }
}

export default Counter;
