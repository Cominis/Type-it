using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public const string FREE_LETTER = "FreeLetter";
    public const string LOCKED_LETTER = "LockedLetter";
    public const string PLAYER = "Player";
    public const string WALL = "Wall";

    public static string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static KeyCode[] AcceptableKeys { get; } = new KeyCode[]
    {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z,
    };

    public static List<Theme> Themes { get; set; } = new List<Theme>()
    {
        new Theme(0x660099, 0xffffff),
        new Theme(0x44ffee, 0x22aa33),
    };
}

public class Theme
{
    public int BackgroundColor { get; set; }
    public int TextColor { get; set; }

    public Theme(int backgroundColor, int textColor)
    {
        BackgroundColor = backgroundColor;
        TextColor = textColor;
    }
}
