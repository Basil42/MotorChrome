using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 _originPos, _shakePos;
    
    private float _time;
    [SerializeField] private float screenShakeDuration;
    private void Start()
    {
        ScreenShaker();
        _originPos = transform.position;
        _shakePos = _originPos;
    }

    private void ScreenShaker()
    {
        _time = 0;
    }

    private void Update()
    {
        if (_time < screenShakeDuration)
        {
            _shakePos += new Vector3(MathF.Cos(_time*100)/1000, MathF.Tan(_time*100)/1000, MathF.Sin(_time*100)/1000);
            transform.position = _shakePos;
            _time += Time.deltaTime;

        }
        else
        {
            transform.position = _originPos;
        }
        
        
    }
}
