export default function convertGameBoardMark(value) {
    if (value === 0) {
        return '';
    }

    if (value === 1) {
        return 'X';
    }

    return 'O';
}