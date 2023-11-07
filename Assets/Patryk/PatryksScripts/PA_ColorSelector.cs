using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PA_ColorSelector : MonoBehaviour, IColorGet
{
    //Added magenta, yellow and cyan state - Patryk
    private readonly ColorState[] _colors = new ColorState[] { ColorState.Blue, ColorState.Green,ColorState.Red, ColorState.Cyan, ColorState.Magenta, ColorState.Yellow  };

    public ColorState CurrentColorState { get; private set; }

    [SerializeField] private Renderer playerRenderer;
    //[SerializeField] private Material playerSharedMaterial;
    [SerializeField] private InputAction changeColorLeft, changeColorRight;
    private GameObject _player;
    public int CurrentColor { get; private set; }

    private ColorShifting _colorShifting;

    public ColorEffect shiftingColors;
    
    public void Awake()
    {
        changeColorLeft.performed += OnChangeColorLeftOnPerformed;
        changeColorRight.performed += OnChangeColorRightOnPerformed;
        _colorShifting = GetComponent<ColorShifting>();
        //changeColorRight.performed += ctx => SwitchColor(false);
        //playerRenderer.material.color = _colors[_currentColor = Random.Range(0, _colors.Length)];
        
        //playerSharedMaterial.color = _colors[CurrentColor = Random.Range(0, _colors.Length)];
        CurrentColorState = _colors[CurrentColor];
        _colorShifting.NewColorShift();
    }
    private void OnChangeColorLeftOnPerformed(InputAction.CallbackContext ctx)
    {
        if (ctx.interaction is TapInteraction) SwitchColor(true);
    }
    private void OnChangeColorRightOnPerformed(InputAction.CallbackContext ctx)
    {
        if (ctx.interaction is TapInteraction) SwitchColor(false);
    }

    private void OnEnable()
    {
        changeColorLeft.Enable();
        changeColorRight.Enable();
    }private void OnDisable()
    {
        changeColorLeft.Disable();
        changeColorRight.Disable();
    }

    private void SwitchColor(bool left)
    {


          if (left) 
              CurrentColor++;
          else
              CurrentColor--;

          
          if (CurrentColor > _colors.Length) 
              CurrentColor = 0;
          else if (CurrentColor < 0)
              CurrentColor = _colors.Length - 1;
         
          //CurrentColor++;
          //playerRenderer.material.color = _colors[_currentColor > 2 ? _currentColor = 0 : _currentColor];
          //playerSharedMaterial.color = _colors[CurrentColor > 2 ? CurrentColor = 0 : CurrentColor];

         
            
        else
        CurrentColorState = _colors[CurrentColor > 2 ? CurrentColor = 0 : CurrentColor];
          _colorShifting.NewColorShift();

    }

    public void Update()
    {
        //These are just for play testing not anything important

        /*switch (Input.inputString)
        {
            case "r":
                SwitchColor(0);
                break;
            case "b":
                SwitchColor(1);
                break;
            case "g":
                SwitchColor(2);
                break;
        }*/
        //Patryk introducing stuff to shift the colors
        if (shiftingColors.hasGreen == true && shiftingColors.hasBlue)
        {
            CurrentColorState = ColorState.Cyan;

        }
        if (shiftingColors.hasRed == true && shiftingColors.hasBlue)
        {
            CurrentColorState = ColorState.Magenta;

        }
        if (shiftingColors.hasGreen == true && shiftingColors.hasRed)
        {
            CurrentColorState = ColorState.Yellow;

        }
    }

    public ColorState GetColorState()
    {
        return CurrentColorState;
        
    }
}
