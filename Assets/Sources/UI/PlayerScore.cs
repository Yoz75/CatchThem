using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance { get; private set; }

    [SerializeField] private TMP_Text ScoreText;
    public float Score
    {
        get; private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(float score)
    {
        Score += score;
        
        ScoreText.text = Score.ToString("0.00");
    }
}
