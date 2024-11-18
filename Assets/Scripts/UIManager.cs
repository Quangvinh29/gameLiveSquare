using System.Collections;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text ScoreText, DashText, GameOver, finalScore;
  
    public void ScoreUpdate(int Score)
    {
        ScoreText.text = "TotalScore: " + Score;
    }

    public void DashUpdate(int currentDash)
    {
        DashText.text = "Dash: " + currentDash;
    }

     public void GameOverUI(int Score)
    {
       GameOver.gameObject.SetActive(true);
        finalScore.text = "Your Score: " + Score;
    }
}
