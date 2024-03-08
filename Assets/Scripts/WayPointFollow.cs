using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private float speed = 2f;
    private int currentWayPointIndex = 0;
    private bool isReversed = false;

    private void Update()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            if(isReversed == false)
            {
                currentWayPointIndex++;
                if (currentWayPointIndex >= wayPoints.Length)
                {
                    currentWayPointIndex--;
                    isReversed = true;
                    if (gameObject.CompareTag("Trap"))
                    {
                        transform.localScale = Vector3.one;
                    }
                }
            }
            else
            {
                currentWayPointIndex--;
                if (currentWayPointIndex < 0)
                {
                    currentWayPointIndex++;
                    isReversed = false;
                    if (gameObject.CompareTag("Trap"))
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
