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
    public int badHitScore = 50;
    public int goodHitScore = 100;
    public int perfectHitScore = 200;

    public int currentCombo;
    public int comboTracker;
    public int[] comboThresholds;

    public Text scoreText;
    public Text comboText;

    public float totalNotes;
    public float badHits, goodHits, perfectHits, missedHits;

    public float totalScore;
    public float accuracy;

    public GameObject scoreboard;
    public Text perfectText, goodText, badText, missedText, accuracyText, totalScoreText, gradeText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentCombo = 1;

        totalNotes = FindObjectsOfType<ButtonDetections>().Length; // leiab k6ik objektid, millel on ButtonDetections
    }                                                              // script kyljes ja tagastab pikkuse floatina

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
        else
        {
            if(!music.isPlaying && !scoreboard.activeInHierarchy)
            {
                scoreboard.SetActive(true);

                badText.text = badHits.ToString(); // muudab floati stringiks
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missedText.text = missedHits.ToString();

                float totalscore = maxScore();
                float accuracy = (currentScore / totalScore) * 100;

                Debug.Log(totalScore);
                Debug.Log(accuracy);

                accuracyText.text = accuracy.ToString("F1") + "%";

                string gradeValue = "F";

                if(accuracy > 50)
                {
                    gradeValue = "E";
                    if(accuracy > 60)
                    {
                        gradeValue = "D";
                        if(accuracy > 70)
                        {
                            gradeValue = "C";
                            if (accuracy > 80)
                            {
                                gradeValue = "B";
                                if (accuracy > 90)
                                {
                                    gradeValue = "A";
                                    if (accuracy > 95)
                                    {
                                        gradeValue = "S";

                                    }
                                }
                            }
                        }
                    }
                }
                gradeText.text = gradeValue;

                totalScoreText.text = currentScore.ToString();
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
        currentScore += badHitScore * currentCombo;
        NoteHit();
        
        badHits++;
    }

    public void GoodHit()
    {
        currentScore += goodHitScore * currentCombo;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += perfectHitScore * currentCombo;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");

        currentCombo = 1;
        comboTracker = 0;

        comboText.text = "Combo: x" + currentCombo;

        missedHits++;
    }

    public float maxScore() //leiab leveli suurima potentsiaalse skoori
    {
        float total = 0;
        int comboType;
        float maxComboNotes = totalNotes;

        for(comboType = 0; comboType < comboThresholds.Length; comboType++)          //teeb nii palju kui on m2ngus erinevaid combo koefitsente
        {
            total += perfectHitScore * (comboType + 1) * comboThresholds[comboType]; //comboThresholds[comboType] ehk mitu korda j2rjest tuleb nootidele pihta saada, et combo koefitsent t6useks
            maxComboNotes -= comboThresholds[comboType];                             //leiab, mitu nooti on levelis j22nud, mille parima ajastusega saadavat tulemust tuleb korrutada suurima comboga
        }

        total += perfectHitScore * (comboType + 1) * maxComboNotes;                  //liidab juurde tulemuse, mis saadakse (maxComboNotes) * (skoor, mis saadakse suurima comboga parimal noodi ajastusel)

        Debug.Log(total);
        return total;
    }
}
