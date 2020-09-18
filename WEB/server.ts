import express from 'express';
import axios from 'axios';

const port = process.env.port || 3000;
const app = express();

app.get('/', async (req, res) => {
    const weather = await axios('http://localhost:51646/weatherforecast');
    console.log(weather);
    return res.send('Hello world!');
});

app.listen(port);