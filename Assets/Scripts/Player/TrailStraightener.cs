using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailStraightener : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(transform.position+Vector3.left*10, transform.parent.up*10);
    }
}
