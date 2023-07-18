// Following steps are required to install gulp: see https://gulpjs.com/docs/en/getting-started/quick-start/
// npm install --global gulp-cli
//
// in the project dir:
//   npm init
//   npm install --save-dev gulp gulp-rename gulp-clean gulp-concat gulp-minify child_process
//   npm install echarts --save
//
// to build:
//   gulp

var path = require('path'),
	rename = require('gulp-rename'),
	clean = require('gulp-clean'),
	gulp = require('gulp'),
	sass = require('gulp-sass')(require('sass')),
	postcss = require('gulp-postcss'),
	cleancss = require('gulp-clean-css'),
	concat = require('gulp-concat'),
	minify = require('gulp-minify');
var exec = require("child_process").exec;

var vizorScripts = './Scripts';
var wwwroot = path.resolve(__dirname, "wwwroot");
var libroot = path.resolve(__dirname, "./node_modules");


var srcPaths = {
	js: [
		path.resolve(libroot, 'echarts/dist/echarts.min.js'),
		path.resolve(vizorScripts, 'vizor-echarts.js'),
	]
};


var destPaths = {
	js: path.resolve(wwwroot, 'js')
};


gulp.task('clean', () => {
	return gulp.src(
		[path.resolve(wwwroot, 'js/**')])
		.pipe(clean());
});

gulp.task('buildJs', () => {
	return gulp.src(srcPaths.js)
		.pipe(concat('vizor-echarts.js'))
		.pipe(minify())
		.pipe(gulp.dest(destPaths.js))
});

gulp.task("publishLocal", function (callback) {
	exec(
		"Powershell.exe -executionpolicy remotesigned . .\\publish_local.ps1 -Push:1",
		function (err, stdout, stderr) {
			console.log(stdout);
			callback(err);
		}
	);
});

gulp.task('cleanup', gulp.series(['clean']));
gulp.task('default', gulp.series(['buildJs']));