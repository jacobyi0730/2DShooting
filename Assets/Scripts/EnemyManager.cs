using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간이 흐르다가 생성시간이 되면 적공장에서 적을 만들어서 내위치에 배치하고싶다.
public class EnemyManager : MonoBehaviour
{
    // 현재시간
    float currentTime;
    // 생성시간
    public float makeTime = 1;
    // 적공장
    public GameObject enemyFactory;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 2. 만약 현재시간이 생성시간이 되면
        if (currentTime > makeTime)
        {
            // 3. 적공장에서 적을 만들어서
            GameObject enemy = Instantiate(enemyFactory);
            // 4. 내위치에 배치하고싶다.
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;
            // 5. 현재시간을 0으로 초기화 하고싶다.
            currentTime = 0;
        }
    }
}
