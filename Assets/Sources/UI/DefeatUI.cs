using TMPro;
using UnityEngine;

namespace CatchThem
{
    public class DefeatUI : MonoBehaviour
    {
        [SerializeField] private GameObject DefeatScreen;
        [SerializeField] private TMP_Text ScoreText;

        private void Start()
        {
            DefeatScreen.SetActive(false);
            Defeat.Instance.AddOnLose(() =>
            {
                DefeatScreen.SetActive(true); 
                ScoreText.text = PlayerScore.Instance.Score.ToString("0.00");
            });
        }
    }
}