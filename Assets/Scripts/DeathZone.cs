using JetBrains.Annotations;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    GameObject _player;
    GameObject _spawn;

    [UsedImplicitly]
    private void Start() {
        //setzt die variablen
        _spawn = GameObject.FindGameObjectWithTag(TagNames.Spawn);
        _player = GameObject.FindGameObjectWithTag(TagNames.Player);
    }

    [UsedImplicitly]
    private void LateUpdate()
    {
        //setzt die position vom spieler
        transform.position = new Vector3(_player.transform.position.x, transform.position.y,transform.position.z);
    }
}
