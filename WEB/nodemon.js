const nodemon = require('nodemon');

nodemon({
    ignore: [
        'node_modules/**/node_modules',
        '.git',
        'dist/**/*',
        'obj/**/*',
        'bin/**/*'
    ],
    delay: 1500,
    env: { NODE_ENV: 'development' },
    ext: "ts, json",
    exec: "npm run build && node dist/server.js"
});