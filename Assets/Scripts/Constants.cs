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
}
