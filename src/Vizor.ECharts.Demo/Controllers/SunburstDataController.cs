using Microsoft.AspNetCore.Mvc;

namespace Vizor.ECharts.Demo.Controllers;

[ApiController]
public class SunburstDataController : ControllerBase
{
    private const string data = @"[
  {
    ""name"": ""Grandpa"",
    ""children"": [
      {
        ""name"": ""Uncle Leo"",
        ""value"": 15,
        ""children"": [
          {
            ""name"": ""Cousin Jack"",
            ""value"": 2
          },
          {
            ""name"": ""Cousin Mary"",
            ""value"": 5,
            ""children"": [
              {
                ""name"": ""Jackson"",
                ""value"": 2
              }
            ]
          },
          {
            ""name"": ""Cousin Ben"",
            ""value"": 4
          }
        ]
      },
      {
        ""name"": ""Father"",
        ""value"": 10,
        ""children"": [
          {
            ""name"": ""Me"",
            ""value"": 5
          },
          {
            ""name"": ""Brother Peter"",
            ""value"": 1
          }
        ]
      }
    ]
  },
  {
    ""name"": ""Nancy"",
    ""children"": [
      {
        ""name"": ""Uncle Nike"",
        ""children"": [
          {
            ""name"": ""Cousin Betty"",
            ""value"": 1
          },
          {
            ""name"": ""Cousin Jenny"",
            ""value"": 2
          }
        ]
      }
    ]
  }
]";

    [HttpGet("data/sunburst/simple")]
    public ActionResult List()
    {
        return Content(data, "application/json");
    }
}
