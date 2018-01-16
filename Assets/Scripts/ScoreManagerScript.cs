using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {

    public static int score;
    Text text;

    void Start() {

        text = GetComponent<Text>();
        score = 0;

    }


    void Update() {

        if (score < 0)
            score = 0;

        text.text = score.ToString();
   
    } 

    public static void addPoints(int pointsToAdd) {
        score += pointsToAdd;
    }

    public static void reset() {
        score = 0;
    }
}
