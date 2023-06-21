using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Transform으로된 Spawn목록을 가지고 있고싶다.
// 일정시간마다 Spawn목록중에 랜덤으로 하나 정하고싶다.
// 적 공장에서 적을 만들어서 그위치에 배치하고싶다.
public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    private void Awake()
    {
        instance = this;
    }
    public bool isBoss = false;

    public Transform[] spawnList;
    float currtenTime;
    public float makeTime = 1;
    GameObject enemyFactory;
    int prevChooseIndex = -1;
     
    // Start is called before the first frame update
    void Start()
    {
        enemyFactory = Resources.Load<GameObject>("Enemy");
    }

    void Update()
    {
        if (isBoss)
        {
            UpdateBoss();
        }
        else
        {
            UpdateNormal();
        }
    }

    // 강적공장에서 강적을 하나만 만들어지게 하고싶다.
    void UpdateBoss()
    {

    }

    void UpdateNormal()
    {
        // 일정시간마다 Spawn목록중에 랜덤으로 하나 정하고싶다.
        // 적 공장에서 적을 만들어서 그위치에 배치하고싶다.

        // 1. 시간이 흐르다가
        currtenTime += Time.deltaTime;
        // 2. 만약 현재시간이 생성시간이되면
        if (currtenTime > makeTime)
        {
            // 3. 적 공장에서 적을 만들어서
            GameObject enemy = Instantiate(enemyFactory);
            // 4. Spawn목록중에 랜덤으로 정한 곳에 배치하고싶다.
            int chooseIndex = Random.Range(0, spawnList.Length);
            // 4.1 랜덤 인덱스가 직전 인덱스와 같다면 
            if (prevChooseIndex == chooseIndex)
            {
                //chooseIndex = (chooseIndex + 1) % spawnList.Length;
                //chooseIndex = (chooseIndex + spawnList.Length - 1) % spawnList.Length;
                // chooseIndex에 1을 더하고싶다.
                chooseIndex++;
                // 만약 chooseIndex가 배열의 범위를 벗어난다면 0으로 초기화 하고싶다.
                if (chooseIndex >= spawnList.Length)
                {
                    chooseIndex = 0;
                }
            }
            // 직전 인덱스에 현재 인덱스를 기억하고싶다.
            prevChooseIndex = chooseIndex;
            enemy.transform.position = spawnList[chooseIndex].transform.position;
            // 5. 현재시간을 0으로 초기화 하고싶다.
            currtenTime = 0;
        }

    }
}
