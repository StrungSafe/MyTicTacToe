const initialState = { p1Btn_Value: '', p2Btn_Value: '', p3Btn_Value: '', p4Btn_Value: '', p5Btn_Value: '', p6Btn_Value: '', p7Btn_Value: '', p8Btn_Value: '', p9Btn_Value: '' };

export const actionCreators = {
    p1Btn_Click: () => ({ type: 'move', x: 0, y: 0 }),
    p2Btn_Click: () => ({ type: 'move', x: 1, y: 0 }),
    p3Btn_Click: () => ({ type: 'move', x: 2, y: 0 }),
    p4Btn_Click: () => ({ type: 'move', x: 0, y: 1 }),
    p5Btn_Click: () => ({ type: 'move', x: 1, y: 1 }),
    p6Btn_Click: () => ({ type: 'move', x: 2, y: 1 }),
    p7Btn_Click: () => ({ type: 'move', x: 0, y: 2 }),
    p8Btn_Click: () => ({ type: 'move', x: 1, y: 2 }),
    p9Btn_Click: () => ({ type: 'move', x: 2, y: 2 })
};

function makeMove(x, y) {
    alert('button clicked: ' + x + ', ' + y);
}

export const reducer = (state, action) => {
  state = state || initialState;

    if (action.type == 'move') {
        makeMove(action.x, action.y);
    return { ...state };
  }

  return state;
};
