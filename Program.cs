using LiteDB;
using JsonSerializer = System.Text.Json.JsonSerializer;

try
{
    if (args.Length <= 0)
        throw new Exception("No file provided.");

    string inputFilePath = args[0];
    if (!File.Exists(inputFilePath))
        throw new Exception($"File '{inputFilePath}' does not exist.");

    HashSet<string> seen = [];
    List<FigureModel> wardrobe = [];

    using (var db = new LiteRepository(inputFilePath))
    {
        foreach (var figure in db.Query<FigureModel>().ToArray())
        {
            if (seen.Add(figure.FigureString))
                wardrobe.Add(figure);
        }
    }

    if (wardrobe.Count == 0)
        throw new Exception("No figures in database.");

    Console.WriteLine($"Loaded {wardrobe.Count} figures from '{inputFilePath}'.");

    string outputFilePath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "xabbo", "wardrobe.json");

    if (File.Exists(outputFilePath))
    {
        var existingWardrobe = JsonSerializer.Deserialize<List<FigureModel>>(File.ReadAllText(outputFilePath), JsonContext.Default.ListFigureModel);
        if (existingWardrobe is not null)
        {
            int mergeCount = 0;
            foreach (var figure in existingWardrobe)
            {
                if (seen.Add(figure.FigureString))
                {
                    mergeCount++;
                    wardrobe.Add(figure);
                }
            }
            if (mergeCount > 0)
                Console.WriteLine($"Merged {mergeCount} figures from existing wardrobe.");
        }
    }

    File.WriteAllText(outputFilePath, JsonSerializer.Serialize(wardrobe, JsonContext.Default.ListFigureModel));
    Console.WriteLine($"Wrote {wardrobe.Count} figures to '{outputFilePath}'.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Environment.Exit(1);
}
