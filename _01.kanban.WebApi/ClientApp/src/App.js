import React, { Component, useEffect } from 'react';
import { BrowserRouter as Router, Switch, Route, Redirect } from 'react-router-dom';
import ptBR from 'antd/es/locale/pt_BR';
import { ConfigProvider } from 'antd';
import { isAuthenticated } from '../src/services/authorize';
import {
  Home,
  Login,
} from './pages';
import './custom.css'

const PrivateRoute = ({ Component, ...rest }) => (
  <Route
    {...rest}
    render={props =>
      isAuthenticated() ? (
        <Component {...props} />
      ) : (
        <Redirect to={{ pathname: "/", state: { from: props.location } }} />
      )
    }
  />
);

export default function App() {

  // useEffect(() => {
  //   window.process = {
  //     ...window.process,
  //   };
  // }, []);

  return (
    <ConfigProvider locale={ptBR} componentSize="middle">
      <Router>
        <Switch>
          <Route path='/' exact component={Login} />
          <PrivateRoute path="/home" component={Home} />
        </Switch>
      </Router>
    </ConfigProvider>
  );

}
