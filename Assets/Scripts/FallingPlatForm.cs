using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatForm : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float timeDelay;
    [SerializeField] private float timeDestroy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", timeDelay);
            Destroy(gameObject, timeDestroy);
        }
    }

    private void Fall()
    {
        rb.isKinematic = false;
    }
}
