using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float jumpForce;
    [SerializeField] private SpriteRenderer spRenderer;
    [SerializeField] private Collider2D coll;
    [SerializeField] private GameObject brokenParts;
    [SerializeField] private int lifes = 1;
    [SerializeField] private GameObject BoxCollider;
    [SerializeField] private GameObject? itemCollector;
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            LosseLifeAndHit();
            if(lifes <= 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            }
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
            if (!itemCollector.IsUnityNull())
            {
                itemCollector.SetActive(true);
            }
        }
    }
    private void DestroyBox()
    {
        Destroy(gameObject, 0.5f);
    }
}
