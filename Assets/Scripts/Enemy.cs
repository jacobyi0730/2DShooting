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
        // 만약 부딪힌 상대방의 이름에 Player라는 문자열이 포함되어있다면
        if (collision.gameObject.name.Contains("Player"))
        {
            // collision에게 PlayerHP컴포넌트를 가져오고싶다.
            PlayerHP php = collision.gameObject.GetComponent<PlayerHP>();
            // 체력을 1 감소하고싶다.
            php.HP--;

            if (php.HP <= 0)
            {
                // 너죽고 
                Destroy(collision.gameObject);
            }
        }
        else
        {
            // 나 : Enemy, 너(collision) : Bullet

            // 너죽고 
            Destroy(collision.gameObject);

            // 점수를 1점 증가시키고싶다.
            // GameObject.Find를 이용해서 구현하세요.
           
            ScoreManager.instance.SCORE++;
        }
      

        // 나죽자
        Destroy(this.gameObject);

        //print(collision.gameObject.name);
    }

}
