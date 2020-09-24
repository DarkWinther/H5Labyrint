import axios, { AxiosResponse } from 'axios';
import Phaser from 'phaser';
import { LabyrinthScene } from '../scenes/labyrinthScene';
import { labyrinthData } from '../data';
import { Labyrinth, StatisticsDTO } from '../../models/labyrinth';

const onWin = async (statistics: StatisticsDTO) => {
    try {
        await axios('/api/statistics', {
            method: 'POST',
            data: statistics
        })
    } catch (error) {
        console.error("Couldn't send statistics");
    }
}

document.addEventListener('DOMContentLoaded', async () => {
    let labyrinth: AxiosResponse<Labyrinth> | undefined;

    try {
        labyrinth = await axios('/api/labyrinth/random');
    } catch (error) {
        console.log('Home page cannot connect to the API');
    }

    if (labyrinth) {
        labyrinthData.current = labyrinth.data;
        labyrinthData.onWin = onWin;

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