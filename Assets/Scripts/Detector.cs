using JetBrains.Annotations;

using UnityEngine;

public class Detector: MonoBehaviour {

    GameObject _player;

    [UsedImplicitly]
    private void Start() {
        _player = gameObject.transform.parent.gameObject;
    }

    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == TagNames.Ground) {

            _player.GetComponent<Spiel>().IsGrounded = true;

        }
    }

    [UsedImplicitly]
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == TagNames.Ground) {

            _player.GetComponent<Spiel>().IsGrounded = false;

        }
    }

}