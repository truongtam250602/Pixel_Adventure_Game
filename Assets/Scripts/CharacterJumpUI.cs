using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpUI : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Idle()
    {
        anim.SetBool("Idle", true);
    }
}
