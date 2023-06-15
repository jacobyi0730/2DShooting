using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

// 태어날 때 방향을 정하고싶다.
// 30%의 확률로 플레이어 방향, 나머지 확률로 아래로 정하고싶다.
// 살아가면서 그 방향으로 이동하고싶다.
// 내(Enemy)가 파괴될 때 폭발공장에서 폭발을 만들어서 내위치에 배치하고싶다. 폭발은 2초 후에 파괴되게 하고싶다.
public class Enemy : MonoBehaviour
{
    public GameObject explosionFactory;
    Vector3 dir;
    public float speed = 5;

    EnemyHP enemyHP; // cache

    // Start is called before the first frame update
    void Start()
    {
        enemyHP = GetComponent<EnemyHP>();

        // 태어날 때 방향을 정하고싶다.
        // 30%의 확률로 플레이어 방향, 나머지 확률로 아래로 정하고싶다.
        int rValue = Random.Range(0, 10);
        if (rValue < 3)
        {
            // 플레이어방향
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - this.transform.position;
            dir.Normalize();
            transform.up = -dir;
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
                // 게임오버UI를 활성화 하고싶다.
                GameManager.instance.gameOverUI.SetActive(true);
            }
        }
        else
        {
            // 나 : Enemy, 너(collision) : Bullet

            // 너죽고 
            Destroy(collision.gameObject); // Bullet

            // 점수를 1점 증가시키고싶다.
            // GameObject.Find를 이용해서 구현하세요.

            ScoreManager.instance.SCORE++;
        }

        // enemyHP의 체력을 1 감소하고싶다.
        enemyHP.HP--;
        // 만약 체력이 0이하라면
        if (enemyHP.HP <= 0)
        {
            // 나죽자 하고싶다.
            Destroy(this.gameObject); // Enemy

            // 내(Enemy)가 파괴될 때
            // 1. 폭발공장에서 폭발을 만들어서
            GameObject explosion = Instantiate(explosionFactory);
            // 2. 내위치에 배치하고싶다.
            explosion.transform.position = this.transform.position;
            // 3. 폭발은 2초 후에 파괴되게 하고싶다.
            Destroy(explosion, 2);
        }
    }

}
