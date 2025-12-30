# Node Build Toolchain Status

This project uses Gulp to bundle the JavaScript interop assets. Current state and known issues of the build toolchain are documented here.

## Current Dependencies (src/Vizor.ECharts/package.json)
- gulp 4.x
- del (replaces deprecated gulp-clean)
- gulp-clean-css
- gulp-concat
- gulp-minify
- gulp-postcss
- gulp-rename
- gulp-sass
- sass
- echarts, echarts-stat

## npm audit (after cleanup)
- Remaining vulnerabilities: **13** (6 moderate, 7 high) reported by `npm audit`
- Key sources:
  - **braces / micromatch / chokidar** chain (high): would require upgrading to **gulp 5** (breaking change)
  - **terser via gulp-minify** (high): would require replacing/upgrading the minifier (e.g., gulp-terser) or accepting a breaking change

## What was cleaned up
- Removed unused dev dependencies: bootstrap, child_process, gulp-cssnano, gulp-filter, gulp-sass-glob
- Replaced deprecated **gulp-clean** with **del** in gulpfile

## Why leave as-is for now
- The vulnerabilities are in the **build toolchain**, not shipped runtime code
- Upgrading to gulp 5 and swapping minifier may require refactoring and re-testing the pipeline

## Future Improvement Options
1. **Upgrade to gulp 5** and compatible plugins to clear the braces/chokidar chain
2. **Replace gulp-minify** with **gulp-terser** (or another maintained minifier) to address terser advisory
3. After changes, rerun `npm install` and `npm audit` to verify

## How to reproduce the audit
```bash
cd src/Vizor.ECharts
npm audit
```

## Build commands
```bash
# JS assets
cd src/Vizor.ECharts
npm install
npx gulp          # builds vizor-echarts.js and vizor-echarts-bundle.js

# .NET solution
cd ../..
dotnet restore src/Vizor.ECharts.Demo.sln
dotnet build src/Vizor.ECharts.Demo.sln --no-restore --configuration Debug
dotnet pack -c Release src/Vizor.ECharts/Vizor.ECharts.csproj
```
