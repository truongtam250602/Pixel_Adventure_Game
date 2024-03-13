using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private AudioSource soundTrampoline;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        anim.SetBool("Jump", true);
        soundTrampoline.Play();
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Jump", false);
    }

}
