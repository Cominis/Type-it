using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
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

    public static List<ThemeEventArgs> Themes { get; set; } = new List<ThemeEventArgs>()
    {
        new ThemeEventArgs(new Color32(255, 255, 255, 255), new Color32(0, 0, 0, 255)),
        new ThemeEventArgs(new Color32(0, 0, 0, 255), new Color32(255, 255, 255, 255)),
        new ThemeEventArgs(new Color32(255, 236, 0, 255), new Color32(255, 156, 0, 255)),
        new ThemeEventArgs(new Color32(102, 102, 102, 255), new Color32(51, 255, 0, 255)),
        new ThemeEventArgs(new Color32(244, 93, 102, 255), new Color32(102, 0, 153, 255)),
    };
}
