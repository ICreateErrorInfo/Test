using JetBrains.Annotations;

using UnityEngine;

public class CamaraFollow: MonoBehaviour {

    public GameObject Player;

    Vector3           _unterschied;

    [UsedImplicitly]
    private void Start() {
        _unterschied = transform.position - Player.transform.position;
    }

    [UsedImplicitly]
    private void LateUpdate() {
        transform.position = Player.transform.position + _unterschied;
    }

}