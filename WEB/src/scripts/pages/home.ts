import axios from 'axios';

document.addEventListener('DOMContentLoaded', async () => {
    const labyrinth = await axios('/api/labyrinth');
    console.log(labyrinth && labyrinth.data);
    console.log('Home page is ready');
});