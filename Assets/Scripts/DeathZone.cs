using System.Collections;
using System.Collections.Generic;

using JetBrains.Annotations;

using UnityEngine;

public class DeathZone : MonoBehaviour {

    GameObject _player;
    GameObject _spawn;

    [UsedImplicitly]
    private void Start() {
        _spawn = GameObject.FindGameObjectWithTag("Spawn");
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    [UsedImplicitly]
    private void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, transform.position.y,transform.position.z);
    }

    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

            _player.transform.position = _spawn.transform.position;

        }
    }
}
