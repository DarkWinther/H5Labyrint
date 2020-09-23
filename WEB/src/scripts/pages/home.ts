import axios, { AxiosError } from 'axios';

document.addEventListener('DOMContentLoaded', async () => {
    try {
        const labyrinth = await axios('/api/labyrinth');
        console.log(labyrinth);
        console.log('Home page is ready');
    } catch (error) {
        console.log('Home page cannot connect to API');
    }
});