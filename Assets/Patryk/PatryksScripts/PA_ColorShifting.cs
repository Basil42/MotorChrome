using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PA_ColorShifting : MonoBehaviour
{
        private readonly Color[] _colors = new Color[] {Color.blue, Color.green, Color.red};

        
        private Renderer _playerColor;
        private Color _targetColor;
         private float _timeLeft;
         [SerializeField] private float shiftingTime;

        private ColorSelector _colorSelector;
        
        [SerializeField] private Texture2D colorSpectrum;
    //Added purplePos, cyanPos and yellowPos - Patryk
        [SerializeField] private float bluePos, greenPos, redPos, magentaPos, cyanPos, yellowPos;

        private float _currentColorPos;

        private float _colorDestination;

        private Rect _pixelToRead;

        [SerializeField] private Material playerSharedMaterial;

    [SerializeField] private ColorEffect shiftColors;
    
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
            //another addition - Patryk
            if (colorSpectrum.GetPixel(i, 0) == Color.cyan)
            {
                cyanPos = i;
                print("magenta found");
            }
        }
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
                playerSharedMaterial.color = colorSpectrum.GetPixel((int)MathF.Round(_currentColorPos), 0);

            }
            
        //Testing if I understand how to switch colors - Patryk
        if(shiftColors.hasRed == true && shiftColors.hasBlue) 
        {
            _colorSelector = GetComponent<ColorSelector>();

            _timeLeft = shiftingTime;

            Invoke("ReturnColor", 5f * Time.deltaTime);
            switch (_colorSelector.CurrentColorState)
            {
                case ColorState.Magenta:
                
                    _colorDestination = magentaPos;
                    break;

                    



                

            }
        }
        if (shiftColors.hasRed == true && shiftColors.hasGreen)
        {
            _colorSelector = GetComponent<ColorSelector>();

            _timeLeft = shiftingTime;

            Invoke("ReturnColor", 5f * Time.deltaTime);
            switch (_colorSelector.CurrentColorState)
            {
                case ColorState.Yellow:

                    _colorDestination = yellowPos;
                    break;


            }
        }
        if (shiftColors.hasBlue == true && shiftColors.hasGreen)
        {
            _colorSelector = GetComponent<ColorSelector>();

            _timeLeft = shiftingTime;

            Invoke("ReturnColor", 5f * Time.deltaTime);
            switch (_colorSelector.CurrentColorState)
            {
                case ColorState.Cyan:

                    _colorDestination = cyanPos;
                    break;


            }
        }



        //End of test - Patryk

        //_playerColor.sharedMaterial.color = colorSpectrum.ReadPixels(_pixelToRead,  )


    }

        public void NewColorShift()
        {
            _colorSelector = GetComponent<ColorSelector>();
            
            _timeLeft = shiftingTime;
            //_targetColor = _colors[_colorSelector.CurrentColor];

            switch (_colorSelector.CurrentColorState)
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
    //Patryk stuff
    public void ReturnColor() 
    {
        shiftColors.hasRed = false;
        shiftColors.hasGreen = false;
        shiftColors.hasBlue = false;
    
    }
    
    // End of Patryk stuff
        
        

}
