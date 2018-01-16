using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IHateUnity : MonoBehaviour {

    public int currLevel;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player" && currLevel !=3)
            SceneManager.LoadScene(HealthManager.levelForEnd+"");
        else if(currLevel == 3) {

            SceneManager.LoadScene("Successssss");

        }
    }

}
