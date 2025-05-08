using System.Text.Json.Serialization;

namespace Vizor.ECharts
{
    //https://stackoverflow.com/questions/42503988/echarts-datazoom-event-does-not-return-timestamp-but-only-percentages
    public class EventDatazoom
    {

        [JsonPropertyName("datazoomItems")]
        public List<EventDatazoomItem> DatazoomItems { get; set; } = new List<EventDatazoomItem>();
    }

    public class EventDatazoomItem
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "";

        [JsonPropertyName("startValue")]
        public double StartValue { get; set; }

        [JsonPropertyName("endValue")]
        public double EndValue { get; set; }

        [JsonPropertyName("start")]
        public double StartPercent { get; set; }

        [JsonPropertyName("end")]
        public double EndPercent { get; set; }
    }
}
