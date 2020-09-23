/// <binding AfterBuild='build' Clean='clean' ProjectOpened='watch' />
const { src, dest, series, parallel, watch } = require('gulp');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const rename = require('gulp-rename');
const del = require('del');
const uglify = require('gulp-uglify');
const browserify = require('browserify');
const source = require('vinyl-source-stream');
const buffer = require('vinyl-buffer');
const watchify = require('watchify');
const gulplog = require('gulplog');

const PAGES = ['home', 'statistics'];

// Cleaning
const cleanScss = () => {
    return del('dist/static/css/');
};

const cleanJs = () => {
    return del('dist/static/js');
}

const clean = parallel(cleanScss, cleanJs);

// Building
const styles = () => {
    return src('src/scss/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(cleanCss())
        .pipe(rename({ suffix: ".min" }))
        .pipe(dest('dist/static/css/'));
};

const scripts = cb => {
    PAGES.forEach(page => {
        browserify(`dist/scripts/pages/${page}.js`)
            .bundle()
            .pipe(source(`${page}.min.js`))
            .pipe(buffer())
            .pipe(uglify())
            .pipe(dest('dist/static/js/'));
    });
    cb();
}

const build = parallel(styles, scripts);

// Watching
const watchScss = cb => {
    watch('src/scss/**/*.scss', styles);
    cb();
}

const watchJs = cb => {
    PAGES.forEach(page => {
        const b = watchify(browserify({
            entries: `dist/scripts/pages/${page}.js`,
            cache: {},
            packageCache: {}
        }));

        const bundle = () => {
            b.bundle()
                .pipe(source(`${page}.min.js`))
                .pipe(buffer())
                .pipe(uglify())
                .pipe(dest('dist/static/js/'));
        };

        b.on('update', bundle);
        b.on('log', log => gulplog.info(`${log} for ${page} page`));
        bundle();
    });
    cb();
}

// Exporting
exports.clean = parallel(cleanScss, cleanJs);
exports.build = build;
exports.watch = series(watchScss, watchJs);
exports.default = series(clean, build);