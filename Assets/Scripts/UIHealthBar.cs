using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < PlayerLife.Instance.currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }

        SetIdleAvatar();
    }

    private void SetIdleAvatar()
    {
        if (PlayerLife.Instance.currentHealth <= 0)
        {
            GameObject.FindGameObjectWithTag("Avatar").GetComponent<Animator>().SetBool("Idle", true);
        }
    }
}
