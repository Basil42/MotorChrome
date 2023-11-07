using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickupGreen : MonoBehaviour
{
    public ColorEffect colorEffect;

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        colorEffect = other.GetComponent<ColorEffect>();
        colorEffect.hasGreen = true;
        Destroy(gameObject);
    }
}
