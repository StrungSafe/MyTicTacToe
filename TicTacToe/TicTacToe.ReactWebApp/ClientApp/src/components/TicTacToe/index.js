import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { actionCreators } from '../../store/TicTacToe';

import GameBoard from './GameBoard';

import './TicTacToe.css';

const TicTacToe = props => (
  <div id='ticTacToeGame'>
    <h1>My TicTacToe Kata</h1>

    <p>This is a TicTacToe game that uses React for the front-end and dotnet for the back-end.</p>

    <GameBoard {...props} />

    <p className='gameStatus'>Game Status: <strong>{props.gameStatus}</strong></p>

    <button className='newGameBtn' onClick={props.newGame}>New Game</button>
  </div>
);

export default connect(
  state => state.ticTacToe,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(TicTacToe);
