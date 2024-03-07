using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStartPoint : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetBool("start", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetBool("start", false);
        }
    }
}
