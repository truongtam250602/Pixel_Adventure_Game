using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spRenderer;
    [SerializeField] private Collider2D coll;
    [SerializeField] private GameObject brokenParts;
    [SerializeField] private int lifes = 1;
    [SerializeField] private GameObject BoxCollider;
    void Start()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            LosseLifeAndHit();
        }
    }
    private void LosseLifeAndHit()
    {
        lifes--;
        anim.SetTrigger("Hit");
        CheckLife();
    }
    private void CheckLife()
    {
        if(lifes <= 0)
        {
            brokenParts.SetActive(true);
            BoxCollider.SetActive(false);
            coll.enabled = false;
            spRenderer.enabled = false;
            DestroyBox();
        }
    }
    private void DestroyBox()
    {
        Destroy(gameObject, 0.5f);
    }
}
