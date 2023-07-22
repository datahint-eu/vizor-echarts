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

	processObject: async function (obj) {
		for (const key in obj) {
			if (obj.hasOwnProperty(key)) {
				const value = obj[key];

				if (typeof value === 'object') {
					if (value.type === '__vi-ext-data') {
						// Fetch data asynchronously
						const response = await fetch(value.url);
						if (!response.ok) {
							throw new Error('Failed to fetch external chart data: url=' + value.url);
						}

						// parse the response as JSON
						const data = await response.json();

						// replace the object with the fetched data
						obj[key] = data;
					} else if (value.type === '__vi-js-function') {
						// evaluate the function using eval
						const evaluatedFunction = eval('(' + value.function + ')');

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

	initChart: function (id, theme, width, height, options, noMapping) {
		var chart = echarts.init(document.getElementById(id), theme, { renderer: 'svg', width: width, height: height });
		vizorECharts.charts.push({ id: id, chart: chart });

		// show loading animation
		chart.showLoading();

		// parse the options
		var parsedOptions = JSON.parse(options);

		// iterate through the options and map all JS functions / external data sources
		if (!noMapping) {
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
	},

	updateChart: function (id, options, noMapping) {
		var chart = vizorECharts.getChart(id);
		if (chart == null) {
			console.error("Failed to retrieve chart id " + id);
			return;
		}

		// parse the options
		var parsedOptions = JSON.parse(options);

		// iterate through the options and map all JS functions / external data sources
		if (!noMapping) {
			vizorECharts.processObject(parsedOptions)
				.then(() => {
					// update the chart data
					chart.setOption(parsedOptions);
				})
				.catch(error => {
					console.error('Error: ', error.message);
				});
		} else {
			// set the chart options
			chart.setOption(parsedOptions);
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