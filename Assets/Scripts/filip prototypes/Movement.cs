using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float forwardMovement = 1f;
    [SerializeField] private float sidewaysMovement = 1f;

    private void Update()
    {
        transform.Translate(0, 0, forwardMovement * Time.deltaTime);

        if(Input.GetKey("d") && transform.position.x < 2)
        {
            transform.Translate(sidewaysMovement * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey("a") && transform.position.x > -2) 
        {
            transform.Translate(-sidewaysMovement * Time.deltaTime, 0, 0);
        }
    }
} 
