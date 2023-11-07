using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorGet
{
    public ColorState GetColorState();
}

[Flags]
public enum ColorState
{
    Black = 0 , Blue = 1, Green = 2, Cyan = 3, Red = 4, Magenta = 5, Yellow = 6, White = 7
}