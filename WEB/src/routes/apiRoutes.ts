import { Application } from "express";
import axios from 'axios';

const api = 'http://localhost:51646/api';

export const apiLabyrinth = (app: Application) => {
    app.get('/api/labyrinth', async (req, res) => {
        const labyrinth = await axios(`${api}/labyrinth`);
        return res.json(labyrinth.data);
    });
};