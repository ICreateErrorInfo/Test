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
        //prüft ob der spieler im Item ist
        // und zerstört die barikade bei Tastendruck
        if (_insideItem && Input.GetButtonDown(Steuerung.Benutzen)) {
            Obj.SetActive(false);
            Stats.Instance.BarikadeIsShown = false;
            gameObject.SetActive(false);
            Stats.Instance.EntfernerItemIsShown = false;
            EText.gameObject.SetActive(false);
        }

        // Läst den Timer hochzählen
        if (_insideItem) {
            _timer += 1;
            Debug.Log(_timer);
        }

        //läst den Text anzeigen wenn timer größer ist als 100
        // und wenn das spiel nicht pausiert ist
        if (_timer >= 100 && Time.timeScale > 0) {
            EText.gameObject.SetActive(true);
        }
    }

}