const initialState = {
    gameStatus: 'NewGameXMove',
    makeMoveSuccess: true,
    newGameSuccess: true,
    gameBoard: [
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0]
    ],
};

export const actionCreators = {
    makeMove: (row, column) => async dispatch => {
        const url = `api/TicTacToe/MakeMove?row=${row}&column=${column}`;
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    newGame: () => async dispatch => {
        const url = 'api/TicTacToe/NewGame';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'newGame', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === 'newGame') {
        return {
            ...state,
            newGameSuccess: action.success,
            makeMoveSuccess: true,
            gameStatus: action.gameStatus,
            gameBoard: action.gameBoard,
        }
    }

    if (action.type === 'makeMove') {
        return {
            ...state,
            makeMoveSuccess: action.success,
            gameStatus: action.gameStatus,
            gameBoard: action.gameBoard,
        }
    }

    return state;
};