import express from 'express';
import initRoutes from './routes';


const PORT = process.env.port || 3000;
const app = express();

// Pug
app.set('view engine', 'pug');
app.set('views', 'src/views');

app.use(express.json());
app.use(express.urlencoded({ extended: true }));
app.use(express.static('dist/static'));

initRoutes(app); // Initialize routes

app.listen(PORT, () => {
    console.log(`Server listening on port ${PORT}`);
});