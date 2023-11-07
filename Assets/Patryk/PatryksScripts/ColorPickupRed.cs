using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickupRed : MonoBehaviour
{
    public ColorEffect colorEffect;

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        colorEffect = other.GetComponent<ColorEffect>();
        colorEffect.hasRed = true;
        Destroy(gameObject);
    }
}
