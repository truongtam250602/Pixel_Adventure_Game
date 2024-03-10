using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private Animator anim;
    private bool collisioned;
    [SerializeField] private int damage;
    [SerializeField] private float timeDelay;
    [SerializeField] private float timeActive;
    [SerializeField] private GameObject fireZone;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fireZone.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (!collisioned)
            {
                StartCoroutine(ActiveFireTrap());
            }
        }
    }

    private IEnumerator ActiveFireTrap()
    {
        collisioned = true;
        yield return new WaitForSeconds(timeDelay);
        anim.SetBool("On", true);
        fireZone.SetActive(true);
        yield return new WaitForSeconds(timeActive);
        collisioned = false;
        anim.SetBool("On", false);
        fireZone.SetActive(false);
    }
   
}
