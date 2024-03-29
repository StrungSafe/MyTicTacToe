﻿import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import TicTacToe from './components/TicTacToe';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/tictactoe' component={TicTacToe} />
  </Layout>
);
