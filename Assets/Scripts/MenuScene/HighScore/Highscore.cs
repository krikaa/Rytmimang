using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text scoreText;
    public Text gradeText;
    public GameObject noAttemptsText;
    public string level;
    public string grade;
    public float highscore;

    // Start is called before the first frame update
    void Start()
    {
        level = gameObject.name;
        highscore = PlayerPrefs.GetFloat(level + "Highscore");
        grade = PlayerPrefs.GetString(level + "Grade");
        if (highscore > 0)
        {
            noAttemptsText.SetActive(false);
            scoreText.text = "" + highscore;
            gradeText.text = grade + " /";
        }
        else
        {
            scoreText.text = "";
            gradeText.text = "";
        }
    }
}
