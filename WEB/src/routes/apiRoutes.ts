import { Application } from "express";
import axios, { AxiosError } from 'axios';

const API = 'http://localhost:51646/api';
const ECONNREFUSED = 'ECONNREFUSED';

const handleError = (error: any): number => {
    if (error.isAxiosError) {
        const err = error as AxiosError;

        if (err.code === ECONNREFUSED) {
            return 503;
        }

        if (typeof err.code === 'number') {
            return err.code;
        }
    }
    return 500;
}

export const apiLabyrinth = (app: Application) => {
    app.get('/api/labyrinth/random', async (req, res) => {
        try {
            const labyrinth = await axios(`${API}/labyrinth`);
            return res.json(labyrinth.data);
        } catch (error) {
            return res.sendStatus(handleError(error));
        }
    });

    app.post('/api/statistics', async (req, res) => {
        try {
            const postResult = await axios(`${API}/statistic`, {
                method: 'POST',
                data: req.body
            });
            return res.sendStatus(postResult.status);
        } catch (error) {
            return res.sendStatus(handleError(error));
        }
    });
};