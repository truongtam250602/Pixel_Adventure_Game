using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentWayPointIndex = 0;

    void Update()
    {
        if (currentWayPointIndex == 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (currentWayPointIndex == (wayPoints.Length - 1))
        {
            transform.localScale = Vector3.one;
        }
    }
}
