using System.Collections;
using System.Collections.Generic;

using JetBrains.Annotations;

using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public GameObject Player;

    [UsedImplicitly]
    private void Start()
    {
        
    }
    [UsedImplicitly]
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Player.GetComponent<Spiel>().ExtraJump  = 2;
            Player.GetComponent<Spiel>().ExtraJump2 = 2;
        }
    }
}
