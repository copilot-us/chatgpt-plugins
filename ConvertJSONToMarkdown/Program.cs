using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        string url = "https://github.com/jopilot-net/jopilot-4-job-seekers/raw/main/chatgpt_plugins.json";
        string outputFile = Path.Combine(Environment.CurrentDirectory, "output.txt");

        // Download the JSON data from the URL
        string jsonData;
        using (WebClient client = new WebClient())
        {
            jsonData = client.DownloadString(url);
        }

        // Parse the JSON data
        JObject jsonObject = JObject.Parse(jsonData);
        JArray itemsArray = (JArray)jsonObject["items"];

        // Create a StringBuilder to store the markdown table
        var markdownBuilder = new System.Text.StringBuilder();

        // Add the table header
        markdownBuilder.AppendLine("| Index | Name for Human | Domain  | Logo | Desc for Human |");
        markdownBuilder.AppendLine("|-------|----------------|---------|------|----------------|");

        // Iterate over each item and add a row to the table
        for (int i = 0; i < itemsArray.Count; i++)
        {
            JObject item = (JObject)itemsArray[i];

            // Get the values for each column
            string index = (i + 1).ToString();
            string logoUrl = $"![Logo]({item["manifest"]["logo_url"]})";
            string nameForHuman = item["manifest"]["name_for_human"].ToString().Replace("\n", "\\n");
            string domain = item["domain"].ToString().Replace("\n", "\\n");
            string descriptionForHuman = item["manifest"]["description_for_human"].ToString().Replace("\n", "\\n");

            // Add the row to the markdown table
            markdownBuilder.AppendLine($"| {index} | {nameForHuman} | {domain} | {logoUrl} | {descriptionForHuman}");
        }

        // Write the markdown table to the output file
        File.WriteAllText(outputFile, markdownBuilder.ToString());

        // Print the full output file path to the console
        Console.WriteLine("Output file path: " + outputFile);
    }
}
