import { Application } from "express";
import { home, statistics } from "./routes";
import { apiLabyrinth } from './apiRoutes';


export default (app: Application) => {
    // Page Routes
    home(app);
    statistics(app);

    // Api Routes
    apiLabyrinth(app);
}