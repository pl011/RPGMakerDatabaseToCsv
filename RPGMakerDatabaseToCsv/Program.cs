﻿// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using RPGMakerDatabaseToCsv;

Console.WriteLine("Generating files...");

string dataFolder = "Data";
if (args.Length > 0)
{
    dataFolder = args[0];
}

var skillsData = JsonConvert.DeserializeObject<List<Skills>>(File.ReadAllText(Path.Combine(dataFolder, "Skills.json")));
var mapInfosData = JsonConvert.DeserializeObject<List<MapInfos>>(File.ReadAllText(Path.Combine(dataFolder, "MapInfos.json")));

using (StreamWriter outputFile = new StreamWriter("SkillsTable.csv"))
{
    outputFile.WriteLine("ID,Name");
    foreach (var result in skillsData)
    {
        if (result != null)
        {
            outputFile.WriteLine($"{result.id},{result.name}");
        }
    }
}

using (StreamWriter outputFile = new StreamWriter("SkillsTable.md"))
{
    outputFile.WriteLine("|ID|Name|");
    outputFile.WriteLine("|--|----|");
    foreach (var result in skillsData)
    {
        if (result != null)
        {
            outputFile.WriteLine($"|{result.id}|{result.name}|");
        }
    }
}

using (StreamWriter outputFile = new StreamWriter("MapInfosTable.csv"))
{
    outputFile.WriteLine("\"Map ID\",\"Name\",\"List Order\",\"Parent/linked to ID\"");
    foreach (var result in mapInfosData)
    {
        if (result != null)
        {
            outputFile.WriteLine($"{result.id},{result.name},{result.order},{result.parentId}");
        }
    }
}

using (StreamWriter outputFile = new StreamWriter("MapInfosTable.md"))
{
    outputFile.WriteLine("|Map ID|Name|List Order|Parent/linked to ID|");
    outputFile.WriteLine("|------|----|----------|-------------------|");
    foreach (var result in mapInfosData)
    {
        if (result != null)
        {
            outputFile.WriteLine($"|{result.id}|\"{result.name}\"|{result.order}|{result.parentId}");
        }
    }   
}


Console.WriteLine("Done!");
