using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    [SerializeField] private Transform followTrans;
    [SerializeField] private float rotateTime = 0;
    [SerializeField] private float rotateAngle;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float startAngle;   
    // Update is called once per frame
    void Update()
    {
        if (followTrans)
        {
            rotateTime += Time.deltaTime;
            followTrans.rotation = Quaternion.Euler(0, 0, rotateAngle * Mathf.Sin(startAngle + rotateTime * rotateSpeed));
        }
    }
}
