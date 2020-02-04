using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeEventArgs : EventArgs
{
    public Color BackgraoundColor { get; set; }
    public Color TextColor { get; set; }

    public ThemeEventArgs(Color backgraoundColor, Color textColor)
    {
        BackgraoundColor = backgraoundColor;
        TextColor = textColor;
    }

}
