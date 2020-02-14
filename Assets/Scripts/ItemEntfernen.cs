using JetBrains.Annotations;

using UnityEngine;

public class ItemEntfernen: MonoBehaviour {

    public GameObject Obj;

    private bool _insideItem;

    [UsedImplicitly]
    private void Update() {
        if (_insideItem && Input.GetKeyDown(KeyCode.E)) {
            Destroy(Obj);
        }
    }

    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            _insideItem = true;
        }
    }

    [UsedImplicitly]
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            _insideItem = false;
        }
    }

}