import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;


  
  constructor(props) {
    super(props);
    this.state = { testApiResult: [], loading: true };
  }

  componentDidMount()
  {
    // this.testApi();
    
  }

  render () {
    return (
      <div>
        {/* <h1>{this.state.testApiResult}</h1> */}
        <h1>CQRS Bank Demo App</h1>
      </div>
    );
  }


  // async testApi() 
  // {
  //    await fetch('https://localhost:5001/auth/IsAlive')
  //    .then(res => res.json())
  //    .then((data) => 
  //    {
  //      this.setState({ testApiResult: data, loading: false });
  //    })
  //    .catch(console.error)
  // }
  
}
