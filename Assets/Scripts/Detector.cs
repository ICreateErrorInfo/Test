using JetBrains.Annotations;

using UnityEngine;

public class Detector: MonoBehaviour {

    GameObject _player;

    [UsedImplicitly]
    private void Start() {
        //variable gesetzt
        _player = gameObject.transform.parent.gameObject;
    }

    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision) {
        //prüft ob der spieler den boden berührt 
        if (collision.tag == TagNames.Ground) {

            _player.GetComponent<PlayerControllre>().IsGrounded = true;

        }
    }

    [UsedImplicitly]
    private void OnTriggerExit2D(Collider2D collision) {
        //prüft ob der spieler den boden verlässt
        if (collision.tag == TagNames.Ground) {

            _player.GetComponent<PlayerControllre>().IsGrounded = false;

        }
    }

}