using JetBrains.Annotations;

using UnityEngine;

public class Detector: MonoBehaviour {

    GameObject Player;

    [UsedImplicitly]
    private void Start() {
        Player = gameObject.transform.parent.gameObject;
    }

    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ground") {

            Player.GetComponent<Spiel>().IsGrounded = true;

        }
    }

    [UsedImplicitly]
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Ground") {

            Player.GetComponent<Spiel>().IsGrounded = false;

        }
    }

}