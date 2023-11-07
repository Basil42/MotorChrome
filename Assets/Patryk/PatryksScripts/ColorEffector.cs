using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEffect : MonoBehaviour
{
    public bool hasRed = false;
    public bool hasGreen = false;
    public bool hasBlue = false;

    private Renderer _enemyColor;

    public ColorShifting shiftColors;


    private void OnTriggerEnter(Collider other)
    {
        _enemyColor = other.GetComponent<Renderer>();

        if (hasRed && hasGreen && (_enemyColor.material.color == Color.red || _enemyColor.material.color == Color.green))
        {
            
        }
    }
}
