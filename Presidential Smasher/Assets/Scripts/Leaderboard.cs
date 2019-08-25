using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

    public int topScore;
    string highScoreKey = "HighScore";
    public GameObject HighScoreBoard;

    void Start()
    {
        topScore = PlayerPrefs.GetInt(highScoreKey, 0);
        //use this value in whatever shows the leaderboard.
    }
    void Update()
    {
        UpdateScore();
    }
    void UpdateScore()
    {
        Text hScore = HighScoreBoard.GetComponent<Text>();
        hScore.text = topScore.ToString();
    }
}
