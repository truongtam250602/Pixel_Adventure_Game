using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCharacter : MonoBehaviour
{
    [SerializeField] private List<GameObject> listGameObjectPayer;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private GameObject avatar;

    private string[] animations = {"Ninja Fog Run", "Virtual Guy Run", "Pink Man Run", "Mask Dude Run" };
    private string characterStr;
    void Awake()
    {
        characterStr = PlayerPrefs.GetString("Character");
        foreach(GameObject item in listGameObjectPayer)
        {
            if(item.name == characterStr)
            {
                item.SetActive(true);
                avatar.GetComponent<Animator>().Play(animations[listGameObjectPayer.IndexOf(item)]);
                playerCamera.Follow = item.transform;
            }
            else
            {
                item.SetActive(false);
                
            }
        }
    }
}
