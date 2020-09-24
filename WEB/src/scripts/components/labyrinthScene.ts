import Phaser from 'phaser';
import { labyrinthData } from '../data';
import { LabyrinthTile } from '../../models/labyrinth';

const FIELD_SIZE = 32;

export class LabyrinthScene extends Phaser.Scene {
    constructor() {
        super('Labyrinth');
    }

    public create = () => {
        if (labyrinthData.current?.labyrinthSpaces) {
            // Graphhics (Walls, start, goal)
            const graphics = this.add.graphics();
            const spaces = labyrinthData.current.labyrinthSpaces;

            for (let i = 0; i < spaces.length; i++) {
                for (let j = 0; j < spaces[i].length; j++) {
                    switch (spaces[i][j]) {
                        case LabyrinthTile.Wall:
                            graphics.fillStyle(0x222222);
                            graphics.fillRect(FIELD_SIZE * j, FIELD_SIZE * i, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case LabyrinthTile.Start:
                            graphics.fillStyle(0x00FF00);
                            graphics.fillRect(FIELD_SIZE * j, FIELD_SIZE * i, FIELD_SIZE, FIELD_SIZE);
                            break;
                        case LabyrinthTile.Goal:
                            graphics.fillStyle(0xFF0000);
                            graphics.fillRect(FIELD_SIZE * j, FIELD_SIZE * i, FIELD_SIZE, FIELD_SIZE);
                            break;
                        default:
                            break;
                    }
                }
            }


            // Player
            const player = this.add.graphics();
            const startSpace = spaces.reduce((obj, current, index) => {
                const startIndex = current.findIndex(space => space === LabyrinthTile.Start)
                if (startIndex > -1) {
                    obj.y = index;
                    obj.x = startIndex;
                }
                return obj;
            }, { x: 0, y: 0 });

            player.x = startSpace.x * FIELD_SIZE;
            player.y = startSpace.y * FIELD_SIZE;

            player.fillStyle(0xffd500);
            player.fillCircle(16, 16, 12);

            // Controls
            const goDown = (event: KeyboardEvent) => {
                const x = player.x / FIELD_SIZE;
                const y = player.y / FIELD_SIZE;

                if (y + 1 < spaces.length) {
                    const tile = spaces[y + 1][x];

                    if (typeof tile === 'number' && tile !== LabyrinthTile.Wall) {
                        player.y += FIELD_SIZE;
                    }
                }
            };

            const goUp = (event: KeyboardEvent) => {
                const x = player.x / FIELD_SIZE;
                const y = player.y / FIELD_SIZE;


                if (y - 1 >= 0) {
                    const tile = spaces[y - 1][x];

                    if (typeof tile === 'number' && tile !== LabyrinthTile.Wall) {
                        player.y -= FIELD_SIZE;
                    }
                }
            };

            const goLeft = (event: KeyboardEvent) => {
                const x = player.x / FIELD_SIZE;
                const y = player.y / FIELD_SIZE;
                const tile = spaces[y][x - 1];

                if (typeof tile === 'number' && tile !== LabyrinthTile.Wall) {
                    player.x -= FIELD_SIZE;
                }
            };

            const goRight = (event: KeyboardEvent) => {
                const x = player.x / FIELD_SIZE;
                const y = player.y / FIELD_SIZE;
                const tile = spaces[y][x + 1];

                if (typeof tile === 'number' && tile !== LabyrinthTile.Wall) {
                    player.x += FIELD_SIZE;
                }
            };

            interface WASD {
                W: Phaser.Input.Keyboard.Key,
                A: Phaser.Input.Keyboard.Key,
                S: Phaser.Input.Keyboard.Key,
                D: Phaser.Input.Keyboard.Key,
                UP: Phaser.Input.Keyboard.Key,
                DOWN: Phaser.Input.Keyboard.Key,
                LEFT: Phaser.Input.Keyboard.Key,
                RIGHT: Phaser.Input.Keyboard.Key
            }

            const wasd = this.input.keyboard.addKeys('W,A,S,D,UP,DOWN,LEFT,RIGHT') as WASD;

            wasd.W.on('down', goUp);
            wasd.A.on('down', goLeft);
            wasd.S.on('down', goDown);
            wasd.D.on('down', goRight);
            wasd.UP.on('down', goUp);
            wasd.DOWN.on('down', goDown);
            wasd.LEFT.on('down', goLeft);
            wasd.RIGHT.on('down', goRight);
        }
    }
}