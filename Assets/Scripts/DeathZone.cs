using JetBrains.Annotations;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    GameObject _player;

    [UsedImplicitly]
    private void Start() {
        _player = GameObject.FindGameObjectWithTag(TagNames.Player);
    }

    [UsedImplicitly]
    private void LateUpdate()
    {
        //setzt die position vom spieler
        transform.position = new Vector3(_player.transform.position.x, transform.position.y,transform.position.z);
    }
}
