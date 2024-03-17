using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    public float speed;
    public float waitTime;
    public float patrolDistance; // �������Զ����Ѳ�߾���

    private Transform[] moveSpots; // �޸�Ϊ˽�б���
    private int i = 0;
    private bool movingRight = true;
    private float wait;

    // Use this for initialization
    public new void Start()
    {
        base.Start();
        wait = waitTime;

        // ��̬����Ѳ�ߵ�
        InitializeMoveSpots();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = true;
                }

                i = i == 0 ? 1 : 0; // �򻯵��л��߼�

                waitTime = wait;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void InitializeMoveSpots()
    {
        moveSpots = new Transform[2]; // ����������
        GameObject leftSpot = new GameObject("LeftPatrolPoint");
        GameObject rightSpot = new GameObject("RightPatrolPoint");

        leftSpot.transform.position = new Vector2(transform.position.x - patrolDistance, transform.position.y);
        rightSpot.transform.position = new Vector2(transform.position.x + patrolDistance, transform.position.y);

        moveSpots[0] = leftSpot.transform;
        moveSpots[1] = rightSpot.transform;
    }
}