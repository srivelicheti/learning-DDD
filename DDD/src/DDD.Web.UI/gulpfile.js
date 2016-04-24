/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    inject = require("gulp-inject");

   

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js",
    function(cb) {
        rimraf(paths.concatJsDest, cb);
    });

gulp.task("clean:css",
    function(cb) {
        rimraf(paths.concatCssDest, cb);
    });

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js",
    function() {
        return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
            .pipe(concat(paths.concatJsDest))
            .pipe(uglify())
            .pipe(gulp.dest("."));
    });

gulp.task("min:css",
    function() {
        return gulp.src([paths.css, "!" + paths.minCss])
            .pipe(concat(paths.concatCssDest))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });

gulp.task("min", ["min:js", "min:css"]);

gulp.task("inject-vendor-js-css-wiredep", function () {
    var wiredep = require("wiredep").stream;

    var options = {
       // bowerJson: bower,
      //  directory: 'wwwroot/lib',
        ignorePath: '../../wwwroot'
     //   client: 'Views/Shared/_Layout.cshtml',
      //  cwd:'wwwroot'
    };
    return gulp.src("Views/Shared/_Layout.cshtml").pipe(wiredep(options)).pipe(gulp.dest("Views/Shared"));
});


gulp.task("inject-app-js-css", function() {
    var target = gulp.src("Views/Shared/_Layout.cshtml");
    var sources = gulp.src(['wwwroot/js/**/*.js', "wwwroot/css/**/*.css"], { read: false });
    return target.pipe(inject(sources, {ignorePath:"/wwwroot"})).pipe(gulp.dest("Views/Shared"));
});

gulp.task("dev-scripts", ['inject-vendor-js-css-wiredep', 'inject-app-js-css']);