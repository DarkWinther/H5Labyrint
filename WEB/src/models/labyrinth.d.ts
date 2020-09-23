export const enum LabyrinthTile {
    Empty,
    Wall,
    Start,
    Goal
};

export interface Labyrinth {
    category: string;
    id: string;
    labyrinthName: string;
    labyrinthSpaces: LabyrinthTile[][];
};

const keepMe = {};