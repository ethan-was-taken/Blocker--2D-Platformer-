using UnityEngine;
using System.Collections;

public class SkullSpearScript : MonoBehaviour {

    //Negative so that it goes down instead of up
    public float speedY = -10f;
    public float speedX = 0f;

    private Rigidbody2D rigid;
    public GameObject player;
    public AudioClip toPlay;
    AudioSource source;

    private bool shouldDestroy = false;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(speedX, speedY);
        player = GameObject.FindGameObjectWithTag("Player");
        source = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        checkAudio();
    }

    private void checkAudio() {

        if (!source.isPlaying && shouldDestroy) {
            Debug.Log("spear");
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D coll) {

        if (coll.gameObject.tag == "Player") {
            knockBack(coll);
            HealthManager.hurtPlayer(66);

            if (source.isPlaying)
                source.Stop();
            source.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            shouldDestroy = true;

        }
        else if (coll.gameObject.tag == "Enviro")
            Destroy(gameObject);
        else if(coll.gameObject.tag == "BodyBlock") {
            Destroy(coll.gameObject);
        }

    }

    private void knockBack(Collider2D coll) {

        Rigidbody2D temp = coll.GetComponent<Rigidbody2D>();
        player.GetComponent<UnitySampleAssets._2D.PlatformerCharacter2D>().airControl = false;

        if (speedX < 0 && !player.GetComponent<UnitySampleAssets._2D.PlatformerCharacter2D>().grounded) {
            temp.AddForce(new Vector2(-15, 0), ForceMode2D.Impulse); Debug.Log("a2");
        }
        else if (speedX >= 0) {
            temp.AddForce(new Vector2(15, 10), ForceMode2D.Impulse); Debug.Log("a3");
        }
        else {
            temp.AddForce(new Vector2(0, 10), ForceMode2D.Impulse); Debug.Log("a4");
        }

    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.tag == "Enviro") 
            Destroy(gameObject);
        else if (coll.gameObject.tag == "BodyBlock") 
            Destroy(coll.gameObject);

    }
}
