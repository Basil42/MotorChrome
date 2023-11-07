using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[Obsolete("should be split between a spawner and a block behavior", true)]
public class BreakableBlocksGeneration : MonoBehaviour, IColorGet
{
    private readonly ColorState[] _blockColors = new ColorState[] { ColorState.Red, ColorState.Green, ColorState.Blue };

    private int _blockColorNumber;

    [SerializeField] private float baseEnemySpeed;
    
    //Adjust to overlap with the players lanes -Gustav
    [SerializeField] private float offsetFromCentre;

    //how far in the distance it will respawn -Gustav
    [SerializeField] private int distanceFromPlayerWhenRespawning;

    private Vector3 _targetPosition;
    private Rigidbody _rb;

    private MeshRenderer _blocksMeshRenderer;

    [SerializeField] private PlayerBlockCollision enemySpeed;  
    const float TargetPositionY = 1.75f;
    const int MaxInclusive = 2;

    private ColorState _currentColorState;

    [Header("Lose Condition Variables")]
    [SerializeField] private float _initialSafetyTime = 15f;
    [SerializeField] private float _safetyTimeAfterCollision = 10f;
    [SerializeField] private int _failsBeforeLose = 4;
    [SerializeField] private float _minAllowedVelocity = -11;
    private bool _currentlySafe = true;
    
    
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        
        _blocksMeshRenderer = GetComponent<MeshRenderer>(); 
        
        SetColor();
        StartCoroutine(StartSafetyNet(_initialSafetyTime));
    }

    private void Update()
    {
        //This is a placeholder for a respawning system
        if (transform.position.z < 0)
        {
            GenerateBlock();
        }
        _rb.velocity = new Vector3(0,0,-enemySpeed.brokenBlocks - baseEnemySpeed);

        //If the velocity bottoms out and there is no safety net active
        if(_rb.velocity.z >= _minAllowedVelocity && !_currentlySafe)
        {
            StartCoroutine(CollisionSafetyNet(_safetyTimeAfterCollision));
        }
    }

    public void GenerateBlock()
    {
        SetColor();
        GeneratePosition();
    }

    private void SetColor(ColorState color = ColorState.Green)
    {
        _blockColorNumber = Random.Range(0, _blockColors.Length);

        color = _blockColors[_blockColorNumber];

        _currentColorState = color;

        
        Color materialColor = new Color();
        materialColor.r = (int)(color & ColorState.Red) != 0 ? 1f : 0f;
        materialColor.g = (int)(color & ColorState.Green) != 0 ? 1f : 0f;
        materialColor.b = (int)(color & ColorState.Blue) != 0 ? 1f : 0f;
        materialColor.a = 1f;

        _blocksMeshRenderer.material.color = materialColor;
    }

    private void GeneratePosition()
    {
        _targetPosition = new Vector3(
            Random.Range(-1, MaxInclusive) * offsetFromCentre, 
            TargetPositionY,
            distanceFromPlayerWhenRespawning);
        transform.position = _targetPosition; 
    }

    public ColorState GetColorState()
    {
        return _currentColorState;
    }


    //would probably be better to have lose condition in a separate script but im not sure if its worth
    //Since it would have to fetch the rb.velocity.z in an update method there to keep track of it (i think)
    IEnumerator StartSafetyNet(float safeForSeconds)
    {
        yield return new WaitForSeconds(safeForSeconds);
        _currentlySafe = false;
    }
    IEnumerator CollisionSafetyNet(float safeForSeconds)
    {
        if (_failsBeforeLose <= 0 && enemySpeed.ToString() == _currentColorState.ToString())
        {
            //Call leaderboard class with current score, or a method in scoring class that calls leaderboard from there
            //Open main menu or something
            Time.timeScale = 0f;
        }
        _currentlySafe = true;
        _failsBeforeLose--;
        yield return new WaitForSeconds(safeForSeconds);
        _currentlySafe = false;
    }
    
}
