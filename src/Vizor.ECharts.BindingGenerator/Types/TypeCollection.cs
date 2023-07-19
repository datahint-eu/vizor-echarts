﻿namespace Vizor.ECharts.BindingGenerator.Types;

internal class TypeCollection
{
	private readonly Dictionary<string, Dictionary<string, MappedEnumType>> enumTypesMappedByName = new();

	private readonly Dictionary<string, ObjectType> objectTypeLookup = new();
	private readonly List<ObjectType> seriesTypes = new();

	private readonly ObjectType chartOptions = new("chartOptions");

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
		AddMappedEnumType(new MappedEnumType("brushType", typeof(BrushType)));
		AddMappedEnumType(new MappedEnumType("colorBy", typeof(ColorBy)));
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
		AddMappedEnumType(new MappedEnumType("selectedMode", typeof(SelectionMode)));
		AddMappedEnumType(new MappedEnumType("selector", typeof(Selector)));
		AddMappedEnumType(new MappedEnumType("seriesLayoutBy", typeof(SeriesLayoutBy)));
		AddMappedEnumType(new MappedEnumType("showEffectOn", typeof(ShowEffectOn)));
		AddMappedEnumType(new MappedEnumType("stackStrategy", typeof(StackStrategy)));
		AddMappedEnumType(new MappedEnumType("step", typeof(Step)));
		AddMappedEnumType(new MappedEnumType("textAlign", typeof(HorizontalAlign)));
		AddMappedEnumType(new MappedEnumType("textBorderType", typeof(LineType)));
		AddMappedEnumType(new MappedEnumType("textBorderRadius", typeof(Radius)));
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
		AddMappedEnumType(new MappedEnumType("type", typeof(AxisPointer)), "axisPointer");

		AddMappedEnumType(new MappedEnumType("cap", typeof(LineCap)), "lineStyle", "crossStyle");
		AddMappedEnumType(new MappedEnumType("join", typeof(LineJoin)), "lineStyle", "crossStyle");

		AddMappedEnumType(new MappedEnumType("order", typeof(TooltipOrder)), "tooltip");
		AddMappedEnumType(new MappedEnumType("renderMode", typeof(RenderMode)), "tooltip");
		AddMappedEnumType(new MappedEnumType("trigger", typeof(TooltipTrigger)), "tooltip");

		AddMappedEnumType(new MappedEnumType("position", typeof(TopOrBottom)), "xAxis");
		AddMappedEnumType(new MappedEnumType("shape", typeof(RadarShape)), "radar");

		AddMappedEnumType(new MappedEnumType("selectorPosition", typeof(StartOrEnd)), "legend");
		AddMappedEnumType(new MappedEnumType("position", typeof(StartOrEnd)), "dayLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(StartOrEnd)), "monthLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(Position)), "yearLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(Position)), "controlStyle");
		AddMappedEnumType(new MappedEnumType("position", typeof(LeftOrRight)), "yAxis");
		AddMappedEnumType(new MappedEnumType("controlPosition", typeof(LeftOrRight)), "timeline");
		AddMappedEnumType(new MappedEnumType("layout", typeof(HorizontalOrVertical)), "parallel");

		AddMappedEnumType(new MappedEnumType("layout", typeof(TreeLayout)), "TreeSeries");
		AddMappedEnumType(new MappedEnumType("edgeShape", typeof(TreeEdgeShape)), "TreeSeries");


		AddMappedEnumType(new MappedEnumType("effectType", typeof(ScatterEffectType)), "EffectScatterSeries");
	}

	public ObjectType ChartOptions => chartOptions;

	public IEnumerable<ObjectType> ListObjectTypesToGenerate()
	{
		yield return chartOptions;

		foreach (var objectType in objectTypeLookup.Values)
			yield return objectType;
	}

	public IEnumerable<ObjectType> ListSeriesTypesToGenerate() => seriesTypes;

	public bool TryGetObjectType(string name, out ObjectType? objectType) => objectTypeLookup.TryGetValue(name, out objectType);

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

	public void AddObjectType(ObjectType objectType)
	{
		objectTypeLookup.Add(objectType.Name, objectType);
	}

	public void AddSeriesType(ObjectType objectType)
	{
		seriesTypes.Add(objectType);
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
