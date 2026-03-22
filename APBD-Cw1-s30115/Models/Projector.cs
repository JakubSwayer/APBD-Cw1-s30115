namespace APBD_Cw1_s30115.Models;

public class Projector(string name, string model, string manufacturer, string resolution, int brightness) : Equipment(name, model, manufacturer)
{
    public string resolution { get; set; } = resolution;
    public int brightness { get; set; } = brightness;
}