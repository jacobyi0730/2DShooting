using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 나의 up 방향으로 이동하고싶다.
// 화면밖으로 나가게되는 경우 방향을 왼쪽으로 90도 회전하고싶다.
public class Item : MonoBehaviour
{
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 나의 up 방향으로 이동하고싶다.
        transform.position += transform.up * speed * Time.deltaTime;
        // 화면밖으로 나가게되는 경우 방향을 왼쪽으로 90도 회전하고싶다.
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPoint.x <= 0 || viewportPoint.x >= 1 ||
            viewportPoint.y <= 0 || viewportPoint.y >= 1)
        {
            transform.up = transform.right;
        }
    }
}
