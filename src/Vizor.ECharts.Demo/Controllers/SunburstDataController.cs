using Microsoft.AspNetCore.Mvc;

namespace Vizor.ECharts.Demo.Controllers;

[ApiController]
public class SunburstDataController : ControllerBase
{
    private const string data = @"
[
    {
        'children': [
            {
                'children': [
                    {
                        'name': 'Cousin Jack',
                        'value': 2
                    },
                    {
                        'children': [
                            {
                                'name': 'Jackson',
                                'value': 2
                            }
                        ],
                        'name': 'Cousin Mary',
                        'value': 5
                    },
                    {
                        'name': 'Cousin Ben',
                        'value': 4
                    }
                ],
                'name': 'Uncle Leo',
                'value': 15
            },
            {
                'children': [
                    {
                        'name': 'Me',
                        'value': 5
                    },
                    {
                        'name': 'Brother Peter',
                        'value': 1
                    }
                ],
                'name': 'Father',
                'value': 10
            }
        ],
        'name': 'Grandpa'
    },
    {
        'children': [
            {
                'children': [
                    {
                        'name': 'Cousin Betty',
                        'value': 1
                    },
                    {
                        'name': 'Cousin Jenny',
                        'value': 2
                    }
                ],
                'name': 'Uncle Nike'
            }
        ],
        'name': 'Nancy'
    }
]
";

    [HttpGet("data/sunburst/sample1")]
    public ActionResult List()
    {
        return Content(data, "application/json");
    }
}
