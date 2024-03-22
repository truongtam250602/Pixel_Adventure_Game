using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    [SerializeField] private Collider2D coll;
    [SerializeField] private Collider2D collDamage;
    [SerializeField] private float jumpForce;
    [SerializeField] private int lifes;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            LosseLifeAndHit();
            CheckDie();
        }
    }
    private void LosseLifeAndHit()
    {
        lifes--;
        anim.Play("Hit");
    }
    private void CheckDie()
    {
        if(lifes <= 0)
        {
            gameObject.layer = 7;
            collDamage.enabled = false;
            anim.Play("Death");
            StartCoroutine(DestroyEnemie());
        }
    }
    private IEnumerator DestroyEnemie()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
