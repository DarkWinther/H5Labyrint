import { Application } from "express";
import axios, { AxiosError } from 'axios';

const API = 'http://localhost:51646/api';

export const apiLabyrinth = (app: Application) => {
    app.get('/api/labyrinth/random', async (req, res) => {
        try {
            const labyrinth = await axios(`${API}/labyrinth`);
            return res.json(labyrinth.data);
        } catch (error) {
            if (error.isAxiosError && (error as AxiosError).code === 'ECONNREFUSED') {
                return res.sendStatus(503);
            }

            if (typeof error.code === 'number') {
                return res.sendStatus(error.code);
            }

            return res.sendStatus(500);
        }
    });
};