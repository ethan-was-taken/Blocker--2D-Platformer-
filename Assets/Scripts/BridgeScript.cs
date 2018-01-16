using UnityEngine;
using System.Collections;

public class BridgeScript : MonoBehaviour {

    public GameObject bouce;
    public GameObject bridge;
    public GameObject bounceToSpawn;

    void Start() {

        bounceToSpawn = GameObject.Find("Bounce Box (4)");

    }

    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("1");
        if (coll.gameObject.tag == "Player") {
            Debug.Log("2");
            remove();
        }

        bounceToSpawn.GetComponent<BoxCollider2D>().enabled = true;

    }

    public void remove() {
        Destroy(bridge);
    }

}
