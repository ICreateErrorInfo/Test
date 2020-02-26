using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gefahren : MonoBehaviour
{
    float xStart;
    public float xÄnderung;
    public int entfernung;

    void Start()
    {
        xStart = transform.position.x;
        xÄnderung *= Time.deltaTime;
    }

    void Update()
    {
        float xNeu = transform.position.x + xÄnderung;
        transform.position = new Vector3(xNeu, transform.position.y, 0);

        if ((xNeu > xStart + entfernung) || (xNeu < xStart - entfernung))
        {
            xÄnderung = -1 * xÄnderung;
        }

    }
}
