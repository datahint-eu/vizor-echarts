window.vizorECharts = {

	charts: new Array(),

	getChart: function (id) {
		for (var i = 0; i < vizorECharts.charts.length; i++) {
			if (vizorECharts.charts[i].id === id) {
				return vizorECharts.charts[i].chart;
			}
		}
		return null;
	},

	evaluatePath: function (data, pathExpression) {
		const pathSegments = pathExpression.split('.');
		let currentObj = data;

		for (const segment of pathSegments) {
			if (!currentObj.hasOwnProperty(segment)) {
				return undefined; // Property not found, return undefined
			}
			currentObj = currentObj[segment];
		}

		return currentObj;
	},

	processObject: async function (obj) {
		for (const key in obj) {
			if (obj.hasOwnProperty(key)) {
				const value = obj[key];

				if (typeof value === 'object') {
					if (value.type === '__vi-ext-data') {
						// Fetch data asynchronously
						const response = await fetch(value.url, value.options);
						if (!response.ok) {
							throw new Error('Failed to fetch external chart data: url=' + value.url);
						}

						// parse the response as JSON
						const data = await response.json();

						// replace the object with the fetched data
						if (value.path != null) {
							obj[key] = vizorECharts.evaluatePath(data, value.path);
						} else {
							obj[key] = data;
						}
					} else if (value.type === '__vi-js-function') {
						// evaluate the function using eval
						const evaluatedFunction = eval('(' + value.function + ')');

						// replace the object with the evaluated function
						obj[key] = evaluatedFunction;
					} else if (value.type === '__vi-js-function-call') {
						// evaluate the function using eval
						const evaluatedFunction = eval('(' + value.function + ')()');

						// replace the object with the evaluated function
						obj[key] = evaluatedFunction;
					} else {
						// Continue recursively if the object has other properties
						await vizorECharts.processObject(value);
					}
				}
			}
		}
	},

	initChart: function (id, theme, initOptions, options, mapSpecialObjects) {
		var chart = echarts.init(document.getElementById(id), theme, JSON.parse(initOptions));
		vizorECharts.charts.push({ id: id, chart: chart });

		// show loading animation
		chart.showLoading();

		// parse the options
		if (options != null) {
			var parsedOptions = JSON.parse(options);

			// iterate through the options and map all JS functions / external data sources
			if (mapSpecialObjects) {
				vizorECharts.processObject(parsedOptions)
					.then(() => {
						// update the chart data
						chart.setOption(parsedOptions);

						// hide the loading animation
						chart.hideLoading();
					})
					.catch(error => {
						console.error('Error: ', error.message);
					});
			} else {
				// set the chart options
				chart.setOption(parsedOptions);

				// hide the loading animation immediately
				chart.hideLoading();
			}
		}
	},

	updateChart: function (id, options, mapSpecialObjects) {
		var chart = vizorECharts.getChart(id);
		if (chart == null) {
			console.error("Failed to retrieve chart id " + id);
			return;
		}

		// parse the options
		var parsedOptions = JSON.parse(options);

		// iterate through the options and map all JS functions / external data sources
		if (mapSpecialObjects) {
			vizorECharts.processObject(parsedOptions)
				.then(() => {
					// update the chart data
					chart.setOption(parsedOptions);

					// hide the loading animation
					chart.hideLoading();
				})
				.catch(error => {
					console.error('Error: ', error.message);
				});
		} else {
			// set the chart options
			chart.setOption(parsedOptions);

			// hide the loading animation
			chart.hideLoading();
		}
	},

	disposeChart: function (id) {
		var found = -1;
		for (var i = 0; i < vizorECharts.charts.length; i++) {
			if (vizorECharts.charts[i].id === id) {
				found = i;
				break;
			}
		}

		if (found >= 0) {
			echarts.dispose(vizorECharts.charts[i].id)
			vizorECharts.charts.splice(found, 1); // delete 1 at position found
		}
	}
};