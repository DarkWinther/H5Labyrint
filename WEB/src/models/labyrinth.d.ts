export const enum LabyrinthTile {
    Empty,
    Wall,
    Start,
    Goal
};

export interface Labyrinth {
    id: string;
    category: string;
    labyrinthName: string;
    labyrinthSpaces: LabyrinthTile[][];
};

export type Traversal = number[][];

export interface StatisticsDTO {
    labyrinths_id: string;
    traversal: Traversal,
    millisecondsSpent: number
}

const keepMe = {};