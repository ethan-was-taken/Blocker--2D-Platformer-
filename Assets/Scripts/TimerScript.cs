using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    Text text;

    void Start() {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        text.text = Time.timeSinceLevelLoad.ToString("F2");
    }
}
