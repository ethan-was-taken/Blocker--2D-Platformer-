using UnityEngine;
using System.Collections;

public class BodyBlockScript : MonoBehaviour {

    public static float speed = 60f;
    private Rigidbody2D rigid;
    public bool isOnBoundary;

    public AudioClip toPlay;
    AudioSource source;

    public GameObject player;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        isOnBoundary = false;
        this.GetComponent<BoxCollider2D>().usedByEffector = true;
        this.GetComponent<SurfaceEffector2D>().useColliderMask = true;
        player = GameObject.FindGameObjectWithTag("Player");
        source = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if(player.GetComponent <UnitySampleAssets._2D.PlatformerCharacter2D>().bodyBlockCleared) {
            this.GetComponent<SurfaceEffector2D>().useColliderMask = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll) {

        // 8 = Boundaries
        if (coll.gameObject.layer == 8 /*&& temp*/) {
            Debug.Log(coll.gameObject.name + "");
            rigid.isKinematic = true;
            if (source.isPlaying)
                source.Stop();
            source.Play();
        }
        if(coll.gameObject.layer == 4 || coll.gameObject.layer == 15) {
            if (source.isPlaying)
                source.Stop();
            source.Play();
            Debug.Log("Desty");
            Destroy(this.gameObject);
        }

    }

}
