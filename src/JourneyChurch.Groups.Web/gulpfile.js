/// <binding BeforeBuild='min' Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat-util"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    angularFilesort = require("gulp-angular-filesort"),
    inject = require("gulp-inject"),
    watch = require("gulp-watch");

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "parts/**/*.js";
paths.minJs = paths.webroot + "parts/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "parts/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) { 
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(inject(gulp.src([paths.js]).pipe(angularFilesort())))
        .pipe(concat(paths.concatJsDest))
        //.pipe(uglify())
        .pipe(concat.header(""))
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

gulp.task('watch', function() {
    return gulp.watch([paths.js, paths.css], ['min']);
});