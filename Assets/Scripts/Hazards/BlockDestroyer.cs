using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BlockDestroyer : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.z < 0)
        {
            DestroyBlock();
        }
    }

    public void DestroyBlock()
    {
        Destroy(gameObject);
        //transform.position = new Vector3(9000, 9000, 9000); //This is very temporary
    }
}
