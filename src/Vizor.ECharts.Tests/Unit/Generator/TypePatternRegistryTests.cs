using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.Tests.Unit.Generator;

/// <summary>
/// Tests for TypePatternRegistry - the central registry of type mapping patterns.
/// </summary>
[TestClass]
public class TypePatternRegistryTests
{
    private TypePatternRegistry registry = null!;
    private TypeCollection typeCollection = null!;
    
    [TestInitialize]
    public void Setup()
    {
        typeCollection = new TypeCollection();
        registry = new TypePatternRegistry(typeCollection);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsFalseForNull()
    {
        var result = registry.TryGetMappedType(null!, "TestType", out var mappedType);
        
        Assert.IsFalse(result);
        Assert.IsNull(mappedType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsFalseForEmptyList()
    {
        var result = registry.TryGetMappedType(new List<string>(), "TestType", out var mappedType);
        
        Assert.IsFalse(result);
        Assert.IsNull(mappedType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForPrimitiveString()
    {
        var result = registry.TryGetMappedType(new List<string> { "string" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("string", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForPrimitiveNumber()
    {
        var result = registry.TryGetMappedType(new List<string> { "number" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("double", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForPrimitiveBoolean()
    {
        var result = registry.TryGetMappedType(new List<string> { "boolean" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("bool", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForColor()
    {
        var result = registry.TryGetMappedType(new List<string> { "color" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("Color", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForFunction()
    {
        var result = registry.TryGetMappedType(new List<string> { "function" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("JavascriptFunction", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsFalseForUnmappedSingleType()
    {
        var result = registry.TryGetMappedType(new List<string> { "enum" }, "TestType", out var mappedType);
        
        // enum is not handled by TryGetMappedType - needs separate handling
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForNumberOrBool()
    {
        var result = registry.TryGetMappedType(new List<string> { "boolean", "number" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("NumberOrBool", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForBoolOrString()
    {
        var result = registry.TryGetMappedType(new List<string> { "boolean", "string" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("BoolOrString", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForNumberOrString()
    {
        var result = registry.TryGetMappedType(new List<string> { "number", "string" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("NumberOrString", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_ReturnsTrueForStringOrFunction()
    {
        var result = registry.TryGetMappedType(new List<string> { "function", "string" }, "TestType", out var mappedType);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(mappedType);
        Assert.AreEqual("StringOrFunction", mappedType.DotNetType);
    }
    
    [TestMethod]
    public void TryGetMappedType_HandlesOrderIndependently()
    {
        // Test that "boolean,number" and "number,boolean" map to the same type
        var result1 = registry.TryGetMappedType(new List<string> { "boolean", "number" }, "Type1", out var mapped1);
        var result2 = registry.TryGetMappedType(new List<string> { "number", "boolean" }, "Type2", out var mapped2);
        
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.AreEqual(mapped1?.DotNetType, mapped2?.DotNetType);
    }
    
    [TestMethod]
    public void IsPartiallySupported_ReturnsFalseForNull()
    {
        var result = registry.IsPartiallySupported(null!);
        
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void IsPartiallySupported_ReturnsTrueForEnumFunction()
    {
        var result = registry.IsPartiallySupported(new List<string> { "enum", "function" });
        
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void IsPartiallySupported_ReturnsFalseForOtherPatterns()
    {
        var result = registry.IsPartiallySupported(new List<string> { "string", "number" });
        
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void IsPartiallySupported_HandlesOrderIndependently()
    {
        var result1 = registry.IsPartiallySupported(new List<string> { "enum", "function" });
        var result2 = registry.IsPartiallySupported(new List<string> { "function", "enum" });
        
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
    }
    
    [TestMethod]
    public void IsTrulyUnsupported_ReturnsFalseForNull()
    {
        var result = registry.IsTrulyUnsupported(null!, out var reason);
        
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void IsTrulyUnsupported_ReturnsTrueForWildcardNumber()
    {
        var result = registry.IsTrulyUnsupported(new List<string> { "*", "number" }, out var reason);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(reason);
        Assert.Contains("ambiguous", reason);
    }
    
    [TestMethod]
    public void IsTrulyUnsupported_ReturnsTrueForDateObjectNumberString()
    {
        var result = registry.IsTrulyUnsupported(
            new List<string> { "date", "object", "number", "string" },
            out var reason);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(reason);
    }
    
    [TestMethod]
    public void IsTrulyUnsupported_ReturnsFalseForSupportedPatterns()
    {
        var result = registry.IsTrulyUnsupported(new List<string> { "string", "number" }, out var reason);
        
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void GetAllSupportedPatternKeys_ReturnsNonEmptyCollection()
    {
        var keys = registry.GetAllSupportedPatternKeys().ToList();
        
        Assert.IsNotEmpty(keys);
        Assert.IsTrue(keys.Any(k => k.Contains("number") && k.Contains("string")));
    }
    
    [TestMethod]
    public void GenerateSuggestion_ReturnsNullForNull()
    {
        var suggestion = registry.GenerateSuggestion(null!);
        
        Assert.IsNull(suggestion);
    }
    
    [TestMethod]
    public void GenerateSuggestion_ReturnsSuggestionFor2ElementUnion()
    {
        var suggestion = registry.GenerateSuggestion(new List<string> { "array", "enum" });
        
        Assert.IsNotNull(suggestion);
        Assert.Contains("create custom", suggestion, StringComparison.OrdinalIgnoreCase);
    }
    
    [TestMethod]
    public void GenerateSuggestion_ReturnsSuggestionFor3PlusElements()
    {
        var suggestion = registry.GenerateSuggestion(new List<string> { "array", "enum", "number" });
        
        Assert.IsNotNull(suggestion);
        Assert.Contains("complex", suggestion, StringComparison.OrdinalIgnoreCase);
    }
    
    [TestMethod]
    public void GenerateSuggestion_ReturnsSuggestionForEnumWithValues()
    {
        var suggestion = registry.GenerateSuggestion(
            new List<string> { "enum" },
            "solid,dashed,dotted");
        
        Assert.IsNotNull(suggestion);
        Assert.Contains("Add enum", suggestion, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("MappedEnumType", suggestion);
    }
}
