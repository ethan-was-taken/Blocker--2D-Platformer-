using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {

    public GameObject player;
    public AudioClip toPlay;
    AudioSource source;

    public int dmg;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        source = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D coll) {

        if (coll.gameObject.tag == "Player") {
            knockBack(coll);
            HealthManager.hurtPlayer(dmg);

            if (source.isPlaying)
                source.Stop();
            source.Play();
        }
    }

    private void knockBack(Collider2D coll) {

        Rigidbody2D temp = coll.GetComponent<Rigidbody2D>();
        player.GetComponent<UnitySampleAssets._2D.PlatformerCharacter2D>().airControl = false;

        float speedX = player.GetComponent<Rigidbody2D>().velocity.x;
        float speedY = player.GetComponent<Rigidbody2D>().velocity.y;

        speedY *= 1.5f;

        // Kill y velocity
        temp.velocity = new Vector2(0, 0);

        if (speedX < 0)
            temp.AddForce(new Vector2(-10, 15), ForceMode2D.Impulse);
        else if (speedX >= 0)
            temp.AddForce(new Vector2(10, 15), ForceMode2D.Impulse);
        //player.GetComponent<UnitySampleAssets._2D.PlatformerCharacter2D>().airControl = true;

    }

}
