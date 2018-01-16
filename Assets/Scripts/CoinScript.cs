using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

    public int pointsToAdd = 10;
    public AudioClip toPlay;
    AudioSource source;

    private bool shouldDestroy = false;

    void Start() {
        source = gameObject.GetComponent<AudioSource>();
    }

    void LateUpdate() {

        if (source.isPlaying && shouldDestroy) {
            //Debug.Log("kjfdsbadhfagpi;kfag");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (!source.isPlaying && shouldDestroy) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag != "Player" || shouldDestroy)
            return;
        
        ScoreManagerScript.addPoints(pointsToAdd);
        source.Play();
        shouldDestroy = true;

    }

}
