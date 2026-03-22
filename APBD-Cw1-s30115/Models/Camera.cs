namespace APBD_Cw1_s30115.Models;

public class Camera(string name, string model, string manufacturer, bool isMirrorless, string matrixResolution) : Equipment(name, model, manufacturer)
{
public bool IsMirrorless { get; set; } = isMirrorless;
public string MatrixResolution { get; set; } = matrixResolution;
}
