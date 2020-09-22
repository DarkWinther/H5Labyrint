import express from 'express';

const port = process.env.port || 3000;
const app = express();

// Pug
app.set('view engine', 'pug');
app.set('views', 'src/views');

app.use(express.static('dist/static'));

app.get('/', async (req, res) => {
    return res.render('pages/home');
});

app.listen(port, () => {
    console.log(`Server listening on port ${port}`);
});