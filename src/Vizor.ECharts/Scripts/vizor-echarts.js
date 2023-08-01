window.vizorECharts = {

	charts: new Map(),

	getChart: function (id) {
		return vizorECharts.charts.get(id);
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

	fetchExternalData: async function (chartId, fetchOptions) {
		if (fetchOptions == null)
			return;

		for (item of JSON.parse(fetchOptions)) {
			//console.log(item);

			const response = await fetch(item.url, item.options);
			if (!response.ok) {
				throw new Error('Failed to fetch external chart data: url=' + url);
			}

			// parse the response as JSON
			var data = await response.json();
			//console.log(data);

			// replace the object with the fetched data
			if (item.path != null) {
				data = vizorECharts.evaluatePath(data, item.path);
			}

			// assign for later retrieval
			window.vizorECharts.getChart(chartId)[item.id] = data;
		}
	},

	initChart: async function (id, theme, initOptions, fetchOptions, chartOptions) {
		var chart = echarts.init(document.getElementById(id), theme, JSON.parse(initOptions));
		vizorECharts.charts.set(id, chart);

		// show loading animation
		chart.showLoading();

		if (chartOptions == null)
			return;

		// fetch external data if needed
		await vizorECharts.fetchExternalData(id, fetchOptions);

		// parse the options
		var parsedOptions = eval('(' + chartOptions + ')');
		console.log(parsedOptions);

		// set the chart options
		chart.setOption(parsedOptions);

		// hide the loading animation immediately
		chart.hideLoading();
	},

	updateChart: async function (id, fetchOptions, chartOptions) {
		var chart = vizorECharts.charts.get(id);
		if (chart == null) {
			console.error("Failed to retrieve chart " + id);
			return;
		}

		// fetch external data if needed
		await vizorECharts.fetchExternalData(id, fetchOptions);

		// parse the options
		var parsedOptions = eval('(' + chartOptions + ')');

		// iterate through the options and map all JS functions / external data sources
		// set the chart options
		chart.setOption(parsedOptions);

		// hide the loading animation
		chart.hideLoading();
	},

	disposeChart: function (id) {
		var chart = vizorECharts.charts.get(id);
		if (chart == null) {
			console.error("Failed to dispose chart " + id);
			return;
		}

		echarts.dispose(chart)
		vizorECharts.charts.delete(id);
	}
};