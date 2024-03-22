using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour
{
    [SerializeField] private Image[] listBorder;
    [SerializeField] private GameObject[] listCharater;
    private Animator anim;
    private int index = 0;
    private void Start()
    {
        anim = GetComponent<Animator>();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.listCharacterAudio[0]);
    }
    public void ChooseBorder()
    {
        foreach (var item in listBorder)
        {
            item.GetComponent<Animator>().SetTrigger("Choose");
        }

        anim.SetTrigger("Clicked");
    }
    public void ChooseCharacter(int amount)
    {
        index = Mathf.Clamp(index + amount, 0, listCharater.Length-1);
        for(int i=0; i<listCharater.Length; i++)
        {
            if(i == index)
            {
                listCharater[i].SetActive(true);
                AudioManager.Instance.SFXSource.Stop();
                AudioManager.Instance.PlaySFX(AudioManager.Instance.listCharacterAudio[i]);
                Debug.Log(i);
            }
            else
            {
                listCharater[i].SetActive(false);
            }
        }
    }
}
