using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string highscoreName;
    public string highgradeName;

    public AudioSource music;
    public AudioSource hitSound;

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

    public float totalNotes = 0;
    public float noteCounter = 0;
    public float badHits, goodHits, perfectHits, missedHits;

    public float accuracy;

    public GameObject scoreboard;
    public Text perfectText, goodText, badText, missedText, accuracyText, totalScoreText, gradeText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;                                           // kasutab GameManager koodina seda sama koodi

        scoreText.text = "SCORE: 0";                               // annab skoorilugejale algse v22rtuse
        currentCombo = 1;                                          // annab combolugejale algse v22rtuse

        hitSound.GetComponent<AudioSource>();
    }                                                              

    // Update is called once per frame
    void Update()
    {
        if (totalNotes == 0)
        {
            totalNotes = FindObjectsOfType<ButtonDetections>().Length; // leiab k6ik objektid, millel on ButtonDetections
        }                                                              // script kyljes ja tagastab pikkuse floatina

        if (!startMusic)
        {
            if (Input.anyKeyDown)                                  // klahvi vajutades hakkab level pihta
            {
                startMusic = true;
                FN.startLevel = true;

                music.Play();
            }
        }
        else
        {
            if(noteCounter == totalNotes && !scoreboard.activeInHierarchy)       // kui level saab l2bi
            {
                scoreboard.SetActive(true);                             // siis n2ita skooritabelit

                badText.text = badHits.ToString();                      // muudab floati stringiks
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missedText.text = missedHits.ToString();

                float accuracy = (currentScore / maxScore()) * 100;     // t2psus, mis on m2ngus saadud tulemuse ja antud leveli maksimaalse v6imaliku tulemuse protsentuaalne suhe

                Debug.Log(accuracy);

                accuracyText.text = accuracy.ToString("F1") + "%";      // muudab t2psuse floati stringiks

                string gradeValue = "F";                                // hindelise tulemuse algne v22rtus

                switch(accuracy)                                        // muudab hinnet vastavalt t2psusele
                {
                    case (> 95):
                        gradeValue = "S";
                        break;
                    case (> 90):
                        gradeValue = "A";
                        break;
                    case (> 80):
                        gradeValue = "b";
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

                totalScoreText.text = currentScore.ToString();         // muudab tulemuse floati stringiks

                if ((PlayerPrefs.GetFloat(highscoreName)) < currentScore)
                {
                    PlayerPrefs.SetFloat(highscoreName, currentScore);
                    PlayerPrefs.SetString(highgradeName, gradeValue);
                }
            }
        }
    }

    public void NoteHit()                                              //arvutab combo koefitsenti ja muudab skoorilugejat ja combolugejat
    {
        Debug.Log("Hit on Time");
        hitSound.Play();
        if (currentCombo - 1 < comboThresholds.Length)                 // kui combo ei ole veel maksimaalne
        {
            comboTracker++;                                            // inkrementeeri muutujat, mille piisaval kasvamisel t6useb combo koefitsent 1 v6rra

            if (comboThresholds[currentCombo - 1] <= comboTracker)     // kui comboTracker on piisavalt suur
            {
                comboTracker = 0;                                      // siis anna j2lle algne v22rtus
                currentCombo++;                                        // siis t6sta combo koefitsenti
            }
        }

        comboText.text = "COMBO: X" + currentCombo;

        scoreText.text = "SCORE: " + currentScore;

        noteCounter++;
    }

    public void BadHit()                                              // liidab skoorile juurde halva tabamusega saadava skoori * combo koefitsent, kusjuures inkrementeerib halbade tabamuste hulka
    {
        currentScore += badHitScore * currentCombo;
        NoteHit();                                                    // loeb sisse tabatud noodi
        
        badHits++;
    }

    public void GoodHit()                                             // liidab skoorile juurde hea tabamusega saadava skoori * combo koefitsent, kusjuures inkrementeerib heade tabamuste hulka
    {
        currentScore += goodHitScore * currentCombo;
        NoteHit();                                                    // loeb sisse tabatud noodi

        goodHits++;
    }

    public void PerfectHit()                                          // liidab skoorile juurde perfektse tabamusega saadava skoori * combo koefitsent, kusjuures inkrementeerib perfektsete tabamuste hulka
    {
        currentScore += perfectHitScore * currentCombo;
        NoteHit();                                                    // loeb sisse tabatud noodi

        perfectHits++;
    }

    public void NoteMissed()                                          // annab combo koefitsendile ja comboTrackerile algse v22rtuse, kusjuures inkrementeerib tabamata nootide hulka
    {
        Debug.Log("Missed");

        currentCombo = 1;
        comboTracker = 0;

        comboText.text = "COMBO: x" + currentCombo;

        missedHits++;

        noteCounter++;
    }

    public float maxScore()      // leiab leveli suurima potentsiaalse skoori
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
