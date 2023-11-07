using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [FormerlySerializedAs("Floor")][SerializeField] private GameObject[] floor;
    [SerializeField] private int startZPos;
    [FormerlySerializedAs("nextZPos")] [SerializeField] private int zPosStep;
    private bool _creatingSection;
    private int _floorNum;
    [SerializeField] private int maxFloorAmount;
    private Queue<GameObject> _activeFloor = new();
    private Coroutine _tileRoutine;
    private GameObject _lastFloorCreated;
    const int RoadLength = 5;
    const int DequeueLimit = 6;
    private const float TileStep = 1f;
   

    private void OnEnable()
    {
        for (int i = 0; i < RoadLength; i++)
        {
            AddSection(0f);
            startZPos += zPosStep;
        }
        
    }

   

    private void LateUpdate()
    {
        var PosDiff = startZPos -_lastFloorCreated.transform.position.z;
        if (PosDiff > zPosStep)
        {
            PosDiff -= zPosStep;
            AddSection(PosDiff);
        }
    }

    private void AddSection(float offset)
    {
        // made to select  different prefabs
        _floorNum = Random.Range(0, maxFloorAmount);
        // Instantiate(floor[_floorNum], new Vector3(0, 0, startZPos), Quaternion.identity);
        _lastFloorCreated = ObjectPool.instance.GetPooledObject();
        if (_lastFloorCreated != null)
        {
            _activeFloor.Enqueue(_lastFloorCreated);
            _lastFloorCreated.transform.position = new Vector3(0, 0, startZPos - offset);
            _lastFloorCreated.SetActive(true);
        }
        
        if (_activeFloor.Count > DequeueLimit)
        {
            _activeFloor.Dequeue().SetActive(false);
        }
    }
}
