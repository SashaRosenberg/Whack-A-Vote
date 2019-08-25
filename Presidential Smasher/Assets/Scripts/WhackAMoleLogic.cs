using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WhackAMoleLogic : MonoBehaviour {

    public int score = 0;
    string highScoreKey = "HighScore";
    public float startingTimeBetweenPuppets = 1f;
    public float fastestTimeBetweenPuppets = 0.5f;
    public float timeDecreasePerPuppet = 0.05f;
    public int rewardForGoodHit = 1;
    public int penaltyForBadHit = 10;

    public float gameLength = 60;
    private float currentGameLength = 0;
    public bool gameIsInPlay { get; private set; }

    private float timeSinceLastPuppet = 0;
    private float timePerPuppet = 0;

    public GameObject displayObject;
    private Display display;
    public GameObject[] puppets;
    private List<GameObject> puppetsWhichCanBeHit = new List<GameObject>();

    public int topScore = 0;
    public int mode = 0; //0 = both candidates, 1 = only trump, 2 = only hillary

    public HighScoreBalloons callLoons;

    public AudioClip gameStartSFX, gameEndSFX, highscoreSFX;
    private AudioSource audioSrc;

    void Start () {
        gameIsInPlay = false;
        display = displayObject.GetComponent<Display>();
        topScore = PlayerPrefs.GetInt(highScoreKey, 0);
        audioSrc = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {

    }
	
    void FixedUpdate()
    {
        if (gameIsInPlay)
        {
            if (timeSinceLastPuppet > timePerPuppet)
            {
                //activate a random puppet
                int puppetToHit = Random.Range(0, puppetsWhichCanBeHit.Count);
                //Debug.Log("Puppet to hit: " + puppetToHit);
                //Debug.Log("PuppetsWhichCanBeHit: " + puppetsWhichCanBeHit.Count);
                if (Random.Range(0,10) > 8)
                {
                    //penalty head
                    puppetsWhichCanBeHit[puppetToHit].GetComponent<PuppetLogic>().activatePuppet(true, false);
                } else
                {
                    //normal head
                    if (mode == 0)
                    {
                        bool isTrumpHead = (Random.Range(0, 2) == 1);
                        if (isTrumpHead)
                        {
                            puppetsWhichCanBeHit[puppetToHit].GetComponent<PuppetLogic>().activatePuppet(false, false);
                        } else
                        {
                            puppetsWhichCanBeHit[puppetToHit].GetComponent<PuppetLogic>().activatePuppet(false, true);
                        }
                    } else if (mode == 1)
                    {
                        puppetsWhichCanBeHit[puppetToHit].GetComponent<PuppetLogic>().activatePuppet(false, true);
                    } else if (mode == 2)
                    {
                        puppetsWhichCanBeHit[puppetToHit].GetComponent<PuppetLogic>().activatePuppet(false, false);
                    }
                }
                
                //ensure it cant be activated again until it signals that it's had a full routine.
                puppetsWhichCanBeHit.Remove(puppetsWhichCanBeHit[puppetToHit]);

                //decrease the timer
                if (timePerPuppet <= fastestTimeBetweenPuppets)
                {
                    timePerPuppet = fastestTimeBetweenPuppets;
                } else
                {
                    timePerPuppet -= timeDecreasePerPuppet;
                }
                timeSinceLastPuppet = 0;
            }
            timeSinceLastPuppet += Time.deltaTime;

            currentGameLength += Time.deltaTime;
            if (currentGameLength > gameLength)
            {
                currentGameLength = gameLength;
            }
            //update the display items
            display.updateDisplayStats(score, gameLength - currentGameLength, topScore);

            if (currentGameLength >= gameLength)
            {
                endgame();
            }
        }
    }
    public void endgame()
    {
        //game is over
        display.changeHeaderText("Insert Coin");
        audioSrc.PlayOneShot(gameEndSFX);
        if (score > topScore)
        {
            topScore = score;
            PlayerPrefs.SetInt(highScoreKey, topScore);
            PlayerPrefs.Save();
            callLoons.spawningBallonsNow();
            audioSrc.PlayOneShot(highscoreSFX);
        }
        display.updateDisplayStats(score, 0, topScore);
        gameIsInPlay = false;
        foreach (GameObject puppet in puppets)
        {
            puppet.GetComponent<PuppetLogic>().stopPlaneHit(true);
        }
    }

    public void reactivatePuppetForHitting(GameObject puppet)
    {
        puppetsWhichCanBeHit.Add(puppet);
    }

    public void startGame(int mode)
    {
        this.mode = mode;
        if (!gameIsInPlay)
        {
            //display.changeHeaderText("Good Luck!");
            timePerPuppet = startingTimeBetweenPuppets;
            score = 0;
            currentGameLength = 0;
            timeSinceLastPuppet = 0;
            gameIsInPlay = true;
            Debug.Log("startgame");

            // Play game start sound
            audioSrc.PlayOneShot(gameStartSFX);
        }
    }

    public void addReward()
    {
        score += rewardForGoodHit;
    }

    public void addPenalty()
    {
        score -= penaltyForBadHit;
    }
}
