using JetBrains.Annotations;

using TMPro;

using UnityEngine;

public class ItemEntfernen: MonoBehaviour {

    public  GameObject      Obj;
    [HideInInspector]
    public int             _timer;
    [HideInInspector]
    public bool            _insideItem;
    public  TextMeshProUGUI EText;

    [UsedImplicitly]
    private void Update() {
        if (_insideItem && Input.GetButtonDown(Steuerung.Benutzen)) {
            Destroy(Obj);
            gameObject.SetActive(false);
            EText.gameObject.SetActive(false);
        }

        if (_insideItem) {
            _timer += 1;
            Debug.Log(_timer);
        }

        if (_timer >= 100 && Time.timeScale > 0) {
            EText.gameObject.SetActive(true);

            //  EText.text = "Press E";
        }
    }

}