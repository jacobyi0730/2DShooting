using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스테이지의 레벨이 변하면 배경 스크롤 속도록 빠르게 하고싶다.
public class StageLevel : MonoBehaviour
{
    public static StageLevel instance;
    private void Awake()
    {
        instance = this;
    }

    public Background bg;

    int level;

    public int LEVEL
    {
        get { return level; }
        set
        {
            level = value;
            // 스테이지 레벨이 2가 되면 
            if (level == 2)
            {
                // 배경 스크롤 속도를 빠르게 하고싶다.
                bg.speed = 2f;
                // 보스가 생성되게 하고싶다.
                SpawnManager.instance.isBoss = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
