import axios, { AxiosResponse } from 'axios';
import Phaser from 'phaser';
import { LabyrinthScene } from '../components/labyrinthScene';
import { labyrinthData } from '../data';
import { Labyrinth } from '../../models/labyrinth';

document.addEventListener('DOMContentLoaded', async () => {
    let labyrinth: AxiosResponse<Labyrinth> | undefined;

    try {
        labyrinth = await axios('/api/labyrinth/random');
    } catch (error) {
        console.log('Home page cannot connect to the API');
    }

    if (labyrinth) {
        labyrinthData.current = labyrinth.data;
        const width = labyrinth.data.labyrinthSpaces.length * 32;
        const height = labyrinth.data.labyrinthSpaces[0].length * 32;
        new Phaser.Game({
            type: Phaser.AUTO,
            width,
            height,
            parent: 'labyrinth',
            scene: LabyrinthScene,
            backgroundColor: '#FFFFFF'
        });
    }
});