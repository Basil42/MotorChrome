using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PA_FlashingScreen : MonoBehaviour
{
    [SerializeField] private Image flashingScreen;
    public float flashingTime = 2f;
    private bool canFlash = false;
    private Color32 flashStart = new Color32(255, 0, 0, 0);
    private Color32 flashEnd = new Color32(255, 0, 0, 100);
    public float timePassed = 0.0f;
    [SerializeField] LoseCondition loseCondition;
    [SerializeField] private GameObject color;

    float progress = 0.0f;
    bool fadeIn = true;
    // Start is called before the first frame update
    void Awake()
    {
        flashingScreen = GetComponent<Image>();
        

    }
    void Start()
    {
        loseCondition = GameObject.Find("Player").GetComponent<LoseCondition>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(loseCondition.hp < 10 && timePassed < flashingTime && canFlash == false)
        {
            timePassed += Time.fixedDeltaTime;
            flashingScreen.color = Color.Lerp(flashStart, flashEnd, timePassed / flashingTime);
            Invoke("FlashOne", flashingTime);
        }

        if(((loseCondition.hp < 10 && timePassed > 0) || loseCondition.hp >= 10) && canFlash == true)
        {

            timePassed -= Time.fixedDeltaTime;
            flashingScreen.color = Color.Lerp(flashStart, flashEnd, timePassed / flashingTime);
            Invoke("FlashTwo", flashingTime);
        }
    }

void FlashOne()
{
    canFlash = true;
}
void FlashTwo()
{
    canFlash = false;
}
}
