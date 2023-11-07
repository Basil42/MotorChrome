using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ColorBar : MonoBehaviour
{
    [SerializeField] private WhiteLightPowerUp powerUpBehavior;//TODO: change this to use value refs and signals
    public Image redGaugeSprite, greenGaugeSprite, blueGaugeSprite; 
    private const int NumberOfGauges = 3;

    [SerializeField] private float time;
    private int _brokenBlockColor;
    private bool _barChanging;
    private Coroutine _redRoutine;
    private Coroutine _greenRoutine;
    private Coroutine _blueRoutine;
    private int _maxStacks;


    // private IEnumerator Start()
    // {
    //     var waiter = new WaitForSeconds(2f);
    //     ChangeColorBar(0.333f,ColorState.Red);
    //     yield return waiter;
    //     ChangeColorBar(0.333f,ColorState.Blue);
    //     ChangeColorBar(0.333f,ColorState.Green);
    //     yield return waiter;
    //     ChangeColorBar(1f,ColorState.Red);
    //     yield return waiter;
    //     ChangeColorBar(0f,ColorState.Red);
    // }

    private void Awake()
    {
#if UNITY_EDITOR
        if (powerUpBehavior == null)
        {
            Debug.LogWarning("Whitelight powerup reference wasn't serialized to it's associated ui, trying to find it now");
            powerUpBehavior = FindObjectOfType<WhiteLightPowerUp>();
            if(powerUpBehavior == null)Debug.LogError("Could not find the behavior");
        }
        
#endif
        powerUpBehavior.OnRedStacksChanged += OnRedStacksChanged;
        powerUpBehavior.OnGreenStacksChanged += OnGreenStacksChanged;
        powerUpBehavior.OnBlueStacksChanged += OnBlueStacksChanged;
        powerUpBehavior.OnWhitePowerUpTriggered += OnPowerUp;
        _maxStacks = powerUpBehavior.MaxStacks;//would be nice to hqve reference here instead
        initColorBars();
    }

    private void OnPowerUp(float duration)
    {
        StartCoroutine(WhiteGaugeRoutine(duration));
    }

    //Gradually empty the gauges, be sure to restore the gauges colors if you interrupt this routine
    private IEnumerator WhiteGaugeRoutine(float duration)
    {
        StopCoroutine(_redRoutine);
        StopCoroutine(_greenRoutine);
        StopCoroutine(_blueRoutine);
        redGaugeSprite.fillAmount = 1f;
        greenGaugeSprite.fillAmount = 1f;
        blueGaugeSprite.fillAmount = 1f;
        var originalRed = redGaugeSprite.color;
        redGaugeSprite.color = Color.white;
        var originalGreen = greenGaugeSprite.color;
        greenGaugeSprite.color = Color.white;
        var originalBlue = blueGaugeSprite.color;
        blueGaugeSprite.color = Color.white;
        float timePerGauge = duration / NumberOfGauges;
        float timer = 0f;
        while (timer < timePerGauge)
        {
            timer += Time.deltaTime;
            blueGaugeSprite.fillAmount = Mathf.Lerp(1f, 0f, timer / timePerGauge);
            yield return null;
        }
        timer = 0f;
        while (timer < timePerGauge)
        {
            timer += Time.deltaTime;
            greenGaugeSprite.fillAmount = Mathf.Lerp(1f, 0f, timer / timePerGauge);
            yield return null;
        }
        timer = 0f;
        
        while (timer < timePerGauge)
        {
            timer += Time.deltaTime;
            redGaugeSprite.fillAmount = Mathf.Lerp(1f, 0f, timer / timePerGauge);
            yield return null;
        }
        redGaugeSprite.color = originalRed;
        greenGaugeSprite.color = originalGreen;
        blueGaugeSprite.color = originalBlue;
    }

    

    private void OnDestroy()
    {
        powerUpBehavior.OnRedStacksChanged -= OnRedStacksChanged;
        powerUpBehavior.OnGreenStacksChanged -= OnGreenStacksChanged;
        powerUpBehavior.OnBlueStacksChanged -= OnBlueStacksChanged;
    }

    private void OnRedStacksChanged(int stacks)
    {
        StopCoroutine(_redRoutine);
        StartCoroutine(ChangeColorBarRoutine(redGaugeSprite, (float)stacks / _maxStacks));
    }
    private void OnGreenStacksChanged(int stacks)
    {
        StopCoroutine(_greenRoutine);
        StartCoroutine(ChangeColorBarRoutine(greenGaugeSprite, (float)stacks / _maxStacks));
    }
    private void OnBlueStacksChanged(int stacks)
    {
        StopCoroutine(_blueRoutine);
        StartCoroutine(ChangeColorBarRoutine(blueGaugeSprite, (float)stacks / _maxStacks));
    }
    private void initColorBars()
    {
         _redRoutine = StartCoroutine(ChangeColorBarRoutine(redGaugeSprite,0f));
         _greenRoutine = StartCoroutine(ChangeColorBarRoutine(greenGaugeSprite,0f));
         _blueRoutine = StartCoroutine(ChangeColorBarRoutine(blueGaugeSprite,0f));
    }
    private IEnumerator ChangeColorBarRoutine(Image gauge, float targetAmount)
    {
        float startingFillAmount = gauge.fillAmount;
        float targetFillAmount = targetAmount;
        float timer = 0f;
        while (timer <= time)
        {
            timer += Time.deltaTime;
            gauge.fillAmount = Mathf.Lerp(startingFillAmount,targetFillAmount, timer/time);
            yield return null;
        }   
    }
}