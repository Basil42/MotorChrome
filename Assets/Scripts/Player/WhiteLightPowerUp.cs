using System;
using System.Collections;
using System.Collections.Generic;
using Hazards;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(ColorSelector),typeof(PlayerBlockCollision))]
public class WhiteLightPowerUp : MonoBehaviour
{
    
    public int MaxStacks => maxStacks;

    private int _redStacks;
    private int _greenStacks;
    private int _blueStacks;

    private PlayerBlockCollision _playerCollision;
    private ColorSelector _colorSelector;
    [SerializeField] private int maxStacks = 3;
    [SerializeField] private float duration = 5f;
    private void Awake()
    {
        _colorSelector = GetComponent<ColorSelector>();
        _playerCollision = GetComponent<PlayerBlockCollision>();
        _playerCollision.OnBlockDestroyed += OnBlockDestroyed;
        _playerCollision.OnMismatchedBlockHit += OnBlockMismatchedHit;
    }

    
    private void OnBlockMismatchedHit(BlockDataProvider block)
    {
        var blockColor = block.GetBlockColorHandler().GetColorState();
        if (blockColor.HasFlag(ColorState.Red))
        {
            _redStacks = Mathf.Max(_redStacks - 1, 0);
            OnRedStacksChanged?.Invoke(_redStacks);
        }

        if (blockColor.HasFlag(ColorState.Green))
        {
            _greenStacks = Mathf.Max(_greenStacks - 1, 0);
            OnGreenStacksChanged?.Invoke(_greenStacks);
        }

        if (blockColor.HasFlag(ColorState.Blue))
        {
            _blueStacks = Mathf.Max(_blueStacks - 1, 0);
            OnBlueStacksChanged?.Invoke(_blueStacks);
        }

        if (_redStacks >= maxStacks && _greenStacks >= maxStacks && _blueStacks >= maxStacks)
        {
            StartCoroutine(WhiteLightRoutine());
        }
    }

    private void OnDestroy()
    {
        _playerCollision.OnBlockDestroyed -= OnBlockDestroyed;
        _playerCollision.OnMismatchedBlockHit -= OnBlockMismatchedHit;
    }

    public event Action<int> OnRedStacksChanged;
    public event Action<int> OnGreenStacksChanged;
    public event Action<int> OnBlueStacksChanged;

    public event Action<float> OnWhitePowerUpTriggered;
    public event Action OnWhitePowerUpEnded;
    private void OnBlockDestroyed(BlockDataProvider block)
    {
        var blockColor = block.GetBlockColorHandler().GetColorState();
        if (blockColor.HasFlag(ColorState.Red))
        {
            _redStacks = Mathf.Min(_redStacks + 1, MaxStacks);
            OnRedStacksChanged?.Invoke(_redStacks);
        }

        if (blockColor.HasFlag(ColorState.Green))
        {
            _greenStacks = Mathf.Min(_greenStacks + 1, MaxStacks);
            OnGreenStacksChanged?.Invoke(_greenStacks);
        }

        if (blockColor.HasFlag(ColorState.Blue))
        {
            _blueStacks = Mathf.Min(_blueStacks + 1, MaxStacks);
            OnBlueStacksChanged?.Invoke(_blueStacks);
        }

        if (_redStacks >= maxStacks && _greenStacks >= maxStacks && _blueStacks >= maxStacks)
        {
            StartCoroutine(WhiteLightRoutine());
        }
    }
    
    private IEnumerator WhiteLightRoutine()
    {
        _redStacks = 0;
        _greenStacks = 0;
        _blueStacks = 0;
        _playerCollision.OnBlockDestroyed -= OnBlockDestroyed;//we stop listening for block destruction while active
        OnWhitePowerUpTriggered?.Invoke(duration);
        _colorSelector.TriggerWhitePowerUp(duration);//I could probably ties that to an event
        yield return new WaitForSeconds(duration);
        _playerCollision.OnBlockDestroyed += OnBlockDestroyed;//resuming stack accumulation
        OnWhitePowerUpEnded?.Invoke();
        OnRedStacksChanged?.Invoke(_redStacks);
        OnGreenStacksChanged?.Invoke(_greenStacks);
        OnBlueStacksChanged?.Invoke(_blueStacks);
    }
}
