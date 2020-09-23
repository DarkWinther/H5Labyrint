import Phaser from 'phaser';
import { labyrinthData } from '../data';
import { LabyrinthTile } from '../../models/labyrinth';

export class LabyrinthScene extends Phaser.Scene {
    constructor() {
        super('Labyrinth');
    }

    public create = () => {
        if (labyrinthData.current?.labyrinthSpaces) {
            const graphics = this.add.graphics();
            const spaces = labyrinthData.current.labyrinthSpaces;
            for (let i = 0; i < spaces.length; i++) {
                for (let j = 0; j < spaces[i].length; j++) {
                    switch (spaces[i][j]) {
                        case LabyrinthTile.Wall:
                            graphics.fillStyle(0x222222);
                            graphics.fillRect(32 * j, 32 * i, 32, 32);
                            break;
                        case LabyrinthTile.Start:
                            graphics.fillStyle(0x00FF00);
                            graphics.fillRect(32 * j, 32 * i, 32, 32);
                            break;
                        case LabyrinthTile.Goal:
                            graphics.fillStyle(0xFF0000);
                            graphics.fillRect(32 * j, 32 * i, 32, 32);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}