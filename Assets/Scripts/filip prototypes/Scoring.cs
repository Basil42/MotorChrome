using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText, _speed;
    [SerializeField] PlayerBlockCollision _brokenBlocksScore;
    [field: SerializeField] public float CurrentScore { get; private set; } = 0f;
    [SerializeField] private float _scoreIncrease = 0f, _speedMultiplier;
    [SerializeField] private Leaderboard _leaderboard;

    private void Start()
    {
        _scoreText.text = "S " + CurrentScore.ToString();
    }
    private void FixedUpdate()
    {
       //_currentScore += (_scoreIncrease * _speedMultiplier);
       CurrentScore += (_scoreIncrease * _brokenBlocksScore.brokenBlocks * Time.deltaTime);
       _speed.text = "SPEED " + _brokenBlocksScore.brokenBlocks.ToString();
       SetScoreText();
    }
    private void SetScoreText()
    {
        _scoreText.text = " " + Mathf.Round(CurrentScore);
    }
    public void SetSpeedMultiplier(float newMultiplier)
    {
        _speedMultiplier = newMultiplier;
    }
    public void SubmitScore()
    {
        _leaderboard.IsScoreTopTen(CurrentScore);
    }
}
