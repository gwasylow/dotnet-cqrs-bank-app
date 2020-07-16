import React, { Component } from 'react';
import { Input } from 'semantic-ui-react'




export class Login extends Component {

  handleLoginClick()
  {
    this.props.history.push('/home');
  }

  render() {
    return (
      <div>
        <h1>Login form</h1>
        <p>
          <Input placeholder='Login' value='grazynka' />
        </p>
        <p>
          <Input placeholder='Password' value='demo' />
        </p>
        <p>
          <button className="btn btn-primary" onClick={() => this.handleLoginClick()}>Login</button>
        </p>
      </div>
    );
  }
}
