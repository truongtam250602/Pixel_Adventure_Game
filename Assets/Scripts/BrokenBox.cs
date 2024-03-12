using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBox : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-8, 8), Random.Range(0, 5));
        Destroy(gameObject,Random.Range(1f,2f));
    }
}
