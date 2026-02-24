// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class CornerData
{
    /// <summary>
    /// <![CDATA[
    /// Body/Corner Cell Locating  
    /// The rule is uniformly applied, such as, in matrix.dataToPoint and matrix.dataToLayout and xxxComponent.coord .
    ///  
    /// Suppose the matrix.x/y dimensions (header) are defined as:  matrix: {
    ///     x: [{ value: 'Xa0', children: ['Xb0', 'Xb1'] }, 'Xa1'],
    ///     y: [{ value: 'Ya0', children: ['Yb0', 'Yb1'] }],
    /// }  -----------------------------------------
    ///  |       |       |     Xa0       |       |
    ///  |-------+-------+---------------|  Xa1  |
    ///  |cornerQ|cornerP|  Xb0  |  Xb1  |       |
    ///  |-------+-------+-------+-------+--------
    ///  |       |  Yb0  | bodyR | bodyS |       |
    ///  |  Ya0  |-------+-------+---------------|
    ///  |       |  Yb1  |       |     bodyT     |
    ///  |---------------|------------------------  Locator number :  The term locator refers to a integer number to locate cells on x or y direction.
    ///  Use the top-left cell of the body as the origin point (0, 0) ,  the non-negative locator indicates the right/bottom of the origin point;  the negative locator indicates the left/top of the origin point.
    ///      Ordinal number ( OrdinalNumber ):  This term follows the same meaning as that in category axis of cartesian.
    /// They are non-negative integer, designating each string matrix.x.data[i].value / matrix.y.data[i].value .
    /// 'Xb0' , 'Xb2' , 'Xa1' , 'Xa0' are assigned with the ordinal numbers 0 , 1 , 2 , 3 .
    /// For every leaf dimension cell, OrdinalNumber and MatrixXYLocator is the same.
    ///    A single cell or multiple cells can be determined/located by an array of locator number or ordinal number or the original value string as follows:  e.g., the body cell bodyS above can be located by:  coord: [1, 0] (Use non-negative integer)  coord: ['Xb1', 'Yb0'] (Use the value properties in matrix.x/y.data )  coord: ['Xb1', 0] (mix them)    e.g., the corner cell cornerQ above can be located by:  coord: [-2, -1] (negative MatrixXYLocator )  But it is NOT supported to use coord: ['Y1_0', 'X1_0'] (XY transposed form) here.
    ///    The dimension (header) cell can be located by negative integers.
    /// For example:  The center of the node 'Ya0' can be located by [-2, 'Ya0'] .
    ///    Cross cells: multiple cells can be located.
    /// e.g., if using [['Xb0', 'Xb1'], ['Yb0']] , or using a non-leaf dimension cell to locate, such as ['Xa0', 'Yb0'] , it returns only according to the center of the dimension cells, regardless of the body span.
    /// (therefore, the result can be on the boundary of two body cells.) And the ordinal number assigned to 'Xa0' is 3, thus input [3, 'Yb0'] get the some result.
    ///    In a nutshell, The formatter of matrix.data.coord is as follows:  [2, 8] indicates a cell.
    ///  [[2, 5], 8] indicates a rect of cells in x range of 2~5 and y 8 .
    ///  [[2, 5], [7, 8]] indicates a rect of cells in x range of 2~5 and y range of 7~8 .
    ///  ['aNonLeaf', 8] indicates a rect of cells in x range of aNonLeaf and y 8 .
    ///  [2, null/undefined/NaN] means y is the entire column (only work on coordClamp: true ).
    ///  [null/undefined/NaN, 8] is the opposite (only work on coordClamp: true ).
    ///  [[2, 5], null/undefined/NaN] indicates a x range of 2~5 and y is the entire column (only work on coordClamp: true )..
    ///    
    /// NOTICE   bodyR above is [0, 0] **.
    ///  The formatter of matrix.data.coord is MatrixCoordRangeOption[] as follows.
    ///    
    /// The API dataToPoint and dataToLayout also uses this locating rule:   Input ['Xa1', 'Yb1'] to dataToPoint will get a point in the center of "bodyT".
    ///  Input ['Xa1', 'Yb1'] to dataToLayout will get a rect of the "bodyT".
    /// ]]>
    /// </summary>
    [JsonPropertyName("coord")]
    //TODO: Type Warning: array type 'coord' in 'cornerData' will be mapped to List<object>
    public List<object>? Coord { get; set; } 

    /// <summary>
    /// true : matrix.body/corner.data[i].coord can use [null/undefined/NaN/invalid_values, xxx] or [xxx, null/undefined/NaN/invalid_values] to refer to a entire row/column.
    ///  false : Disallow that.
    /// And an error message will be printed in dev mode when such values are used.
    /// </summary>
    [JsonPropertyName("coordClamp")]
    public bool? CoordClamp { get; set; } 

    /// <summary>
    /// Body cells or corner cells can be merged.
    /// </summary>
    [JsonPropertyName("mergeCells")]
    public bool? MergeCells { get; set; } 

    /// <summary>
    /// Text to display in the cell.
    /// </summary>
    [JsonPropertyName("value")]
    public NumberOrString? Value { get; set; } 

}
