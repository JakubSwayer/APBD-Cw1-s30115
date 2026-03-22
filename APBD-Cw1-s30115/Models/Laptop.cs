namespace APBD_Cw1_s30115.Models;

public class Laptop(string name, string model, string manufacturer, string operatingSystem, string screenResolution) : Equipment(name, model, manufacturer)
{
    public string OperatingSystem { get; set; } = operatingSystem;
    public string ScreenResolution { get; set; } = screenResolution;
}