using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorHandler : MonoBehaviour, IColorGet
{
    [SerializeField] private ColorState blockColor;

    public ColorState GetColorState()
    {
        return blockColor;
    }
}
