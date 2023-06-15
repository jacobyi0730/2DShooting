using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 포션아이템과 부딪혔다면 포션갯수 1 증가시키고싶다. UI도 표현하고싶다.
// 만약 1번 키를 눌렀는데 포션이 1개 이상 있다면 체력을 최대체력으로 하고싶다.
public class PlayerInventory : MonoBehaviour
{
    int potion;
    public TextMeshProUGUI textPotion;

    public int POTION
    {
        get { return potion; }
        set
        {
            potion = value;
            textPotion.text = "x " + potion;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // 만약 부딪힌 상대가 Item이라면
        if (other.gameObject.CompareTag("Item"))
        {
            // 포션갯수를 1개 증가시키고 UI도 표현하고싶다.
            POTION++;
            // 아이템 게임오브젝트는 파괴하고싶다.
            Destroy(other.transform.parent.gameObject);
        }
    }

    PlayerHP playerHP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 만약 1번 키를 눌렀는데
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 2. 만약 포션이 1개 이상 있다면
            if (POTION > 0)
            {
                // 3. 체력을 최대체력으로 하고싶다.
                playerHP.HP = playerHP.maxHP;
                // 4. 포션을 1 감소하고싶다.
                POTION--;
            }
        }
    }
}
