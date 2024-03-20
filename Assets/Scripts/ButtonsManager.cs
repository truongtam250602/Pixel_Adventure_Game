using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private TMP_Text text;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnClick()
    {
        StartCoroutine(Clicked());  
    }
    public IEnumerator Clicked()
    {
        anim.SetBool("Clicked", true);
        text.GetComponent<RectTransform>().localPosition = new Vector3 (0f, 0f, 0f);
        yield return new WaitForSeconds(0.2f);
        text.GetComponent<RectTransform>().localPosition = new Vector3 (0f, 3.4f, 0f);
        anim.SetBool("Clicked", false);
    }
}
