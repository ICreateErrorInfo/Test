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
        //nimmt sich die position vom spieler
        xStart = transform.position.x;

        // nimmt die Änderung mal deltaTime
        xÄnderung *= Time.deltaTime;
    }

    void Update()
    {
        //erstellt aus der aktuellen pos. und der änderung ein float
        float xNeu = transform.position.x + xÄnderung;
        //erstellt einen neuen Vektor aus der aktuellen positon und xNeu
        transform.position = new Vector3(xNeu, transform.position.y, 0);

        //dreht die richtung um
        if ((xNeu > xStart + entfernung) || (xNeu < xStart - entfernung))
        {
            xÄnderung = -1 * xÄnderung;
        }

    }
}
