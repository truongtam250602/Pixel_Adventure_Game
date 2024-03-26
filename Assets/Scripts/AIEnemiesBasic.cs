using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemiesBasic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float delayTime;
    private float waitTime;
    private int i = 0;
    private Animator anim;
    private enum MovementState { idle, running, hit, death }
    void Start()
    {
        anim = GetComponent<Animator>();
        waitTime = delayTime;
    }

    void Update()
    {
        TransformAuto();
    }

    private void TransformAuto()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[i].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoints[i].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                anim.SetInteger("State", (int)MovementState.running);
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
                anim.SetInteger("State", (int)MovementState.idle);
                waitTime -= Time.deltaTime;
            }
        }
    }
}
