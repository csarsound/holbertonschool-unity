using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour {

    public int score;
    public Text scoreText;
    public Text theScore;

    public void updateScore()
    {
        score++;
        //Debug.Log("SCORE: " + score);
        theScore.text = score.ToString();
    }

    public void ScoreReset()
    {
        score = 0;
        theScore.text = score.ToString();
    }
}
