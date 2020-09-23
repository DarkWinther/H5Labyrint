import { Application } from "express";

export const home = (app: Application) => {
    app.get('/', (req, res) => {
        return res.render('pages/home', {
            page: 'home'
        });
    });
};

export const statistics = (app: Application) => {
    app.get('/statistics', (req, res) => {
        return res.render('pages/statistics', {
            page: 'statistics'
        });
    });
};