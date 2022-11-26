using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

class Planet
{    
    public string Name { get; set; }
    public int SerialNumber { get; set; }
    public int EquatorLength { get; set; }
    public Planet? Previous { get; set; }
}

class PlanetCatalog
{
    int _requestCounter;
    List<Planet> _body;

    public PlanetCatalog()
    {
        _requestCounter = 0;

        Planet venus = new Planet();
        venus.Name = "Венера";
        venus.SerialNumber = 2;
        venus.EquatorLength = 38025;
        venus.Previous = null;

        Planet earth = new Planet();
        earth.Name = "Земля";
        earth.SerialNumber = 3;
        earth.EquatorLength = 40075;
        earth.Previous = earth;

        Planet mars = new Planet();
        mars.Name = "Марс";
        mars.SerialNumber = 4;
        mars.EquatorLength = 21343;
        mars.Previous = earth;

        _body = new List<Planet>(3);
        _body.Add(venus);
        _body.Add(earth);
        _body.Add(mars);
    }

    public (int serialNumber, int equatorLength, string? errorMsg) GetPlanet(string targetName)
    {
        _requestCounter++;
        string? errorMsg = null;
        if (_requestCounter == 3)
        {
            errorMsg = "Вы спрашиваете слишком часто";
            _requestCounter = 0;
        }
        
        if (!string.IsNullOrEmpty(errorMsg))
        {
            return (serialNumber: -1, equatorLength: -1, errorMsg: errorMsg);
        }

        foreach (var planet in _body)
        {
            if (planet.Name == targetName)
            {                
                return (serialNumber: planet.SerialNumber, equatorLength: planet.EquatorLength, errorMsg: errorMsg);
            }
        }
        return (serialNumber: -1, equatorLength: -1, errorMsg: "Не удалось найти планету");
    }

    public (int serialNumber, int equatorLength, string? errorMsg) GetPlanetWithValidator(string targetName, Func<string, string?> PlanetValidator)
    {
        string? errorMsg = PlanetValidator(targetName);
        
        if (!string.IsNullOrEmpty(errorMsg))
        {
            return (serialNumber: -1, equatorLength: -1, errorMsg: errorMsg);
        }

        foreach (var planet in _body)
        {
            if (planet.Name == targetName)
            {
                return (serialNumber: planet.SerialNumber, equatorLength: planet.EquatorLength, errorMsg: errorMsg);
            }
        }
        return (serialNumber: -1, equatorLength: -1, errorMsg: "Не удалось найти планету");
    }
}