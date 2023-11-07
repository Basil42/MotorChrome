using System;
using System.Collections;
using System.Collections.Generic;
using Data.ValueReferences;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

//THIS IS EDVARDS PIRATED VERSION OF BLOCK-SCRIPT TO MAKE THE LEVEL VISUALS MOVE WITH THE PLAYER//
public class ED_BreakableBlocksGeneration : MonoBehaviour
{
    

    [SerializeField] private float baseEnemySpeed;

    [SerializeField] private FloatRef PlayerSpeed;
    //Adjust to overlap with the players lanes -Gustav
    [SerializeField] private float offsetFromCentre;

    //how far in the distance it will respawn -Gustav
    [SerializeField] private int distanceFromPlayerWhenRespawning;

    private Vector3 _targetPosition;
    private Rigidbody _rb;

  

    [SerializeField] private PlayerBlockCollision enemySpeed;  
    const float TargetPositionY = 1.75f;
    const int MaxInclusive = 2;
    private void Start()
    {
        Assert.IsNotNull(PlayerSpeed);
        _rb = gameObject.GetComponent<Rigidbody>();
        
      
        
       
    }

    private void Update()
    {
       

        _rb.velocity = new Vector3(0,0,-PlayerSpeed.Value);
    }

   
}
