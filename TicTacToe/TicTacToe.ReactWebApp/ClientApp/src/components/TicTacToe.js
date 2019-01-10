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
          <td><button id='p1Btn' onClick={props.p1Btn_Click}>{props.p1Btn_Value}</button></td>
          <td><button id='p2Btn' onClick={props.p2Btn_Click}>{props.p2Btn_Value}</button></td>
          <td><button id='p3Btn' onClick={props.p3Btn_Click}>{props.p3Btn_Value}</button></td>
        </tr>
        <tr class='row'>
          <td><button id='p4Btn' onClick={props.p4Btn_Click}>{props.p4Btn_Value}</button></td>
          <td><button id='p5Btn' onClick={props.p5Btn_Click}>{props.p5Btn_Value}</button></td>
          <td><button id='p6Btn' onClick={props.p6Btn_Click}>{props.p6Btn_Value}</button></td>
        </tr>
        <tr class='row'>
          <td><button id='p7Btn' onClick={props.p7Btn_Click}>{props.p7Btn_Value}</button></td>
          <td><button id='p8Btn' onClick={props.p8Btn_Click}>{props.p8Btn_Value}</button></td>
          <td><button id='p9Btn' onClick={props.p9Btn_Click}>{props.p9Btn_Value}</button></td>
        </tr>
      </tbody>
    </table>
  </div>
);

export default connect(
  state => state.tictactoe,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(TicTacToe);
