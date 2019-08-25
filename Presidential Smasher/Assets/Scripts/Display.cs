using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display : MonoBehaviour {

    public GameObject whackAMoleLogicObject;
    private WhackAMoleLogic whackAMoleLogic;

    public TextMesh insertCoin;
    public TextMesh topScore;
    public TextMesh currentScore;
    public TextMesh timeRemaining;

    string highScoreKey = "HighScore";
    public int highScore;
    public float timeBetweenInsertCoinBlinks = 3f;
    public float blinkOffTime = 0.5f;
    public bool insertCoinIsOn = true;
    private float timeSinceLastBlink = 0f;
    private float timeSpentOff = 0f;

    void Start () {
        whackAMoleLogic = whackAMoleLogicObject.GetComponent<WhackAMoleLogic>();
        updateDisplayStats(0,0, PlayerPrefs.GetInt(highScoreKey, 0));
    }
	
	void Update () {

    }

    void FixedUpdate()
    {
        if (whackAMoleLogic.gameIsInPlay)
        {
            insertCoinIsOn = false;
            timeSinceLastBlink = 0;
            timeSinceLastBlink = 0;
        } else
        {
            if (insertCoinIsOn)
            {
                timeSinceLastBlink += Time.deltaTime;
                if (timeSinceLastBlink > timeBetweenInsertCoinBlinks)
                {
                    insertCoin.GetComponent<MeshRenderer>().enabled = false;
                    timeSinceLastBlink = 0;
                    insertCoinIsOn = false;
                }
            } else
            {
                timeSpentOff += Time.deltaTime;
                if (timeSpentOff > blinkOffTime)
                {
                    timeSpentOff = 0;
                    insertCoin.GetComponent<MeshRenderer>().enabled = true;
                    insertCoinIsOn = true;
                }
            }
        }
    }

    public void changeHeaderText(string newText)
    {
        insertCoin.GetComponent<TextMesh>().text = newText;
        insertCoin.GetComponent<MeshRenderer>().enabled = true;
    }

    public void updateDisplayStats(int currentScore, float timeRemaining, int topScore)
    {
        topScore = PlayerPrefs.GetInt(highScoreKey, 0);
        this.currentScore.GetComponent<TextMesh>().text = currentScore.ToString();
        this.topScore.GetComponent<TextMesh>().text = topScore.ToString();
        this.timeRemaining.GetComponent<TextMesh>().text = timeRemaining.ToString("F1");
    }
}
