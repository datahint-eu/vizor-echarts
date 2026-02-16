// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Y
{
    /// <summary>
    /// Since v6.0.0   
    /// Determines whether to display the header row(in matrix.x )/column(in matrix.y ).
    /// </summary>
    [JsonPropertyName("show")]
    [DefaultValue(true)]
    public bool? Show { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specifies the data for the y-axis cells.
    /// i.e., defined the column/row.
    ///  // Data for a single row
    /// data: ['A', 'B', 'C', 'D', 'E']
    /// 
    /// // Or if column/row names is not of concern, simply
    /// data: Array(5).fill(null) // Five columns or rows
    /// // Note: DO NOT support array with empty slots：
    /// // data: Array(5) // ❌
    /// 
    /// // Data in a tree structure
    /// data: [{
    ///     value: 'A',
    ///     children: [
    ///         {
    ///             value: 'A1',
    ///             children: [
    ///                 {value: 'A1-1'},
    ///                 {value: 'A1-2'}
    ///             ]
    ///         },
    ///         {value: 'A2'}
    ///     ]
    /// }, {
    ///     value: 'B',
    ///     children: [
    ///         {value: 'B1'},
    ///         {value: 'B2'}
    ///     ]
    /// }]  
    /// If matrix.y.data is not provided, it will be collected from series.data or dataset.soruce .
    ///  
    /// See matrix data collection example .
    ///  
    /// And in this case series.encode can be used to specify the dimension from which value is collected.
    /// For example,  var option = {
    ///     // no matrix.x/y.data is specified;
    ///     // so collect from series.data or dataset.source (if any)
    ///     matrix: {},
    ///     series: {
    ///         type: 'scatter',
    ///         coordinateSystem: 'matrix',
    ///         // Collect values from dimension index 3 and 2.
    ///         encode: {x: 3, y: 2},
    ///         data: [
    ///             // 0   1    2    3    (dimension index)
    ///             [100, 111, 122, 133],
    ///             [200, 211, 222, 233],
    ///         ]
    ///     }
    /// }
    /// ]]>
    /// </summary>
    [JsonPropertyName("data")]
    public List<YData>? Data { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Text label of y-axis cells, to explain some data information about graphic item like value, name and so on.
    /// label is placed under itemStyle in ECharts 2.x.
    /// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Graphic style of y-axis cells, emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// Whether to ignore mouse events.
    /// Default value is false, for triggering and responding to mouse events.
    /// </summary>
    [JsonPropertyName("silent")]
    [DefaultValue(false)]
    public bool? Silent { get; set; } 

    /// <summary>
    /// Mouse cursor when hovering on the cell.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; } 

    /// <summary>
    /// Specify the z-index (z-order) of the cell.
    /// Used when style conflict - especially for thick border style.
    /// </summary>
    [JsonPropertyName("z2")]
    public double? Z2 { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// [[The rule of cell size]]   option levelSize  It specifies the size of all cells in a row or a column.
    ///  For matrix.x , it refers to the cell height of a row ("level" refers to a row).
    ///  For matrix.y , it refers to the cell width of a column ("level" refers to a column).
    ///    It can be declared in:  matrix.levelSize specifies the default size of every columns or rows.
    ///  matrix.levels[i].levelSize specifies the size of a certain column or row.
    ///      option size  It specifies the size of a single cell.
    ///  For matrix.x , it refers to the cell width.
    ///  For matrix.y , it refers to the cell height.
    ///    It can be declared in:  matrix.x/y.data[i].size       
    /// The value of levelSize or size can be:   Unspecified(default): The width or height is evenly distributed.
    ///  number : Represents pixel value.
    ///  string : Percentage value (e.g., '33%' ), representing the percentage relative to the width (in matrix.x ) or height (in matrix.y ) of the matrix.
    ///   
    /// For example:  {
    ///     matrix: {
    ///         x: {
    ///             // The height of the second row is 10% of the matrix width,
    ///             levels: [undefined, {levelSize: '10%'}]
    ///             // And the other row height are evenly distributed.
    ///             levelSize: undefined,
    ///             data: [
    ///                 {
    ///                     // The width of the first cell is 30 pixel.
    ///                     size: 30
    ///                 },
    ///                 // And the other cell width are evenly distributed.
    ///                 // ...
    ///             ]
    ///         },
    ///         y: {
    ///             // The width of the second column is 10% of the matrix width,
    ///             levels: [undefined, {levelSize: '10%'}]
    ///             // And the other column width are evenly distributed.
    ///             levelSize: undefined,
    ///             data: [
    ///                 {
    ///                     // The height of the first cell is 30 pixel.
    ///                     size: 30
    ///                 },
    ///                 // And the other cell height are evenly distributed.
    ///                 // ...
    ///             ]
    ///         },
    ///         // ...
    ///     },
    /// }
    /// ]]>
    /// </summary>
    [JsonPropertyName("levelSize")]
    public NumberOrString? LevelSize { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Settings for each column(in matrix.x ) or row(in matrix.y ).
    /// The first element represents the first column/row, and so on.
    ///   If any item in the array is null / undefined , it means using the default value.
    ///  Otherwise any item in the array should be an object, such as {levelSize: number} .
    ///   
    /// For example  matrix: {
    ///     x: {
    ///         level: [null, {levelSize: '20%'}]
    ///         // The second column width should be 20% of
    ///         // the matrix width.
    ///         // The first column has no specific setting.
    ///     },
    ///     // ...
    /// },
    /// ]]>
    /// </summary>
    [JsonPropertyName("levels")]
    public List<YLevel>? Levels { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Header divider line style.
    /// </summary>
    [JsonPropertyName("dividerLineStyle")]
    public DividerLineStyle? DividerLineStyle { get; set; } 

}
