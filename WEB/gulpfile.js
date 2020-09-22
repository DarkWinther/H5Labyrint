/// <binding AfterBuild='build' Clean='clean' ProjectOpened='watch' />
const { src, dest, series, watch } = require('gulp');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const rename = require('gulp-rename');
const del = require('del');

const paths = {
    scss: {
        src: 'src/scss/**/*.scss',
        dest: 'dist/static/css/'
    }
};

const styles = () => {
    return src(paths.scss.src)
        .pipe(sass().on('error', sass.logError))
        .pipe(cleanCss())
        .pipe(rename({ suffix: ".min" }))
        .pipe(dest(paths.scss.dest));
};

const clean = cb => {
    del.sync('dist/static/css');
    cb();
};

const build = series(clean, styles);

const watchScss = cb => {
    watch(paths.scss.src, build);
    cb();
}

exports.clean = clean;
exports.build = build;
exports.watch = watchScss;
exports.default = series(build, watchScss);