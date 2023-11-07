using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BreakableBlocks : MonoBehaviour
{
    [SerializeField] public int blockColorNumber;

    [SerializeField] public float baseEnemySpeed;

    private Vector3 _targetPosition;
    private Rigidbody _rb;

    private MeshRenderer _blocksMeshRenderer;

    [SerializeField] public PlayerBlockCollision enemySpeed;  
    const float TargetPositionY = 1.75f;
    const int MaxInclusive = 2;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.z < 0)
        {
            DestroyBlock();
        }

        // TODO ?
        //_rb.velocity = new Vector3(0,0,-enemySpeed.brokenBlocks - baseEnemySpeed);
        _rb.velocity = new Vector3(0,0,0 - baseEnemySpeed);
    }

    public void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
