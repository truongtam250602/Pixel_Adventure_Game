using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndPoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem endEffect;
    [SerializeField] private GameObject UIWinGame;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EndEffectActive());
            PlayerController.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            audioManager.PlaySFX(audioManager.cannonAudio);
            audioManager.PlaySFX(audioManager.winGameAudio);
            UIWinGame.SetActive(true);
        }
    }

    IEnumerator EndEffectActive()
    {
        endEffect.Play();
        yield return new WaitForSeconds(2f);
    }
}
