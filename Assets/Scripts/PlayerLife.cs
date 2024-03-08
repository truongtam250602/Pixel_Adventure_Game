using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 3;
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if player on trigger trap(normal such as spike)
        if (collision.gameObject.CompareTag("Trap"))
        {
            ChangeHealth(-1);
        }
    }

    private void Die()
    {

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    public void ChangeHealth(int value)
    {
        if(value < 0)
        {
            anim.SetTrigger("Hit");
        }
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentHealth = maxHealth;
    }
}
