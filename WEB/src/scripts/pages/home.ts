import axios, { AxiosResponse } from 'axios';
import { Demo } from '../components/game';
import Phaser from 'phaser';

document.addEventListener('DOMContentLoaded', async () => {
    let labyrinth: AxiosResponse | undefined;

    try {
        labyrinth = await axios('/api/labyrinth');
    } catch (error) {
        console.log('Home page cannot connect to the API');
    }

    if (labyrinth) {
        console.log(labyrinth);
        console.log('Home page is ready');
    }

    const game = new Phaser.Game({
        type: Phaser.AUTO,
        width: 800,
        height: 600,
        physics: {
            default: 'arcade',
            arcade: {
                gravity: { y: 200 }
            }
        },
        scene: Demo
    });
});