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
    labyrinthId: string;
    traversal: Traversal,
    millisecondsSpent: number
}

const keepMe = {};