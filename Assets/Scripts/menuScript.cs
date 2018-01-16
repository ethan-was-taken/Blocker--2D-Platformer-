using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {
   
    public void StartLevel() {
        SceneManager.LoadScene("1");
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void Exit() {
        Application.Quit();
    }

    public void Begin() {
        SceneManager.LoadScene(2);
    }

    public void Retry1() {
        SceneManager.LoadScene("1");
    }

    public void Retry2() {
        SceneManager.LoadScene("2");
    }

    public void Retry3() {
        SceneManager.LoadScene("3");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

}