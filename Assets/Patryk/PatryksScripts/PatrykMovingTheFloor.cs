using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrykMovingTheFloor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _transform;
    [SerializeField] private float floorSpeed = 20f;
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        _transform.position += -_transform.forward * (floorSpeed * Time.deltaTime);
    }
}
