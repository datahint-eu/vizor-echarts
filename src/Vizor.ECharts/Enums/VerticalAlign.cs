﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<VerticalAlign>))]
public enum VerticalAlign
{
    Auto,
    Top,
    Bottom,
    Middle
}