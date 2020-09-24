import { Labyrinth, StatisticsDTO } from "../models/labyrinth";

interface LabyrinthData {
    current?: Labyrinth;
    onWin?: (statistics: StatisticsDTO) => void;
}

export const labyrinthData: LabyrinthData = {};