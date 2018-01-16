using UnityEngine;
using System.Collections;

public class HealthPackScript : MonoBehaviour {

    public int HealthToAdd;
    public AudioClip toPlay;
    AudioSource source;

    private bool shouldDestroy = false;

    void Start() {

        source = gameObject.GetComponent<AudioSource>();

    }

    void Update() {

        if (source.isPlaying && shouldDestroy) {
            Debug.Log("kjfdsbadhfagpi;kfag");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (!source.isPlaying && shouldDestroy) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag != "Player" || shouldDestroy == true || HealthManager.playerHealth == 100)
            return;

        HealthManager.addHealth(HealthToAdd);
        source.Play();
        shouldDestroy = true;

    }
}
