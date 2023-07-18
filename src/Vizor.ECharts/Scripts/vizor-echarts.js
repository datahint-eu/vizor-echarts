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

	initChart: function (id, /*blazorComponent,*/ options, theme, width, height) {
		var chart = echarts.init(document.getElementById(id), theme, { renderer: 'svg', width: width, height: height });

		// we need to use eval instead of JSON.parse, because the options can contain JS functions
		var parsedOptions = eval('(' + options + ')');

		chart.showLoading();
		chart.setOption(parsedOptions);
		chart.hideLoading();

		vizorECharts.charts.push({ id: id, chart: chart/*, blazorComponent: blazorComponent*/ });
	},

	updateChart: function (id, options) {
		var chart = GetChart(id);
		if (chart == null) {
			console.error("Failed to retrieve chart id " + id);
			return;
		}

		// we need to use eval instead of JSON.parse, because the options can contain JS functions
		var parsedOptions = eval('(' + options + ')');

		chart.setOption(parsedOptions);
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