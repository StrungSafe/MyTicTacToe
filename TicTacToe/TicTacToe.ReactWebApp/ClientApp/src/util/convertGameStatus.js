export default function convertGameStatus(value) {
    if (value === 'NewGameXMove') {
        return 'Ready, X Starts First';
    }

    if(value === 'OMove') {
        return "O Player's Turn";
    }

    if(value === 'XMove') {
        return "X Player's Turn";
    }

    if(value === 'OWinner') {
        return "O Player Defeated X Player";
    }

    if(value === 'XWinner') {
        return "X Player Defeated O Player";
    }

    return value;
}