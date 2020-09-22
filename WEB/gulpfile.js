/// <binding AfterBuild='default' Clean='clean' ProjectOpened='watch' />
const { src, dest, series, parallel, watch } = require('gulp');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const rename = require('gulp-rename');
const del = require('del');
const uglify = require('gulp-uglify');
const browserify = require('browserify');
const source = require('vinyl-source-stream');
const buffer = require('vinyl-buffer');

const paths = {
    scss: {
        src: 'src/scss/**/*.scss',
        dest: 'dist/static/css/'
    }
    //js: {
    //    src: 'dist/scripts/**/*.js',
    //    dest: 'dist/static/js/'
    //}
};

// Cleaning
const cleanScss = () => {
    return del(paths.scss.dest);
};

const cleanJs = () => {
    return del('dist/static/js');
}

const clean = parallel(cleanScss, cleanJs);

// Building
const styles = () => {
    return src(paths.scss.src)
        .pipe(sass().on('error', sass.logError))
        .pipe(cleanCss())
        .pipe(rename({ suffix: ".min" }))
        .pipe(dest(paths.scss.dest));
};

const scripts = () => {
    return browserify('dist/scripts/global.js')
        .bundle()
        .pipe(source('bundle.min.js'))
        .pipe(buffer())
        .pipe(uglify())
        .pipe(dest('dist/static/js/'));
}

const build = parallel(styles, scripts);

// Watching
const watchScss = cb => {
    watch(paths.scss.src, styles);
    cb();
}

const watchJs = cb => {
    watch('dist/scripts/**/*.js', scripts);
    cb();
}


// Exporting
exports.clean = parallel(cleanScss, cleanJs);
exports.build = build;
exports.watch = series(watchScss, watchJs);
exports.default = series(clean, build);