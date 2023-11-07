using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickupBlue : MonoBehaviour
{
    public ColorEffect colorEffect;

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        colorEffect = other.GetComponent<ColorEffect>();
        colorEffect.hasBlue = true;
        Destroy(gameObject);
    }
}
