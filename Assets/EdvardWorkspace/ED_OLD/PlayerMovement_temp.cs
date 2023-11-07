using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_temp : MonoBehaviour
{

    private GameObject _player;
    [SerializeField]
    private float _speed = 50f;

    void Start()
    {
        
    }


    void Update()
    {
        _player.transform.forward = _player.transform.forward * (_speed * Time.deltaTime);
    }
}
