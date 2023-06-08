using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표를 향해 이동하고싶다.
public class Tail : MonoBehaviour
{
    public GameObject target;
    public float speed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 목표를 향하는 방향을 구하고싶다.
        // 목표, 나
        Vector3 direction = target.transform.position - this.transform.position;
        // direction의 크기를 1로 만들고싶다.
        direction.Normalize();
        // 2. 그 방향으로 이동하고싶다.
        transform.position += direction * speed * Time.deltaTime;

    }
}
