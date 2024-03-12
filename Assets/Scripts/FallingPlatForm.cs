using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatForm : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool falling = false;
    [SerializeField] private float timeFallDelay;
    [SerializeField] private float timeDestroyDelay;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (falling)
        {
            return;
        }
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        falling = true;
        yield return new WaitForSeconds(timeFallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
