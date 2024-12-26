// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using RPGMakerDatabaseToCsv;

Console.WriteLine("Hello, World!");

var results = JsonConvert.DeserializeObject<List<Skills>>(File.ReadAllText(args[0]));

using (StreamWriter outputFile = new StreamWriter("SkillsTable.txt"))
{
    outputFile.WriteLine("|ID|Name|");
    outputFile.WriteLine("|--|----|");
    foreach (var result in results)
    {
        if (result != null)
        {
            outputFile.WriteLine($"|{result.id}|{result.name}|");
        }
    }
}

Console.WriteLine("Goodbye!");
