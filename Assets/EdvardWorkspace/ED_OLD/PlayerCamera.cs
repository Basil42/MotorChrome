//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UIElements;


////SCRIPT FOR SETTING UP A (CAMERA DISTANCE TO PLAYER & CAMERA FIELD OF VIEW) RELATIONSHIP.
////

//[RequireComponent(typeof(Camera))]
//public class PlayerCamera : MonoBehaviour
//{

//    //OBJECTS
//    [SerializeField] private Camera _cam;
//    [SerializeField] private GameObject _player;


//    //CAMERA ATTRIBUTES
//    [SerializeField] private float _fieldOfView;


//    //TRANSFORM ATTRIBUTES

//    Vector3 playerPosition;

//    Vector3 camPosition;
//    Vector3 camLocalPosition;

//    Vector3 focusPoint;




//    [SerializeField]
//    Transform focus = default;

//    [SerializeField, Range(1f, 20f)]
//    float distance = 5f;

//    [SerializeField, Min(0f)]
//    float focusRadius = 1f;



 




//    void Awake()
//    {
//        _cam = GetComponent<Camera>();
//        focusPoint = focus.position;

//        //camPosition = _cam.transform.position;
//        //camLocalPosition = _cam.transform.localPosition;
//        //playerPosition = _player.transform.position;

//        //camLocalPosition = _cam.transform.localPosition + focusPoint;
//        _fieldOfView = 60;

//    }



//    private void CameraDynamics()
//    {

//        Camera.main.fieldOfView = _fieldOfView;

//        Vector3 camPosition = focusPoint * distance;



//    }





//    void Start()
//    {
        



      
//    }

   
//    void Update()
//    {
        
//    }



//    void LateUpdate()
//    {
//        //UpdateFocusPoint();
        

//    }

//    //void UpdateFocusPoint()
//    //{
//    //    previousFocusPoint = focusPoint;
//    //    Vector3 targetPoint = focus.position;
//    //    if (focusRadius > 0f)
//    //    {
//    //        float distance = Vector3.Distance(targetPoint, focusPoint);
//    //        float t = 1f;
//    //        if (distance > 0.01f && focusCentering > 0f)
//    //        {
//    //            t = Mathf.Pow(1f - focusCentering, Time.unscaledDeltaTime);
//    //        }
//    //        if (distance > focusRadius)
//    //        {
//    //            //focusPoint = Vector3.Lerp(
//    //            //	targetPoint, focusPoint, focusRadius / distance
//    //            //);
//    //            t = Mathf.Min(t, focusRadius / distance);
//    //        }
//    //        focusPoint = Vector3.Lerp(targetPoint, focusPoint, t);
//    //    }
//    //    else
//    //    {
//    //        focusPoint = targetPoint;
//    //    }
//    //}










//}
