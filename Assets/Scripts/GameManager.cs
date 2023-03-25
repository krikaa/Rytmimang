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
    public int perfectHitScore = 150;

    public int currentCombo;
    public int comboTracker;
    public int[] comboThresholds;

    public Text scoreText;
    public Text comboText;

    public float totalNotes;
    public float badHits, goodHits, perfectHits, missedHits;

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

                badText.text = badHits.ToString();                      // muudab floati stringiks
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missedText.text = missedHits.ToString();

                float accuracy = (currentScore / maxScore()) * 100;     // t2psus, mis on m2ngus saadud tulemuse ja antud leveli maksimaalse v6imaliku tulemuse protsentuaalne suhe

                Debug.Log(accuracy);

                accuracyText.text = accuracy.ToString("F1") + "%";

                string gradeValue = "F";

                switch(accuracy)
                {
                    case (> 95):
                        gradeValue = "S";
                        break;
                    case (> 90):
                        gradeValue = "A";
                        break;
                    case (> 80):
                        gradeValue = "B";
                        break;
                    case (> 70):
                        gradeValue = "C";
                        break;
                    case (> 60):
                        gradeValue = "D";
                        break;
                    case (> 50):
                        gradeValue = "E";
                        break;
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

    public float maxScore() // leiab leveli suurima potentsiaalse skoori
    {
        float total = 0;
        int comboType;
        float nextComboNotes = totalNotes;
        int maxThreshold = 1;

        if (totalNotes < comboThresholds[0])                                                // juhul, kui levelis on v2hem noote kui minimaalne combo koefitsendi m22r ytleb
        {
            total = totalNotes * perfectHitScore;
        }
        else
        {
            for (comboType = 0; comboType < maxThreshold; comboType++)                      // teeb tsyklit niikaua, kuni maksimaalsest v2iksema comboga noodid on kokku liidetud
            {
                total += perfectHitScore * (comboType + 1) * (comboThresholds[comboType]);  // comboThresholds[comboType] ehk mitu korda j2rjest tuleb nootidele pihta saada, et combo koefitsent t6useks
                nextComboNotes -= comboThresholds[comboType];                               // leiab, mitu nooti on levelis j22nud, millele rakendub veel k6rgema astme combo koefitsent

                if ((comboType + 1) != comboThresholds.Length)                              // kontrollib, kas eksisteerib veel j2rgmine combo koefitsent
                {
                    if (nextComboNotes > comboThresholds[comboType + 1])                    // kontrollib, kas on alles m6ni noot, millele j2rgmist combo koefitsenti rakendada
                    {
                        maxThreshold++;                                                     // kui jah, suurendab tsyklite arvu
                    }
                }
                Debug.Log(total);
            }
            total += perfectHitScore * (comboType + 1) * nextComboNotes;                    // liidab juurde ylej22nud noodid, millele saab rakendada suurimat v6imalikku combot
        }
        Debug.Log(total);
        return total;
    }
}
