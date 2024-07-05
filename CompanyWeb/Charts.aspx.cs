using System;
using System.Collections.Generic;
using System.Web.UI;

namespace YourNamespace
{
    public partial class BarChart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Sample data for the bar chart
                List<int> data = new List<int> { 20, 30, 40, 50, 60 };

                // Generate x-axis labels (e.g., categories)
                List<string> labels = new List<string> { "Category 1", "Category 2", "Category 3", "Category 4", "Category 5" };

                // Create a Plotly trace for the bar chart
                var trace = new
                {
                    x = labels.ToArray(),
                    y = data.ToArray(),
                    type = "bar",
                    marker = new { color = "#007bff" } // Bar color (blue)
                };

                // Convert the trace to an array
                object[] chartData = { trace };

                // Render the Plotly chart
                string chartScript = $"<script>Plotly.newPlot('chartContainer', {Newtonsoft.Json.JsonConvert.SerializeObject(chartData)});</script>";
                Page.ClientScript.RegisterStartupScript(GetType(), "BarChart", chartScript, false);
            }
        }
    }
}
