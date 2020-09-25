import Doolhof from 'doolhof';
import axios from 'axios';

const generator = async () => {
    let width;
    let height;
    let count;

    process.argv.forEach(arg => {
        if (arg.substr(0, 8) === '--width=') {
            width = parseInt(arg.substring(8).trim());
        }

        if (arg.substr(0, 9) === '--height=') {
            height = parseInt(arg.substring(9).trim());
        }

        if (arg.substr(0, 8) === '--count=') {
            count = parseInt(arg.substring(8).trim());
        }
    });

    const promises = [];

    for (let i = 0; i < (count || 1); i++) {
        const maze = new Doolhof({
            col: (width && !isNaN(width) && width) || 10,
            row: (height && !isNaN(height) && height) || 10
        });

        maze.generate();
        const { start, end } = maze.get().meta;
        const labyrinth = maze.get().raw.map(row => row.map(space => space ? 0 : 1));
        labyrinth[start[0]][start[1]] = 2;
        labyrinth[end[0]][end[1]] = 3;

        promises.push(
            axios('http://localhost:51646/api/labyrinth', {
                method: 'POST',
                data: {
                    LabyrinthName: `Doolhof-${i}`,
                    Category: 'Random',
                    LabyrinthSpaces: labyrinth
                }
            })
        );
    }

    await Promise.all(promises);
};

generator();