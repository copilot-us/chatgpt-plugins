using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        string inputFile = @"C:\Users\alex\Downloads\chatgpt.txt";
        string outputFile = @"C:\Users\alex\Downloads\output.txt";

        // Read the JSON data from the file
        string json = File.ReadAllText(inputFile);

        // Parse the JSON
        var data = JObject.Parse(json);

        // Get the "items" array
        var items = data["items"];

        // Create a string builder to build the markdown table
        var markdownBuilder = new System.Text.StringBuilder();

        // Add the table header
        markdownBuilder.AppendLine("| Index | Domain | Name for Human | Description for Model | Description for Human | Logo URL | Contact Email |");
        markdownBuilder.AppendLine("|-------|--------|----------------|-----------------------|-----------------------|----------|---------------|");

        // Add rows to the table
        int index = 1;
        foreach (var item in items)
        {
            // Extract field values from the JSON
            string domain = item.Value<string>("domain");
            string nameForHuman = item["manifest"]["name_for_human"].Value<string>();
            string descriptionForModel = EncodeNewLines(item["manifest"]["description_for_model"].Value<string>());
            string descriptionForHuman = EncodeNewLines(item["manifest"]["description_for_human"].Value<string>());
            string logoUrl = item["manifest"]["logo_url"].Value<string>();
            string contactEmail = item["manifest"]["contact_email"].Value<string>();

            // Append the row to the markdown table
            markdownBuilder.AppendLine($"| {index} | {domain} | {nameForHuman} | {descriptionForModel} | {descriptionForHuman} | ![Logo]({logoUrl}) | {contactEmail} |");

            index++;
        }

        // Write the markdown table to the output file
        File.WriteAllText(outputFile, markdownBuilder.ToString());

        Console.WriteLine("Conversion complete.");
    }

    static string EncodeNewLines(string input)
    {
        return input.Replace("\n", "\\n").Replace("\r", "\\r");
    }
}
