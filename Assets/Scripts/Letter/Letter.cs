using UnityEngine;

public class Letter : MonoBehaviour
{
    public bool IsUpperCase { get; set; }
    public FontStyle Style { get; set; }
    public Color Color { get; set; }
    public string Font { get; set; }

    public Letter(string fontName, Color color, FontStyle fontStyle, bool isUpperCase)
    {
        IsUpperCase = isUpperCase;
        Style = fontStyle;
        Color = color;
        Font = fontName;
    }

}
