using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ColorShifting : MonoBehaviour
{
        private readonly Color[] _colors = new Color[] {Color.blue, Color.green, Color.red};

        
        private Renderer _playerColor;
        private Color _targetColor;
         private float _timeLeft;
         [SerializeField] private float shiftingTime;

        private ColorSelector _colorSelector;
        
        [SerializeField] private Texture2D colorSpectrum;
   
        [SerializeField] private float bluePos, greenPos, redPos;

        private float _currentColorPos;

        private float _colorDestination;

        private Rect _pixelToRead;

        [SerializeField] private Material[] playerSharedMaterial;
        [SerializeField] private float emissionIntensity = 4f;
    [SerializeField] private ColorEffect shiftColors;
    
    //Material data
    private int _emissionPropId;
    private const string DefaultUrpEmissionPropName = "_EmissionColor";
    
        void Awake()
        {
            //_colorSelector = GetComponent<ColorSelector>();
            
            //_playerColor = GetComponent<Renderer>();

            //_playerColor.sharedMaterial.color = _colors[_colorSelector.CurrentColor];
            _timeLeft = shiftingTime;
            //_targetColor = _colors[_colorSelector.CurrentColor];
            
            /*bluePos/= colorSpectrum.width;
            greenPos/= colorSpectrum.width;
            redPos/= colorSpectrum.width;*/

            _pixelToRead = new Rect(_currentColorPos, 0, 1, 1);

            _colorSelector = GetComponent<ColorSelector>();
            
            
            /*
            for (int i = 0; i < colorSpectrum.width; i++)
            {
                if (colorSpectrum.GetPixel(i, 0) == Color.red)
                {
                    redPos = i;
                    print("red found");
                }

                if (colorSpectrum.GetPixel(i, 0) == Color.green)
                {
                    greenPos = i;
                    print("green found");
                }

                if (colorSpectrum.GetPixel(i, 0) == Color.blue)
                {
                    bluePos = i;
                    print("blue found");
                }
            }*/
            _emissionPropId = Shader.PropertyToID(DefaultUrpEmissionPropName);
        }

    
        void Update()
        {
            
            /*if (_timeLeft <= 0)
            {
                _playerColor.material.color = _targetColor;



                _targetColor = new Color(255,0, 0);
                _timeLeft = 1f;
            }
            else
            {
                if(Input.GetKey(KeyCode.Space))
                {
                    _playerColor.material.color = Color.Lerp(_playerColor.material.color, _targetColor, Time.deltaTime / _timeLeft);


                    _timeLeft -= Time.deltaTime;
                }
            }*/
            

            if (Math.Abs(_currentColorPos - _colorDestination) > 0.01f)
            {
                _pixelToRead.x = _currentColorPos;
                
                //_playerColor.material.color = Color.Lerp(_playerColor.material.color, _targetColor, Time.deltaTime / _timeLeft);
                _currentColorPos = Mathf.Lerp(_currentColorPos, _colorDestination, Time.deltaTime/_timeLeft);
                
                _timeLeft -= Time.deltaTime;
                
                //_playerColor.sharedMaterial.color = colorSpectrum.GetPixel((int)MathF.Round(_currentColorPos), 0);
                foreach (Material mat in playerSharedMaterial)
                {
                    mat.SetColor(_emissionPropId,emissionIntensity * colorSpectrum.GetPixel((int)MathF.Round(_currentColorPos), 0));
                }
                //playerSharedMaterial.color = colorSpectrum.GetPixel((int)MathF.Round(_currentColorPos), 0);

            }
            else if (_colorSelector.CurrentColorState == ColorState.White && shiftingTime > 0)
            {
                foreach (Material mat in playerSharedMaterial)
                {
                    mat.SetColor(_emissionPropId, emissionIntensity * Color.Lerp(mat.color, Color.white, shiftingTime));//TODO: fix this
                }
                //playerSharedMaterial.color = Color.Lerp(playerSharedMaterial.color, Color.white, shiftingTime);
            }
            
        

            //_playerColor.sharedMaterial.color = colorSpectrum.ReadPixels(_pixelToRead,  )


    }

        public void NewColorShift()
        {
            
            _timeLeft = shiftingTime;
            //_targetColor = _colors[_colorSelector.CurrentColor];

            
            switch (_colorSelector.CurrentColorState)//TODO, handle the with powerup case properly
            {
                case ColorState.Blue:
                    _colorDestination = bluePos;
                    break;
                case ColorState.Green:
                    _colorDestination = greenPos;
                    break;
                case ColorState.Red:
                    _colorDestination = redPos;
                    break;
                
            }
                
        }

        public void ForceToTargetColor()
        {
            foreach (Material mat in playerSharedMaterial)
            {
                mat.SetColor(_emissionPropId, emissionIntensity * colorSpectrum.GetPixel((int)MathF.Round(_colorDestination), 0));
            }
        }
    
        
        

}
