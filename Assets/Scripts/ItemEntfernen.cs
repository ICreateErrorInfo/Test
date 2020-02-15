using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ItemEntfernen: MonoBehaviour {

    public GameObject Obj;
    private int _timer;
    private bool _insideItem;
    public TextMeshProUGUI EText;


        [UsedImplicitly]
    private void Update() {
        if (_insideItem && Input.GetButtonDown(Steuerung.Benutzen)) {
            Destroy(Obj);
            EText.enabled = false;
            gameObject.SetActive(false);
        }

        if (_insideItem) {
            _timer += 1;
            Debug.Log(_timer);
        }

        if (_timer >= 100) {
            EText.text = "Press E";
        }
    }

    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == TagNames.Player) {
            _insideItem = true;
        }
    }

    [UsedImplicitly]
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == TagNames.Player) {
            _insideItem = false;
            EText.enabled = false;
            _timer = 0;
        }
    }

}