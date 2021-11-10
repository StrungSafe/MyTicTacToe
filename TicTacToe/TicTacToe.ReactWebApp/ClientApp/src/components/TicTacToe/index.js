import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { actionCreators } from '../../store/TicTacToe';
import convertGameStatus from '../../util/convertGameStatus';

import GameBoard from './GameBoard';

import './TicTacToe.css';

const TicTacToe = props => (
  <div id='ticTacToeGame'>
    <h1>My TicTacToe Kata</h1>

    <p>This is a TicTacToe game that uses React for the front-end and dotnet for the back-end.</p>

    <GameBoard {...props} />

    {
        !props.makeMoveSuccess && (
          <p className='gameStatus'>Invalid Move <strong>Try Again</strong></p>
        )
    }

    <p className='gameStatus'>Game Status: <strong>{convertGameStatus(props.gameStatus)}</strong></p>

    <button className='newGameBtn' onClick={props.newGame}>New Game</button>

    {
        !props.newGameSuccess && (
          <p className='gameStatus'>Failed to Start New Game <strong>Try Again</strong></p>
        )
    }
  </div>
);

export default connect(
  state => state.ticTacToe,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(TicTacToe);
