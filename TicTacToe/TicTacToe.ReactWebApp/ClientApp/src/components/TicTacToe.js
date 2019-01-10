import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/TicTacToe';
import './TicTacToe.css';

const TicTacToe = props => (
  <div>
    <h1>TicTacToe</h1>

    <p>This is a simple example of a TicTacToe game using React.</p>

    <table class='table'>
      <tbody>
        <tr class='row'>
          <td><button></button></td>
          <td><button></button></td>
          <td><button></button></td>
        </tr>
        <tr class='row'>
          <td><button></button></td>
          <td><button></button></td>
          <td><button></button></td>
        </tr>
        <tr class='row'>
          <td><button></button></td>
          <td><button></button></td>
          <td><button></button></td>
        </tr>
      </tbody>
    </table>
  </div>
);

export default connect(
  state => state.tictactoe,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(TicTacToe);
