using System;
using System.Collections;
using System.Collections.Generic;
using Data.ValueReferences;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

public class BlockMover : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField] private float baseEnemySpeed;

    private PlayerBlockCollision _enemySpeed;
    [SerializeField] private FloatRef playerSpeed;

    private void Start()
    {
        Assert.IsNotNull(playerSpeed);
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector3(0,0,- playerSpeed.Value );
        //_rb.velocity = new Vector3(0,0,- baseEnemySpeed);
    }
}
