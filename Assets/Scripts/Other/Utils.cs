using System.Collections;
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
        new ThemeEventArgs(new Color32(40, 74, 99, 255), new Color32(79, 209, 185, 255)),
        new ThemeEventArgs(new Color32(77, 24, 110, 255), new Color32(235, 23, 206, 255)),
    };
}
