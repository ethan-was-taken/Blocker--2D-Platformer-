using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathSceneScript : MonoBehaviour {
    
    //this function will be used on our Start button
    public void StartLevel() {
        SceneManager.LoadScene(1);
    }

    public void Exit() {
        Application.Quit();
    }

    public void Begin() {
        SceneManager.LoadScene(2);
    }

    public void Retry1() {
        SceneManager.LoadScene(2);
    }

    public void Retry2() {
        SceneManager.LoadScene(4);
    }

    public void Retry3() {
        SceneManager.LoadScene(6);
    }

    public void Retry4() {
        SceneManager.LoadScene(8);
    }

    public void Return() {
        SceneManager.LoadScene(0);
    }

}
