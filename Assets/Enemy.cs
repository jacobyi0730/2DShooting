using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

// 태어날 때 방향을 정하고싶다.
// 30%의 확률로 플레이어 방향, 나머지 확률로 아래로 정하고싶다.
// 살아가면서 그 방향으로 이동하고싶다.

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 방향을 정하고싶다.
        // 30%의 확률로 플레이어 방향, 나머지 확률로 아래로 정하고싶다.
        int rValue = Random.Range(0, 10);
        if (rValue < 3)
        {
            // 플레이어방향
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - this.transform.position;
            dir.Normalize();
        }
        else
        {
            // 아래방향
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 아래로 이동하고싶다. 초속 5m/s
        // P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 너죽고 
        Destroy(collision.gameObject);
        // 나죽자
        Destroy(this.gameObject);

        //print(collision.gameObject.name);
    }

}
