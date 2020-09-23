import { Application } from "express";
import axios, { AxiosError } from 'axios';

const API = 'http://localhost:51646/api';

export const apiLabyrinth = (app: Application) => {
    app.get('/api/labyrinth', async (req, res) => {
        try {
            const labyrinth = await axios(`${API}/labyrinth`);
            return res.json(labyrinth.data);
        } catch (error) {
            console.log(error);
            if (error.isAxiosError) {
                const err = error as AxiosError;
                return res.status(500).json({
                    code: err.code,
                    stack: err.stack,
                    message: err.message
                });
            }

            return res.sendStatus(500);
        }
    });
};