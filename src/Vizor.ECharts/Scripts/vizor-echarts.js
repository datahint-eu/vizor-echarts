window.vizorECharts = {

	charts: new Map(),
	dataSources: new Map(),

	logging: false,

	changeLogging(b) {
		vizorECharts.logging = b;
	},

	getChart(id) {
		return vizorECharts.charts.get(id);
	},

	getDataSource(fetchId) {
		const data = vizorECharts.dataSources.get(fetchId);

		if (vizorECharts.logging) {
			console.log(`GET CACHED FETCH ${fetchId}`);
			console.log(data);
		}

		return data;
	},

	evaluatePath(data, pathExpression) {
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

	async fetchExternalData(chart, fetchOptions) {
		if (fetchOptions === null)
			return;

		chart.__dataSources = [];

		for (const item of JSON.parse(fetchOptions)) {
			if (vizorECharts.logging) {
				console.log(`FETCH ${item.id}`);
				console.log(item);
			}

			const response = await fetch(item.url, item.options);
			if (!response.ok) {
				throw new Error(`Failed to fetch external chart data: url=${item.url}`);
			}

			// parse the response as JSON
			let data = null;
			if (item.fetchAs === "json") {
				data = await response.json();

				// replace the object with the fetched data
				if (item.path !== null) {
					try {
						data = vizorECharts.evaluatePath(data, item.path);
					} catch (error) {
						console.log('Failed to evaluate path expression of external data source');
						console.log(error);
					}
				}
			} else if (item.fetchAs === "string") {
				data = await response.text();
			}

			if (vizorECharts.logging) {
				console.log(data);
			}

			// execute the afterLoad function if required
			if (item.afterLoad !== null) {
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

	registerMaps(chart, mapOptions) {
		if (mapOptions === null)
			return;

		const parsedOptions = eval('(' + mapOptions + ')');
		for (const item of parsedOptions) {
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

	async initChart(id, theme, initOptions, chartOptions, mapOptions, fetchOptions) {
		const chart = echarts.init(document.getElementById(id), theme, JSON.parse(initOptions));

		// see issue #20: Size to fit container: Width="auto" not working
		const resizeHandler = function () {
			chart.resize();
		};
		window.addEventListener('resize', resizeHandler);
		chart.__resizeHandler = resizeHandler;  // Store reference on chart

		vizorECharts.charts.set(id, chart);

		// show loading animation
		chart.showLoading();

		if (chartOptions === null)
			return;

		// fetch external data if needed
		await vizorECharts.fetchExternalData(chart, fetchOptions);

		// register GEO maps
		await vizorECharts.registerMaps(chart, mapOptions);

		// parse the options
		const parsedOptions = eval('(' + chartOptions + ')');

		if (vizorECharts.logging) {
			console.log("CHART");
			console.log(parsedOptions);
		}

		// set the chart options
		chart.setOption(parsedOptions);

		// hide the loading animation immediately
		chart.hideLoading();
	},

	async updateChart(id, chartOptions, mapOptions, fetchOptions) {
		const chart = vizorECharts.charts.get(id);
		if (chart === null) {
			console.error("Failed to retrieve chart " + id);
			return;
		}

		// fetch external data if needed
		await vizorECharts.fetchExternalData(chart, fetchOptions);

		// register GEO maps
		await vizorECharts.registerMaps(chart, mapOptions);

		// parse the options
		const parsedOptions = eval('(' + chartOptions + ')');

		// iterate through the options and map all JS functions / external data sources
		// set the chart options
		chart.setOption(parsedOptions);

		// hide the loading animation
		chart.hideLoading();
	},

	attachClickEvent(id, objRef) {
		const chart = vizorECharts.charts.get(id);
		if (chart === null) {
			console.error("Failed to retrieve chart " + id);
			return;
		}

		// Call the JSInvokable .NET method
		chart.on('click', (params) => {
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

	clearChart(id) {
		const chart = vizorECharts.charts.get(id);
		if (chart === null) {
			console.error("Failed to clear chart " + id);
			return;
		}

		chart.clear();
	},

	disposeChart(id) {
		const chart = vizorECharts.charts.get(id);
		if (chart === null) {
			console.error("Failed to dispose chart " + id);
			return;
		}

		// dispose of all dataSources linked to the chart
		if (chart.__dataSources && Array.isArray(chart.__dataSources)) {
			chart.__dataSources.forEach(id => {
				window.vizorECharts.dataSources.delete(id);
			});
		}
		// remove resize listener
		if (chart.__resizeHandler) {
			window.removeEventListener('resize', chart.__resizeHandler);
		}
		// dispose the chart instance
		echarts.dispose(chart)
		vizorECharts.charts.delete(id);
	}
};