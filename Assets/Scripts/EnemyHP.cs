using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 태어날 때 체력을 최대체력으로 하고싶다. UI도 처리하고싶다.
// 총알 혹은 플레이어와 부딪힐 때 체력을 1 감소하고 싶다. 체력이 0이되면 파괴되고싶다.
public class EnemyHP : MonoBehaviour
{
    int hp;
    public int maxHP = 2;
    public Slider sliderHP;

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            sliderHP.value = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 체력을 최대체력으로 하고싶다. UI도 처리하고싶다.
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
