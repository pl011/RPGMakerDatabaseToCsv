// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using RPGMakerDatabaseToCsv;

Console.WriteLine("Hello, World!");

var result = JsonConvert.DeserializeObject<List<Skills>>(File.ReadAllText(args[0]));

Console.WriteLine("Goodbye!");
