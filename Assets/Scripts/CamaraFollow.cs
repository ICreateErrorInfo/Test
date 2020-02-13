using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 unterschied;

    private void Start()
    {
        unterschied = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + unterschied;
    }
}
