using System.Linq;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ActionController : ControllerBase
{
    [HttpGet]
    public ActionResult<Action> Get()
    {
        var actions = new[] { "AMZN", "CACC", "EQIX", "GOOG", "ORLY", "ULTA" };
        var prices = new[,]
        {
            { 12.81, 11.09, 12.11, 10.93, 9.83, 8.14 },
            { 10.34, 10.56, 10.14, 12.17, 13.1, 11.22 },
            { 11.53, 10.67, 10.42, 11.88, 11.77, 10.21 }
        };

        var avgPrices = new double[actions.Length];
        for (int i = 0; i < actions.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < prices.GetLength(1); j++)
            {
                sum += prices[i, j];
            }
            avgPrices[i] = sum / prices.GetLength(1);
        }

        int maxIndex = avgPrices.ToList().IndexOf(avgPrices.Max());

        return new Action
        {
            Name = actions[maxIndex],
            AvgPrice = avgPrices[maxIndex]
        };
    }
}

public class Action
{
    public string Name { get; set; }
    public double AvgPrice { get; set; }
}
