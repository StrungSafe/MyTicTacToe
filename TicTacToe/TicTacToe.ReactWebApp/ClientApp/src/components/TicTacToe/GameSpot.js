import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { actionCreators } from '../../store/TicTacToe';
import convertGameBoardMark from '../../util/convertGameBoardMark';

const GameSpot = ({ id, row, column, gameBoard, makeMove }) => (
    <td id={id} onClick={() => makeMove(row, column)}>{convertGameBoardMark(gameBoard[row][column])}</td>
);

export default connect(
    state => state.ticTacToe,
    dispatch => bindActionCreators(actionCreators, dispatch),
)(GameSpot);