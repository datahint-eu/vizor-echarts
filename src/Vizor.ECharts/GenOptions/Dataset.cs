// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Dataset
{
	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	//TODO: Source
	/// <summary>
	/// dimensions can be used to define dimension info for series.data or dataset.source .
	///  
	/// Notice: if dataset is used, we can definite dimensions in dataset.dimensions , or provide dimension names in the first column/row of dataset.source , and not need to specify dimensions here.
	/// But if dimensions is specified here, it will be used despite the dimension definitions in dataset.
	///  
	/// For example:  option = {
	///     dataset: {
	///         source: [
	///             // 'date', 'open', 'close', 'highest', 'lowest'
	///             [12, 44, 55, 66, 2],
	///             [23, 6, 16, 23, 1],
	///             ...
	///         ]
	///     },
	///     series: {
	///         type: 'xxx',
	///         // Specify name for each dimesions, which will be displayed in tooltip.
	///         dimensions: ['date', 'open', 'close', 'highest', 'lowest']
	///     }
	/// }  series: {
	///     type: 'xxx',
	///     dimensions: [
	///         null,                // If you do not intent to defined this dimension, use null is fine.
	///         {type: 'ordinal'},   // Specify type of this dimension.
	///                              // 'ordinal' is always used in string.
	///                              // If type is not specified, echarts will guess type by data.
	///         {name: 'good', type: 'number'},
	///         'bad'                // Equals to {name: 'bad'}.
	///     ]
	/// }  
	/// Each data item of dimensions can be:   string , for example, 'someName' , which equals to {name: 'someName'} .
	///  Object , where the attributes can be:  name: string .
	///  type: string , supports:  number  float , that is, Float64Array  int , that is, Int32Array  ordinal , discrete value, which represents string generally.
	///  time , time value, see data to check the format of time value.
	///    displayName: string , generally used in tooltip for dimension display.
	/// If not specified, use name by default.
	///     
	/// When dimensions is specified, the default tooltip will be displayed vertically, which is better to show diemsion names.
	/// Otherwise, tooltip will displayed only value horizontally.
	/// </summary>
	[JsonPropertyName("dimensions")]
	public List<object>? Dimensions { get; set; } 

	//TODO: SourceHeader
	/// <summary>
	/// See the tutorial of data transform .
	/// </summary>
	[JsonPropertyName("transform")]
	public List<DatasetTransform>? Transform { get; set; } 

	/// <summary>
	/// Specify the input dataset for dataset.transform .
	/// If dataset.transform specified but both fromDatasetIndex and fromDatasetId are not specified, fromDatasetIndex: 0 will be used by default.
	///  
	/// See the tutorial of data transform .
	/// </summary>
	[JsonPropertyName("fromDatasetIndex")]
	public int? FromDatasetIndex { get; set; } 

	/// <summary>
	/// Specify the input dataset for dataset.transform .
	///  
	/// See the tutorial of data transform .
	/// </summary>
	[JsonPropertyName("fromDatasetId")]
	public string? FromDatasetId { get; set; } 

	/// <summary>
	/// If a dataset.transform produces more than one result, we can use fromTransformResult to retrieve some certain result.
	///  
	/// In most cases, fromTransformResult do not need to be specified because most transforms only produce one result.
	/// If fromTransformResult is not specified, we use fromTransformResult: 0 by default.
	///  
	/// See the tutorial of data transform .
	/// </summary>
	[JsonPropertyName("fromTransformResult")]
	public double? FromTransformResult { get; set; } 

}
