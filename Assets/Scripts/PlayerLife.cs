using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    public static PlayerLife Instance;
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxHealth = 3;
    [SerializeField] private GameObject UILoseGame;

    AudioManager audioManager;
    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if player on trigger trap(normal such as spike)
        if (collision.gameObject.CompareTag("Trap")) // hit 
        {
            ChangeHealth(-1);
        }
        else if (collision.gameObject.CompareTag("Heart")) // collect heart
        {
            if(currentHealth < maxHealth)
            {
                ChangeHealth(1);
                Destroy(collision.gameObject);
                audioManager.PlaySFX(audioManager.collectHeartAudio);
            }
        }
    }

    private IEnumerator Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        audioManager.PlaySFX(audioManager.deathAudio);
        yield return new WaitForSeconds(3f);
        PlayerController.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        UILoseGame.SetActive(true);
        yield return new WaitForSeconds(2f);
    }

    public void ChangeHealth(int value)
    {
        if(value < 0)
        {
            anim.SetTrigger("Hit");
            audioManager.PlaySFX(audioManager.hitAudio);
        }
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        if (currentHealth <= 0)
        {
            StartCoroutine(ShakeCameraController.Instance.ShakeCamera());
            StartCoroutine(Die());
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentHealth = maxHealth;
    }
}
