using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo: its only for events, do not hold it in utils
public class ThemeEventArgs : EventArgs
{
    public Color32 BackgraoundColor { get; set; }
    public Color32 TextColor { get; set; }

    public ThemeEventArgs(Color32 backgraoundColor, Color32 textColor)
    {
        BackgraoundColor = backgraoundColor;
        TextColor = textColor;
    }
}