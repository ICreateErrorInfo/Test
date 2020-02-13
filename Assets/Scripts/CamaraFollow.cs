using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public GameObject player;
    float unterschied;

    private void Start()
    {
        unterschied = transform.position.x - player.transform.position.x;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + unterschied, transform.position.y, transform.position.z);
    }
}
