using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLaser : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BreakableBlock"))
        {
            Destroy(other.gameObject);
        }
    }
}
