using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pickups;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ColorSelector : MonoBehaviour, IColorGet
{
    private readonly ColorState[] _colors = new ColorState[] { ColorState.Red, ColorState.Green, ColorState.Blue };

    public ColorState CurrentColorState { get; private set; }

    [SerializeField] private Renderer playerRenderer;

    //[SerializeField] private Material playerSharedMaterial;
    [SerializeField] private InputAction changeColorLeft, changColorRight;
    private GameObject _player;
    private int CurrentColor { get; set; }

    private ColorShifting _colorShifting;

    private bool _colorShiftingIsLocked, _tappedLeft, _tappedright;
    
    const float _tapInterval = 0.1f;

    private int
        _colorShiftingLocks; //the color shifter is unlock when this is 0, this allows to have different lock running in parallel


    public void Awake()
    {
        changeColorLeft.performed += OnChangeColorLeftOnPerformed;
        changColorRight.performed += OnChangeColorRightOnPerformed;
        _colorShifting = GetComponent<ColorShifting>();
        //changeColorRight.performed += ctx => SwitchColor(false);
        //playerRenderer.material.color = _colors[_currentColor = Random.Range(0, _colors.Length)];

        //playerSharedMaterial.color = _colors[CurrentColor = Random.Range(0, _colors.Length)];
        CurrentColorState = _colors[CurrentColor];
        _colorShifting.NewColorShift();

        //StartCoroutine(WhiteColorPowerUpTimer());
    }

    private void OnChangeColorLeftOnPerformed(InputAction.CallbackContext ctx)
    {
        StartCoroutine(OnChangeColorLeftRoutine(ctx));
    }
    
    private void OnChangeColorRightOnPerformed(InputAction.CallbackContext ctx)
    {
        StartCoroutine(OnChangeColorRightRoutine(ctx));
    }
    // private void OnChangeColorLeftOnPerformed(InputAction.CallbackContext ctx)
    // {
    //     SwitchColor(true, ctx);
    // }
    //
    // private void OnChangeColorRightOnPerformed(InputAction.CallbackContext ctx)
    // {
    //     SwitchColor(false, ctx);
    // }

    private IEnumerator OnChangeColorLeftRoutine(InputAction.CallbackContext ctx)
    {
        _tappedLeft = true;
        if (_tappedright && _tappedLeft) SwitchColor(false, ctx);
        yield return new WaitForSeconds(_tapInterval);
        _tappedLeft = false;
    }
    private IEnumerator OnChangeColorRightRoutine(InputAction.CallbackContext ctx)
    {
        _tappedright = true;
        if (_tappedright && _tappedLeft) SwitchColor(false, ctx);
        yield return new WaitForSeconds(_tapInterval);
        _tappedright = false;
    }

    private void OnEnable()
    {
        changeColorLeft.Enable();
        changColorRight.Enable();
    }

    private void OnDisable()
    {
        changeColorLeft.Disable();
        changColorRight.Disable();
    }

    private void SwitchColor(bool left, InputAction.CallbackContext value)
    {
        _tappedLeft = false;
        _tappedright = false;
        CurrentColor = (CurrentColor + (left ? -1 : 1) + _colors.Length) % _colors.Length; //making the index loop

        if (!_colorShiftingIsLocked)
        {
            CurrentColorState = _colors[CurrentColor > 2 ? CurrentColor = 0 : CurrentColor];
        }

        _colorShifting.NewColorShift();
    }

    public void SetColorState(ColorState color)
    {
        CurrentColorState = color;
        _colorShifting.NewColorShift();
    }

    public void TriggerWhitePowerUp(float duration)
    {
        StartCoroutine(WhiteColorPowerUpTimer(duration));
    }

    public void AddSelectorLock()
    {
        _colorShiftingLocks++;
    }

    public void RemoveSelectorLock()
    {
        _colorShiftingLocks--;
    }


    public ColorState GetColorState()
    {
        return CurrentColorState;
    }

    IEnumerator WhiteColorPowerUpTimer(float whitePowerUpDuration)
    {
        CurrentColorState = ColorState.White;
        _colorShiftingIsLocked = true;
        _colorShifting.NewColorShift();
        yield return
            new WaitForSeconds(
                whitePowerUpDuration); //TODO: implement a grace period for the power removal where players can see which color they are about to revert to

        _colorShiftingIsLocked = false;
        CurrentColorState = _colors[CurrentColor > 2 ? CurrentColor = 0 : CurrentColor];
        _colorShifting.ForceToTargetColor();
        _colorShifting.NewColorShift();
    }
}