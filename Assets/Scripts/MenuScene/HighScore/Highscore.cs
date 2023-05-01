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
        level = gameObject.name;                                // v6tab levelinime objektinime kaudu, mille kylge skript kinnitatud on
        highscore = PlayerPrefs.GetFloat(level + "Highscore");  // v6tab m2ngu salvestatud v22rtuste hulgast leveli nime kaudu k6rgeima saavutatud skoori
        grade = PlayerPrefs.GetString(level + "Grade");         // v6tab m2ngu salvestatud v22rtuste hulgast leveli nime kaudu k6rgeima saavutatud hinde
        if (highscore > 0)                                      // kui saavutatud k6rgeim skoor on k6rgem kui 0,
        {
            noAttemptsText.SetActive(false);                    // peidab teksti, mis kuvatakse juhul kui m2ngimiskatsed puuduvad
            scoreText.text = "" + highscore;                    // m22rab skoori teksikasti tekstiks k6rgeima salvestatud skoori
            gradeText.text = grade + " /";                      // m22rab hinde teksikasti tekstiks k6rgeima salvestatud hinde
        }
        else
        {
            scoreText.text = "";                                // tyhjendab skoori tekstikasti
            gradeText.text = "";                                // tyhjendab hinde tekstikasti
        }
    }
}
