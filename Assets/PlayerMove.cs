using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 입력에따라 상하좌우로 이동하고싶다.
// 필요요소
// - 속력
public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1. 사용자의 입력에따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        print(h + ", " + v);
        // 2. 상하좌우로 방향을 만들고
        Vector3 dir = h * Vector3.right + v * Vector3.up;
        // dir의 크기를 1로 만들고싶다.
        dir.Normalize();
        // 3. 그 방향으로 이동하고싶다. P = P + vt
        Vector3 velocity = dir * speed;
        transform.position += velocity * Time.deltaTime;

    }
}
