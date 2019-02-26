const initialState = { gameStatus: 'Starting', p1Btn_Value: '', p2Btn_Value: '', p3Btn_Value: '', p4Btn_Value: '', p5Btn_Value: '', p6Btn_Value: '', p7Btn_Value: '', p8Btn_Value: '', p9Btn_Value: '' };

export const actionCreators = {
    p1Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=0&column=0';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    p2Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=0&column=1';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    p3Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=0&column=2';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    p4Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=1&column=0';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    p5Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=1&column=1';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    p6Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=1&column=2';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    p7Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=2&column=0';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    p8Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=2&column=1';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },
    p9Btn_Click: () => async (dispatch, getState) => {
        const url = 'api/TicTacToe/MakeMove?row=2&column=2';
        var data;
        await fetch(url).then(response => response.json()).then(results => { data = results; });

        dispatch({ type: 'makeMove', success: data.success, gameStatus: data.gameState, gameBoard: data.gameBoard });
    },

    newGameBtn_Click: () => async (dispatch, getState) => {
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
            gameStatus: action.gameStatus,
            p1Btn_Value: convertGameBoardMark(action.gameBoard[0][0]),
            p2Btn_Value: convertGameBoardMark(action.gameBoard[0][1]),
            p3Btn_Value: convertGameBoardMark(action.gameBoard[0][2]),
            p4Btn_Value: convertGameBoardMark(action.gameBoard[1][0]),
            p5Btn_Value: convertGameBoardMark(action.gameBoard[1][1]),
            p6Btn_Value: convertGameBoardMark(action.gameBoard[1][2]),
            p7Btn_Value: convertGameBoardMark(action.gameBoard[2][0]),
            p8Btn_Value: convertGameBoardMark(action.gameBoard[2][1]),
            p9Btn_Value: convertGameBoardMark(action.gameBoard[2][2])
        }
    }

    if (action.type === 'makeMove') {
        return {
            ...state,
            gameStatus: action.gameStatus,
            p1Btn_Value: convertGameBoardMark(action.gameBoard[0][0]),
            p2Btn_Value: convertGameBoardMark(action.gameBoard[0][1]),
            p3Btn_Value: convertGameBoardMark(action.gameBoard[0][2]),
            p4Btn_Value: convertGameBoardMark(action.gameBoard[1][0]),
            p5Btn_Value: convertGameBoardMark(action.gameBoard[1][1]),
            p6Btn_Value: convertGameBoardMark(action.gameBoard[1][2]),
            p7Btn_Value: convertGameBoardMark(action.gameBoard[2][0]),
            p8Btn_Value: convertGameBoardMark(action.gameBoard[2][1]),
            p9Btn_Value: convertGameBoardMark(action.gameBoard[2][2])
        }
    }
    
    return state;
};

function convertGameBoardMark(value) {
    if (value === 0) {
        return '';
    }

    if (value === 1) {
        return 'X';
    }

    return 'O';
}