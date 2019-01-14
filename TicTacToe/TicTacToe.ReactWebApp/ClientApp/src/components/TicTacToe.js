import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/TicTacToe';
import './TicTacToe.css';

const TicTacToe = props => (
  <div>
    <h1>TicTacToe</h1>

    <p>This is a simple example of a TicTacToe game using React.</p>

    <table className='ticTacToeGameBoard'>
      <tbody>
        <tr>
          <td id='p1Btn' onClick={props.p1Btn_Click}>{props.p1Btn_Value}</td>
          <td id='p2Btn' onClick={props.p2Btn_Click}>{props.p2Btn_Value}</td>
          <td id='p3Btn' onClick={props.p3Btn_Click}>{props.p3Btn_Value}</td>
        </tr>
        <tr>
          <td id='p4Btn' onClick={props.p4Btn_Click}>{props.p4Btn_Value}</td>
          <td id='p5Btn' onClick={props.p5Btn_Click}>{props.p5Btn_Value}</td>
          <td id='p6Btn' onClick={props.p6Btn_Click}>{props.p6Btn_Value}</td>
        </tr>
        <tr>
          <td id='p7Btn' onClick={props.p7Btn_Click}>{props.p7Btn_Value}</td>
          <td id='p8Btn' onClick={props.p8Btn_Click}>{props.p8Btn_Value}</td>
          <td id='p9Btn' onClick={props.p9Btn_Click}>{props.p9Btn_Value}</td>
        </tr>
      </tbody>
    </table>
  </div>
);

export default connect(
  state => state.ticTacToe,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(TicTacToe);
