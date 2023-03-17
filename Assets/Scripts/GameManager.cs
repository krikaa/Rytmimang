using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool startMusic;

    public FallingNotes FN;

    public static GameManager instance;

    public int currentScore;
    public int scoreBadHit = 50;
    public int scoreGoodHit = 100;
    public int scorePerfectHit = 200;

    public int currentCombo;
    public int comboTracker;
    public int[] comboThresholds;

    public Text scoreText;
    public Text comboText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentCombo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startMusic)
        {
            if (Input.anyKeyDown)
            {
                startMusic = true;
                FN.startLevel = true;

                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");
        
        if (currentCombo - 1 < comboThresholds.Length)
        {
            comboTracker++;

            if (comboThresholds[currentCombo - 1] <= comboTracker)
            {
                comboTracker = 0;
                currentCombo++;
            }
        }

        comboText.text = "Combo: x" + currentCombo;

        scoreText.text = "Score: " + currentScore;
    }

    public void BadHit()
    {
        currentScore += scoreBadHit * currentCombo;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scoreGoodHit * currentCombo;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerfectHit * currentCombo;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");

        currentCombo = 1;
        comboTracker = 0;

        comboText.text = "Combo: x" + currentCombo;
    }
}
