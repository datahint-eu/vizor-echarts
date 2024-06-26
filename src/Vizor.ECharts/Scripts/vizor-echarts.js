window.vizorECharts = {

	charts: new Map(),
	dataSources: new Map(),

	logging: false,

	changeLogging: function (b) {
		vizorECharts.logging = b;
	},

	getChart: function (id) {
		return vizorECharts.charts.get(id);
	},

	getDataSource: function (fetchId) {
		var data = vizorECharts.dataSources.get(fetchId);

		if (vizorECharts.logging) {
			console.log(`GET CACHED FETCH ${fetchId}`);
			console.log(data);
		}

		return data;
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

	fetchExternalData: async function (chart, fetchOptions) {
		if (fetchOptions == null)
			return;

		chart.__dataSources = [];

		for (item of JSON.parse(fetchOptions)) {
			if (vizorECharts.logging) {
				console.log(`FETCH ${item.id}`);
				console.log(item);
			}

			const response = await fetch(item.url, item.options);
			if (!response.ok) {
				throw new Error('Failed to fetch external chart data: url=' + url);
			}

			// parse the response as JSON
			var data = null;
			if (item.fetchAs == "json") {
				data = await response.json();

				// replace the object with the fetched data
				if (item.path != null) {
					try {
						data = vizorECharts.evaluatePath(data, item.path);
					} catch (error) {
						console.log('Failed to evaluate path expression of external data source');
						console.log(error);
					}
				}
			} else if (item.fetchAs == "string") {
				data = await response.text();
			}

			if (vizorECharts.logging) {
				console.log(data);
			}

			// execute the afterLoad function if required
			if (item.afterLoad != null) {
				try {
					const func = eval(`(${item.afterLoad})`)
					data = func(data);
				} catch (error) {
					console.log('Failed to execute afterLoad function of external data source');
					console.log(error);
				}
			}

			// store in the datasources map for later retrieval
			window.vizorECharts.dataSources.set(item.id, data);

			// add reference inside the chart, so we can cleanup later
			chart.__dataSources.push(item.id);
		}
	},

	registerMaps: function (chart, mapOptions) {
		if (mapOptions == null)
			return;

		var parsedOptions = eval('(' + mapOptions + ')');
		for (item of parsedOptions) {
			if (vizorECharts.logging) {
				console.log("MAP");
				console.log(item);
			}

			if (item.type === "geoJSON") {
				echarts.registerMap(item.mapName, { geoJSON: item.geoJSON, specialAreas: item.specialAreas });
			} else if (item.type === "svg") {
				echarts.registerMap(item.mapName, { svg: item.svg });
			}
		}
	},

	initChart: async function (id, theme, initOptions, chartOptions, mapOptions, fetchOptions) {
		var chart = echarts.init(document.getElementById(id), theme, JSON.parse(initOptions));
		vizorECharts.charts.set(id, chart);

		// show loading animation
		chart.showLoading();

		if (chartOptions == null)
			return;

		// fetch external data if needed
		await vizorECharts.fetchExternalData(chart, fetchOptions);

		// register GEO maps
		await vizorECharts.registerMaps(chart, mapOptions);

		// parse the options
		var parsedOptions = eval('(' + chartOptions + ')');

		if (vizorECharts.logging) {
			console.log("CHART");
			console.log(parsedOptions);
		}

		// set the chart options
		chart.setOption(parsedOptions);

		// hide the loading animation immediately
		chart.hideLoading();
	},

	updateChart: async function (id, chartOptions, mapOptions, fetchOptions) {
		var chart = vizorECharts.charts.get(id);
		if (chart == null) {
			console.error("Failed to retrieve chart " + id);
			return;
		}

		// fetch external data if needed
		await vizorECharts.fetchExternalData(chart, fetchOptions);

		// register GEO maps
		await vizorECharts.registerMaps(chart, mapOptions);

		// parse the options
		var parsedOptions = eval('(' + chartOptions + ')');

		// iterate through the options and map all JS functions / external data sources
		// set the chart options
		chart.setOption(parsedOptions);

		// hide the loading animation
		chart.hideLoading();
	},

	attachClickEvent: function (id, objRef) {
		var chart = vizorECharts.charts.get(id);
		if (chart == null) {
			console.error("Failed to retrieve chart " + id);
			return;
		}

		// Call the JSInvokable .NET method
		chart.on('click', function (params) {
			if (vizorECharts.logging) {
				console.log("CLICK");
				console.log(params);
			}
			
			// before we can call .NET, we must sanitize the object to prevent circular references from being serialized
			delete params.encode;
			delete params.event;
			
			objRef.invokeMethodAsync('HandleChartClick', params);
		});
	},

	disposeChart: function (id) {
		var chart = vizorECharts.charts.get(id);
		if (chart == null) {
			console.error("Failed to dispose chart " + id);
			return;
		}

		// dispose of all dataSources linked to the chart
		if (chart.__dataSources && Array.isArray(chart.__dataSources)) {
			chart.__dataSources.forEach(id => {
				window.vizorECharts.dataSources.delete(id);
			});
		}

		echarts.dispose(chart)
		vizorECharts.charts.delete(id);
	}
};