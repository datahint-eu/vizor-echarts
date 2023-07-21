using System.Text.Json;
using Vizor.ECharts;

namespace Vizor.ECharts.BindingGenerator.Types;

internal class TypeCollection
{
	private readonly Dictionary<string, Dictionary<string, MappedEnumType>> enumTypesMappedByName = new();

	private readonly Dictionary<string, List<ObjectType>> allObjectTypesWithDuplicates = new();
	private readonly Dictionary<string, ObjectType> objectTypeLookup = new();

	private readonly ObjectType chartOptions = new(null, "", "ChartOptions", "Options");

	public TypeCollection()
	{
		AddMappedEnumType(new MappedEnumType("align", typeof(HorizontalAlign)));
		AddMappedEnumType(new MappedEnumType("animationEasing", typeof(AnimationEasing)));
		AddMappedEnumType(new MappedEnumType("animationEasingUpdate", typeof(AnimationEasing)));
		AddMappedEnumType(new MappedEnumType("animationType", typeof(AnimationType)));
		AddMappedEnumType(new MappedEnumType("animationTypeUpdate", typeof(AnimationTypeUpdate)));
		AddMappedEnumType(new MappedEnumType("axisExpandTriggerOn", typeof(TriggerOn)));
		AddMappedEnumType(new MappedEnumType("axisPosition", typeof(TopOrBottom)));
		AddMappedEnumType(new MappedEnumType("axisSymbol", typeof(AxisSymbol)));
		AddMappedEnumType(new MappedEnumType("axisType", typeof(AxisType)));
		AddMappedEnumType(new MappedEnumType("blendMode", typeof(BlendMode)));
		AddMappedEnumType(new MappedEnumType("borderCap", typeof(LineCap)));
		AddMappedEnumType(new MappedEnumType("borderJoin", typeof(LineJoin)));
		AddMappedEnumType(new MappedEnumType("borderRadius", typeof(Radius)));
		AddMappedEnumType(new MappedEnumType("borderType", typeof(LineType)));
		AddMappedEnumType(new MappedEnumType("boundaryGap", typeof(BoundaryGap)));
		AddMappedEnumType(new MappedEnumType("brushType", typeof(BrushType)));
		AddMappedEnumType(new MappedEnumType("colorBy", typeof(ColorBy)));
		AddMappedEnumType(new MappedEnumType("colorMappingBy", typeof(ColorMappingBy)));
		AddMappedEnumType(new MappedEnumType("emphasisBlurScope", typeof(EmphasisBlurScope)));
		AddMappedEnumType(new MappedEnumType("emphasisFocus", typeof(EmphasisFocus)));
		AddMappedEnumType(new MappedEnumType("fontStyle", typeof(FontStyle)));
		AddMappedEnumType(new MappedEnumType("fontWeight", typeof(FontWeight)));
		AddMappedEnumType(new MappedEnumType("horizontalAlign", typeof(HorizontalAlign)));
		AddMappedEnumType(new MappedEnumType("icon", typeof(Icon)));
		AddMappedEnumType(new MappedEnumType("legendType", typeof(LegendType)));
		AddMappedEnumType(new MappedEnumType("lineCoordinateSystem", typeof(LineCoordinateSystem)));
		AddMappedEnumType(new MappedEnumType("lineType", typeof(LineType)));
		AddMappedEnumType(new MappedEnumType("nameLocation", typeof(NameLocation)));
		AddMappedEnumType(new MappedEnumType("orient", typeof(Orient)));
		AddMappedEnumType(new MappedEnumType("orthogonalOrient", typeof(OrthogonalOrient)));
		AddMappedEnumType(new MappedEnumType("overflow", typeof(Overflow)));
		AddMappedEnumType(new MappedEnumType("padding", typeof(Padding)));
		AddMappedEnumType(new MappedEnumType("radius", typeof(Radius)));
		AddMappedEnumType(new MappedEnumType("roam", typeof(Roam)));
		AddMappedEnumType(new MappedEnumType("selectedMode", typeof(SelectionMode)));
		AddMappedEnumType(new MappedEnumType("selector", typeof(Selector)));
		AddMappedEnumType(new MappedEnumType("seriesLayoutBy", typeof(SeriesLayoutBy)));
		AddMappedEnumType(new MappedEnumType("showEffectOn", typeof(ShowEffectOn)));
		AddMappedEnumType(new MappedEnumType("stackStrategy", typeof(StackStrategy)));
		AddMappedEnumType(new MappedEnumType("step", typeof(Step)));
		AddMappedEnumType(new MappedEnumType("textAlign", typeof(HorizontalAlign)));
		AddMappedEnumType(new MappedEnumType("textBorderType", typeof(LineType)));
		AddMappedEnumType(new MappedEnumType("textBorderRadius", typeof(Radius)));
		AddMappedEnumType(new MappedEnumType("textPadding", typeof(Padding)));
		AddMappedEnumType(new MappedEnumType("textVerticalAlign", typeof(VerticalAlign)));
		AddMappedEnumType(new MappedEnumType("tooltipOrder", typeof(TooltipOrder)));
		AddMappedEnumType(new MappedEnumType("tooltipRenderMode", typeof(RenderMode)));
		AddMappedEnumType(new MappedEnumType("tooltipTrigger", typeof(TooltipTrigger)));
		AddMappedEnumType(new MappedEnumType("tooltipTriggerOn", typeof(TriggerOn)));
		AddMappedEnumType(new MappedEnumType("triggerOn", typeof(TriggerOn)));
		AddMappedEnumType(new MappedEnumType("treeLayout", typeof(TreeLayout)));
		AddMappedEnumType(new MappedEnumType("verticalAlign", typeof(VerticalAlign)));



		AddMappedEnumType(new MappedEnumType("type", typeof(LineType)), "lineStyle");
		AddMappedEnumType(new MappedEnumType("type", typeof(LegendType)), "legend");
		AddMappedEnumType(new MappedEnumType("type", typeof(ImageType)), "saveAsImage");
		AddMappedEnumType(new MappedEnumType("type", typeof(AxisPointerType)), "axisPointer");
		AddMappedEnumType(new MappedEnumType("type", typeof(MarkPointType)), "markPointData");

		AddMappedEnumType(new MappedEnumType("cap", typeof(LineCap)), "lineStyle", "crossStyle", "ParallelSeriesData");
		AddMappedEnumType(new MappedEnumType("join", typeof(LineJoin)), "lineStyle", "crossStyle", "ParallelSeriesData");

		AddMappedEnumType(new MappedEnumType("order", typeof(TooltipOrder)), "tooltip");
		AddMappedEnumType(new MappedEnumType("renderMode", typeof(RenderMode)), "tooltip");
		AddMappedEnumType(new MappedEnumType("trigger", typeof(TooltipTrigger)), "tooltip");

		AddMappedEnumType(new MappedEnumType("position", typeof(TopOrBottom)), "xAxis");
		AddMappedEnumType(new MappedEnumType("shape", typeof(RadarShape)), "radar");

		AddMappedEnumType(new MappedEnumType("status", typeof(AxisPointerStatus)), "axisPointer");
		AddMappedEnumType(new MappedEnumType("symbol", typeof(AxisLineSymbol)), "axisLine");

		AddMappedEnumType(new MappedEnumType("alignTo", typeof(LabelAlignTo)), "label");

		AddMappedEnumType(new MappedEnumType("selectorPosition", typeof(StartOrEnd)), "legend");
		AddMappedEnumType(new MappedEnumType("position", typeof(StartOrEnd)), "dayLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(StartOrEnd)), "monthLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(Position)), "yearLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(Position)), "controlStyle");
		AddMappedEnumType(new MappedEnumType("position", typeof(LeftOrRight)), "yAxis");
		AddMappedEnumType(new MappedEnumType("controlPosition", typeof(LeftOrRight)), "timeline");
		AddMappedEnumType(new MappedEnumType("layout", typeof(HorizontalOrVertical)), "parallel");
		AddMappedEnumType(new MappedEnumType("position", typeof(LabelPosition)), "label", "upperLabel");

		AddMappedEnumType(new MappedEnumType("seriesIndex", typeof(MultiIndex)), "brush");
		AddMappedEnumType(new MappedEnumType("geoIndex", typeof(MultiIndex)), "brush");
		AddMappedEnumType(new MappedEnumType("xAxisIndex", typeof(MultiIndex)), "brush", "dataZoom");
		AddMappedEnumType(new MappedEnumType("yAxisIndex", typeof(MultiIndex)), "brush", "dataZoom");



		AddMappedEnumType(new MappedEnumType("layout", typeof(TreeLayout)), "TreeSeries");
		AddMappedEnumType(new MappedEnumType("edgeShape", typeof(TreeEdgeShape)), "TreeSeries");

		AddMappedEnumType(new MappedEnumType("funnelAlign", typeof(FunnelAlign)), "FunnelSeries");

		AddMappedEnumType(new MappedEnumType("nodeAlign", typeof(SankeyNodeAlign)), "SankeySeries");

		AddMappedEnumType(new MappedEnumType("layout", typeof(GraphLayout)), "GraphSeries");

		AddMappedEnumType(new MappedEnumType("nodeClick", typeof(SunburstNodeClick)), "SunburstSeries");

		AddMappedEnumType(new MappedEnumType("symbolRepeatDirection", typeof(StartOrEnd)), "PictorialBarSeries", "PictorialBarSeriesData");
		AddMappedEnumType(new MappedEnumType("symbolPosition", typeof(StartOrEndOrCenter)), "PictorialBarSeries", "PictorialBarSeriesData");
		AddMappedEnumType(new MappedEnumType("symbolRepeat", typeof(PictorialSymbolRepeat)), "PictorialBarSeries", "PictorialBarSeriesData");

		AddMappedEnumType(new MappedEnumType("effectType", typeof(ScatterEffectType)), "EffectScatterSeries");

		AddMappedEnumType(new MappedEnumType("roseType", typeof(PieRoseType)), "PieSeries");
		AddMappedEnumType(new MappedEnumType("radius", typeof(PieRadius)), "PieSeries");
		AddMappedEnumType(new MappedEnumType("center", typeof(PieCenter)), "PieSeries");

		AddMappedEnumType(new MappedEnumType("filterMode", typeof(DataZoomFilterMode)), "InsideDataZoom", "SliderDataZoom");
		AddMappedEnumType(new MappedEnumType("zoomOnMouseWheel", typeof(DataZoomOnMouse)), "InsideDataZoom");
		AddMappedEnumType(new MappedEnumType("moveOnMouseMove", typeof(DataZoomOnMouse)), "InsideDataZoom");
		AddMappedEnumType(new MappedEnumType("moveOnMouseWheel", typeof(DataZoomOnMouse)), "InsideDataZoom");
	}

	public ObjectType ChartOptions => chartOptions;

	public IReadOnlyDictionary<string, List<ObjectType>> TypesWithDuplicates => allObjectTypesWithDuplicates;

	public IEnumerable<ObjectType> ListObjectTypesToGenerate()
	{
		yield return chartOptions;

		foreach (var objectType in objectTypeLookup.Values)
			yield return objectType;
	}

	public bool TryGetObjectType(string name, out ObjectType? objectType) => objectTypeLookup.TryGetValue(name, out objectType);

	public IPropertyType? MapArrayType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
	{
		// did we succeed in determining the item type ?
		if (optProp.ItemType != null)
		{
			return new GenericListType(optProp.ItemType);
		}

		// special cases: these are often aliases
		switch (prop.Name, parent.Name)
		{
			case ("nodes", "SankeySeries"):
				return new GenericListType(new SimpleType("SankeySeriesData"));
			case ("edges", "SankeySeries"):
				return new GenericListType(new SimpleType("SankeySeriesLinks"));
			case ("nodes", "GraphSeries"):
				return new GenericListType(new SimpleType("GraphSeriesData"));
			case ("edges", "GraphSeries"):
				return new GenericListType(new SimpleType("GraphSeriesLinks"));
		}

		//Console.WriteLine($"WARNING: array type '{prop.Name}' in '{parent.Name}' will be mapped to List<object>");
		return new ObjectListType()
		{
			TypeWarning = $"array type '{prop.Name}' in '{parent.Name}' will be mapped to List<object>"
		};
	}

	public bool TryGetMappedEnumType(string name, string parentName, out MappedEnumType? mappedEnumType)
	{
		if (enumTypesMappedByName.TryGetValue(name, out var typeDict))
		{
			// specific mapping for the parent type
			if (typeDict.TryGetValue(parentName, out mappedEnumType))
				return true;

			// non-specific mapping for the parent type
			if (typeDict.TryGetValue("*", out mappedEnumType))
				return true;

			//TODO: sanity check for enum types
		}

		mappedEnumType = null;
		return false;
	}

	public void TrackType(ObjectType objectType)
	{
		if (!allObjectTypesWithDuplicates.TryGetValue(objectType.Name, out var list))
		{
			list = new List<ObjectType>();
			allObjectTypesWithDuplicates.Add(objectType.Name, list);
		}

		list.Add(objectType);
	}

	public ObjectType MergeType(ObjectType objectType)
	{
		if (!objectTypeLookup.TryGetValue(objectType.Name, out var mergedType))
		{
			mergedType = new ObjectType(null, objectType.Name, typeGroup: objectType.TypeGroup); // merged types have many parents, so set parent to null
			objectTypeLookup.Add(mergedType.Name, mergedType);
		}

		foreach (var property in objectType.Properties)
		{
			if (!mergedType.Properties.Any(p => p.Name == property.Name))
			{
				mergedType.Properties.Add(property);
			}
		}

		return mergedType;
	}

	private void AddMappedEnumType(MappedEnumType mappedType, params string[]? specificObjectTypes)
	{
		if (!enumTypesMappedByName.TryGetValue(mappedType.Name, out var typeDict))
		{
			typeDict = new Dictionary<string, MappedEnumType>();
			enumTypesMappedByName.Add(mappedType.Name, typeDict);
		}

		if (specificObjectTypes == null || specificObjectTypes.Length == 0)
		{
			typeDict.Add("*", mappedType);
		}
		else
		{
			foreach (var specificType in specificObjectTypes)
			{
				typeDict.Add(specificType, mappedType);
			}
		}
	}
}
