using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 태어나면 목적지로 이동하고싶다.
// 이동이 끝나면 공격하고싶다.
// 공격이 끝나면 3초 대기하고싶다.
// 공격과 대기를 반복하고싶다.
public class Boss : MonoBehaviour
{
    const int MOVE = 0;
    const int ATTACK = 1;
    const int WAIT = 2;

    int state;
    public float speed = 10;

    public Transform moveTarget;

    // Start is called before the first frame update
    void Start()
    {
        state = MOVE;
        moveTarget = GameObject.Find("BossTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 나는 한번에 한가지 상태만 처리할 수 있다.
        switch (state)
        {
            case MOVE:
                UpdateMove();
                break;
            case ATTACK:
                UpdateAttack();
                break;
            case WAIT:
                UpdateWait();
                break;
        }
    }

    // 목적지까지 이동하고싶다.
    // 목적지에 도착했다면 
    // 공격행위를 하고싶다.
    private void UpdateMove()
    {
        Vector3 dir = moveTarget.position - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;

        // 도착했다면
        if (dir.magnitude < 0.1f)
        {
            // 공격행위를 하고싶다.
            transform.position = moveTarget.position;
            state = ATTACK;
        }
    }

    public GameObject bossBulletFactory;
    float angleZ;
    public float oneStepAngle = 30;
    public float fireTime = 0.1f;
    public float maxAngle = 360;
    private void UpdateAttack()
    {
        currentTime += Time.deltaTime;
        if (currentTime > fireTime)
        {
            currentTime = 0;
            // 공격을 하고
            GameObject bullet = Instantiate(bossBulletFactory);
            bullet.transform.position = this.transform.position;
            bullet.transform.eulerAngles = new Vector3(0, 0, angleZ);
            angleZ += oneStepAngle;
        }

        // 만약 angleZ가 maxAngle이상이라면
        if (angleZ >= maxAngle)
        {
            // 쉬고싶다.
            state = WAIT;
            currentTime = 0;
            angleZ = 0;
        }
    }

    float currentTime = 0;
    public float waitTime = 3;
    private void UpdateWait()
    {
        // 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 만약 대기시간이 되면
        if (currentTime > waitTime)
        {
            // 공격행위를 하고싶다.
            state = ATTACK;
            currentTime = 0;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // 총알은 ObjectPool로 되어있으니 파괴하지않고 비활성화 한다.
            other.gameObject.SetActive(false);
            // 비활성 목록에 다시 추가한다.
            PlayerFire.deActiveBulletObjectPool.Add(other.gameObject);
        }
        // 나죽자
        Destroy(this.gameObject);
    }
}
