using System.Collections;
using System.Collections.Generic;
using Data.ValueReferences;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

public class ED_PlatformMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //private Transform _transform;
    //private float floorSpeed = 20f;
    //void Start()
    //{
    //    _transform = transform;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    _transform.position += -_transform.forward * (floorSpeed * Time.deltaTime);
    //}


    private Rigidbody _rb;
    //private CharacterController _cc;

    [SerializeField] private float baseEnemySpeed;
    [SerializeField] private FloatRef playerSpeed;
    private PlayerBlockCollision _enemySpeed;

    private void Start()
    {
        Assert.IsNotNull(playerSpeed);
        _rb = GetComponent<Rigidbody>();
        //_cc = GetComponent<CharacterController>();
        _enemySpeed = FindObjectOfType<PlayerBlockCollision>(); // CHANGE THIS AS SOON AS WE HAVE A PROPER MANAGER
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, 0, -playerSpeed.Value);
        //_cc.velocity = new Vector3(0, 0, -_enemySpeed.brokenBlocks - baseEnemySpeed);
       
    }



}
