using System.Collections;
using System.Collections.Generic;
using Data.ValueReferences;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatformMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [FormerlySerializedAs("_transform")] [SerializeField] private Transform _trans;
    [SerializeField] private FloatRef playerSpeed;
    void Start()
    {
        _trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _trans.position += -_trans.forward * (playerSpeed.Value * Time.deltaTime);
    }
}
