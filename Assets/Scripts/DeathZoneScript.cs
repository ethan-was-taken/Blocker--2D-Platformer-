using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathZoneScript : MonoBehaviour {

    public int currLevel;
   

    void Start() {
       
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Player")
            return;
        if (currLevel == 1)
            SceneManager.LoadScene("DeathScene1");
        else if (currLevel == 2)
            SceneManager.LoadScene("DeathScene2");
        else if (currLevel == 3)
            SceneManager.LoadScene("DeathScene3");
    }

}
