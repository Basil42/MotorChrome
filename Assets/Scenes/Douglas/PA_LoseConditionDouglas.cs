using System.Collections;
using System.Collections.Generic;
using Data.ValueReferences;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LoseConditionDouglas : MonoBehaviour
{

    [SerializeField] private FloatRef playerSpeed;
    [SerializeField] private float slowSpeedLimit = 14f;//speed at which the player starts loosing health
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private float _safeForSeconds = 5f;
    private Scoring score;
    public GameObject explodeBike, explosion;
    private bool _isSafe = true, _isAlive = true;

    private SkinnedMeshRenderer[] _disableOwnMesh;

    [SerializeField] float hp;

    float hpLost = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Scoring>();
        StartCoroutine(SafetyPeriod());
        UpdatePlayerHealthText();
        _disableOwnMesh = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpeed.Value < slowSpeedLimit && !_isSafe)
        {
            hp = hp - hpLost * Time.deltaTime;
            UpdatePlayerHealthText();
        }
        else if (playerSpeed.Value > 1 && hp < 10 && !_isSafe)
        {
            hp = hp + hpLost * Time.deltaTime;
            UpdatePlayerHealthText();
        }

        if(hp <= 0)
        {
            if (_isAlive) StartCoroutine(LoseGame());
        }
        
    }
    private void UpdatePlayerHealthText()
    {
        _healthText.text = "Health : " + Mathf.Round(hp) + "";
    }

    IEnumerator LoseGame()
    {
        _isAlive = false;
        var transform1 = transform;
        var position = transform1.position;
        var rotation = transform1.rotation;
        Instantiate(explosion, position, rotation);
        Instantiate(explodeBike, position, rotation);
        foreach (SkinnedMeshRenderer _renderer in _disableOwnMesh)
        {
            _renderer.enabled = false;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        score.SubmitScore();
    }
    IEnumerator SafetyPeriod()
    {
        _isSafe = true;
        yield return new WaitForSeconds(_safeForSeconds);
        _isSafe = false;
    }

}
