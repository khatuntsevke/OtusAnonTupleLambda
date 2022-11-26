Program1();
Program2();
Program3();
Program3WithStar();

void Program1()
{
    var venus = new
    {
        nameOfThePlanet = "Венера",
        serialNumberFromTheSun = 2,
        equatorLength = 38025,
        previousPlanet = null as object,
    };

    var earth = new
    {
        nameOfThePlanet = "Земля",
        serialNumberFromTheSun = 3,
        equatorLength = 40075,
        previousPlanet = venus as object,
    };

    var mars = new
    {
        nameOfThePlanet = "Марс",
        serialNumberFromTheSun = 4,
        equatorLength = 21343,
        previousPlanet = earth as object,
    };

    var venus2 = new
    {
        nameOfThePlanet = "Венера",
        serialNumberFromTheSun = 2,
        equatorLength = 38025,
        previousPlanet = null as object,
    };

    var eq = venus2 == venus;

    Console.WriteLine("=== Программа 1 ===");
    Console.WriteLine($"{venus}\nIsEqualVenus = {venus.Equals(venus)}");
    Console.WriteLine($"{earth}\nIsEqualVenus = {earth.Equals(venus)}");
    Console.WriteLine($"{mars}\nIsEqualVenus = {mars.Equals(venus)}");
    Console.WriteLine($"{venus2}\nIsEqualVenus = {venus2.Equals(venus)}");    
}

void Program2()
{
    Console.WriteLine("\n=== Программа 2 ===");
    
    var pCatalog = new PlanetCatalog();
    var names = new List<string> { "Земля", "Лимония", "Марс" };

    foreach(string nameOfPlanet in names)
    {
        var (serialNumber, equatorLength, errorMsg) = pCatalog.GetPlanet(nameOfPlanet);
        Console.WriteLine($"Планета - {nameOfPlanet}\n" +
            $"Порядковый номер от Солнца - {serialNumber}\n" +
            $"Длина экватора - {equatorLength}\n" +
            $"Ошибка при запросе в каталог - {errorMsg}\n");
    }
}

void Program3()
{
    Console.WriteLine("\n=== Программа 3 ===");

    var pCatalog = new PlanetCatalog();
    var names = new List<string> { "Земля", "Лимония", "Марс" };

    int counter = 0;

    Func<string, string> lambda = (string nameOfPlanet) =>
    {
        counter++;
        if (counter == 3)
        {
            return "Вы спрашиваете слишком часто";
        }
        return "";
    };

    foreach (string nameOfPlanet in names)
    {
        var (serialNumber, equatorLength, errorMsg) = pCatalog.GetPlanetWithValidator(nameOfPlanet, lambda );
        Console.WriteLine($"Планета - {nameOfPlanet}\n" +
            $"Порядковый номер от Солнца - {serialNumber}\n" +
            $"Длина экватора - {equatorLength}\n" +
            $"Ошибка при запросе в каталог - {errorMsg}\n");
    }
}

void Program3WithStar()
{
    Console.WriteLine("\n=== Программа 3* ===");

    var pCatalog = new PlanetCatalog();
    var names = new List<string> { "Земля", "Лимония", "Марс" };    

    Func<string, string?> lambda = (string nameOfPlanet) =>
    {        
        if (nameOfPlanet == "Лимония")
        {
            return "Это запретная планета";
        }
        return null;
    };

    foreach (string nameOfPlanet in names)
    {
        var (serialNumber, equatorLength, errorMsg) = pCatalog.GetPlanetWithValidator(nameOfPlanet, lambda);
        Console.WriteLine($"Планета - {nameOfPlanet}\n" +
            $"Порядковый номер от Солнца - {serialNumber}\n" +
            $"Длина экватора - {equatorLength}\n" +
            $"Ошибка при запросе в каталог - {errorMsg}\n");
    }
}

