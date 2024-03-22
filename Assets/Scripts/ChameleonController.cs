using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChameleonController : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Transform pointRaycast;
    [SerializeField] private LayerMask playerPayer;
    [SerializeField] private float speed;
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float delayTime;
    private float waitTime;

    private int i = 0;
    private Animator anim;
    private enum MovementState {idle, running, attack, hit }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (IsPlayer())
        {
            Attack();
        }
        else
        {
            TransformAuto();
        }
    }
    private void TransformAuto()
    {
        anim.SetInteger("State", (int)MovementState.running);
        transform.position = Vector2.MoveTowards(transform.position, movePoints[i].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, movePoints[i].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (movePoints[i] != movePoints[movePoints.Length - 1])
                {
                    transform.localScale = Vector3.one;
                    i++;
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    i = 0;
                }
                waitTime = delayTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    private void Attack()
    {
        anim.SetInteger("State", (int)MovementState.attack);
    }
    private bool IsPlayer()
    {
        if(Physics2D.Raycast(pointRaycast.position + new Vector3(distance, 0, 0), Vector2.right, distance, playerPayer) 
           || Physics2D.Raycast(pointRaycast.position + new Vector3(-distance, 0, 0), Vector2.left, distance, playerPayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
