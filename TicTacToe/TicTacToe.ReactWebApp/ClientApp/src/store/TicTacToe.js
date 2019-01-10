const initialState = { p1Btn_Value: '', p2Btn_Value: '', p3Btn_Value: '', p4Btn_Value: '', p5Btn_Value: '', p6Btn_Value: '', p7Btn_Value: '', p8Btn_Value: '', p9Btn_Value: '' };

export const actionCreators = {
    p1Btn_Click: () => ({ type: 'test' }),
    p2Btn_Click: () => ({}),
    p3Btn_Click: () => ({}),
    p4Btn_Click: () => ({}),
    p5Btn_Click: () => ({}),
    p6Btn_Click: () => ({}),
    p7Btn_Click: () => ({}),
    p8Btn_Click: () => ({}),
    p9Btn_Click: () => ({})
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type == 'test') {
    return { ...state, p1Btn_Value: 'test' };
  }

  return state;
};
