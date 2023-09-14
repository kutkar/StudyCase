
using TMPro;
using UnityEngine;


    public class GoldAndScoreUI : MonoBehaviour 
    {
        [SerializeField] TextMeshProUGUI goldText;
        [SerializeField] TextMeshProUGUI scoreText;
        
        
        public void UpdateGoldText(int amountOfGold)
        {
            goldText.text = amountOfGold.ToString();
        }
        
        public void UpdateScoreText(int amountOfScore)
        {
            scoreText.text = amountOfScore.ToString();
        }
        
        
    }
