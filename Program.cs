List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Primera erupcion en Chile
int firstEriptionChile = eruptions.Where(l => l.Location == "Chile").Min(eruption => eruption.Year);
Console.WriteLine($"La primera erupcion en Chile fue en el año {firstEriptionChile}");

//Encuentre la primera erupción en la ubicación de "Hawaiian Is" e imprímala. Si no se encuentra ninguno, imprima "No se encontró ninguna erupción hawaiana".
var firstEriptionHawaiian = eruptions.FirstOrDefault(eruption => eruption.Location == "Hawaiian Is");
if (firstEriptionHawaiian != null)
{
    Console.WriteLine($"La primera erupcion en Hawaiian fue en el año {firstEriptionHawaiian.Year}");
}
else
{
    Console.WriteLine($"No se encontró ninguna erupción hawaiana");
}

//Busque la primera erupción posterior al año 1900 Y en "Nueva Zelanda", luego imprímala.
int year = 1900;
var firstEriptionNZ = eruptions.FirstOrDefault(eruption => eruption.Location == "New Zealand" && eruption.Year > year);

Console.WriteLine($"La primera erupcion en Nueva Zelanda posterior al año {year} fue en el año {firstEriptionNZ.Year}");


// Encuentra todas las erupciones donde la elevación del volcán sea superior a 2000 m e imprímelas.
IEnumerable<Eruption> ElevationEruptions = eruptions.Where(eruption => eruption.ElevationInMeters > 2000);
PrintEach(ElevationEruptions, "Erupciones con elevación superior a 2000 m:");


// Encuentra todas las erupciones donde el nombre del volcán comienza con "L" e imprímelas. Imprime también el número de erupciones encontradas.
IEnumerable<Eruption> lVolcanoes = eruptions.Where(eruption => eruption.Volcano.StartsWith("L"));
PrintEach(lVolcanoes, "Erupciones cuyo nombre comienza con 'L':");
Console.WriteLine($"Número de erupciones que comienzan con 'L': {lVolcanoes.Count()}");


// // Encuentra la elevación más alta e imprime solo ese número entero
int maxElevation = eruptions.Max(eruption => eruption.ElevationInMeters);
Console.WriteLine($"Elevación más alta: {maxElevation} m");

//  Utiliza la variable de elevación más alta para buscar e imprimir el nombre del volcán con esa elevación
var volcanoWithMaxElevation = eruptions.FirstOrDefault(eruption => eruption.ElevationInMeters == maxElevation);
Console.WriteLine($"Volcán con la elevación más alta ({maxElevation} m): {volcanoWithMaxElevation.Volcano}");


// Imprime todos los nombres de los volcanes alfabéticamente
IEnumerable<Eruption> sortedVolcanoNames = eruptions.OrderBy(eruption => eruption.Volcano);
PrintEach(sortedVolcanoNames, "Nombres de los volcanes en orden alfabético:");


// Imprime todas las erupciones que ocurrieron antes del año 1000 EC en orden alfabético según el nombre del volcán
IEnumerable<Eruption> ancientEruptions = eruptions.Where(eruption => eruption.Year < 1000).OrderBy(eruption => eruption.Volcano);
PrintEach(ancientEruptions, "Erupciones que ocurrieron antes del año 1000 EC en orden alfabético por nombre del volcán:");


// BONIFICACIÓN: Rehacer la última consulta para imprimir solo el nombre del volcán
IEnumerable<string> ancientVolcanoNames = ancientEruptions.Select(eruption => eruption.Volcano);
PrintEach(ancientVolcanoNames, "Nombres de los volcanes en erupciones que ocurrieron antes del año 1000 EC:");


// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
