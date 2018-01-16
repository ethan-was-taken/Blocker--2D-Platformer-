using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {

    //public Scene toLoad;

    public int maxPlayerHealth;
    public static int playerHealth;
    public int currLevel;
    public static int levelForEnd;
    Text text;

    //private LevelManager levelManager;

    void Start() {

        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        Debug.Log("" + currLevel);
        levelForEnd = currLevel;
        levelForEnd++;

    }


    void FixedUpdate() {

        if (playerHealth <= 0) {
            playerHealth = 0;
            text.text = "0";
            loadScene();


        }
        else if(playerHealth >= maxPlayerHealth) {
            playerHealth = 100;
            text.text = "100";
        }else
            text.text = "" + playerHealth;

    }

    private void loadScene() {

        if(currLevel == 1)
            SceneManager.LoadScene("DeathScene1");
        else if(currLevel == 2)
            SceneManager.LoadScene("DeathScene2");
        else if(currLevel == 3)
            SceneManager.LoadScene("DeathScene3");

    }

    public static void hurtPlayer(int damageDelt) {
        playerHealth -= damageDelt;
    }

    public static void addHealth(int health) {
        playerHealth += health;
    }

    public void reset() {
        playerHealth = maxPlayerHealth;
        ScoreManagerScript.reset();
    }
}
