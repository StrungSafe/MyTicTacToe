import React from 'react';

import GameSpot from './GameSpot';

const GameBoard = () => (
    <table className='ticTacToeGameBoard'>
        <tbody>
            <tr>
                <GameSpot id={1} row={0} column={0} />
                <GameSpot id={2} row={0} column={1} />
                <GameSpot id={3} row={0} column={2} />
            </tr>
            <tr>
                <GameSpot id={4} row={1} column={0} />
                <GameSpot id={5} row={1} column={1} />
                <GameSpot id={6} row={1} column={2} />
            </tr>
            <tr>
                <GameSpot id={7} row={2} column={0} />
                <GameSpot id={8} row={2} column={1} />
                <GameSpot id={9} row={2} column={2} />
            </tr>
        </tbody>
    </table>
);

export default GameBoard;