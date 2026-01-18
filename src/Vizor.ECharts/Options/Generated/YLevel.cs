// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class YLevel
{
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

}
