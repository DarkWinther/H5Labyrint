import { Application } from "express";
import axios from 'axios';

const API = 'http://localhost:51646/api';

export const apiLabyrinth = (app: Application) => {
    app.get('/api/labyrinth/random', async (req, res) => {
        try {
            const labyrinth = await axios(`${API}/labyrinth`);
            return res.json(labyrinth.data);
        } catch (error) {
            return res.sendStatus(503);
        }
    });
};