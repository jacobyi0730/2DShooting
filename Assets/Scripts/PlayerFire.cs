using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 마우스 왼쪽 버튼을 누르면 
// 총알공장에서 총알을 만들어서
// 총구위치에 배치하고싶다.
// 마우스 왼쪽 버튼을 누르고 있으면 0.2초마다 총알이 계속 발사되게 하고싶다.
// 버튼을 떼면 그만 발사하게 하고싶다.

// ObjectPool 처리하고싶다.==============================
// 태어날 때 총알을 미리 만들어서 총알목록에 등록하고 비활성화 해놓고
// 총알이 발사될 때 목록에서 하나 가져와서 활성화 하고싶다.
// 총알이 화면밖에 나갈때 혹은 적과 부딪혔을 때 비활성화 하고싶다.
// 비활성화 목록을 만들어서 비활성총알을 검색하는 일을 하지않고싶다.
public class PlayerFire : MonoBehaviour
{
    List<GameObject> bulletObjectPool;
    int bulletObjectPoolCount = 5;
    public static List<GameObject> deActiveBulletObjectPool;
    public Transform bulletParent;

    public List<GameObject> DeActiveBulletObjectPool
    {
        get { return deActiveBulletObjectPool; }
    }

    public GameObject bulletFactory;
    public Transform firePosition;

    bool bAutoFire;
    float currentTime;
    public float fireTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 총알을 미리 만들어서 총알목록에 등록하고 비활성화 해놓고
        bulletObjectPool = new List<GameObject>();
        deActiveBulletObjectPool = new List<GameObject>();

        for (int i = 0; i < bulletObjectPoolCount; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            // bullet의 부모 = bulletParent
            bullet.transform.parent = bulletParent;
            bullet.SetActive(false);
            bulletObjectPool.Add(bullet);
            deActiveBulletObjectPool.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bAutoFire)
        {
            // 누르는 중
            // 시간이 흐르다가 
            currentTime += Time.deltaTime;
            // 총알생성시간이 되면
            if (currentTime > fireTime)
            {
                // 총알을 만들겠다.
                MakeBullet();
                currentTime = 0;
            }
        }
        // 만약 사용자가 마우스 왼쪽 버튼을 누르면 
        if (Input.GetButtonDown("Fire1"))
        {
            bAutoFire = true;
            MakeBullet();
            currentTime = 0;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            bAutoFire = false;
        }
    }

    void MakeBullet()
    {
        // 총알이 만들어질 때 총알목록에서 비활성화된 총알을 하나 가져와서 활성화 하고싶다.
        GameObject bullet = GetBulletFromObjectPool();
        if (bullet != null)
        {
            // 총구위치에 배치하고싶다.
            bullet.transform.position = firePosition.position;
            bullet.transform.up = firePosition.up;
        }
    }
    GameObject GetBulletFromObjectPool()
    {
        // 만약 비활성목록에 크기가 0보다 크다면
        if (DeActiveBulletObjectPool.Count > 0)
        {
            // 비활성목록의 0번째 항목을 반환하고싶다.
            GameObject bullet = DeActiveBulletObjectPool[0];
            bullet.SetActive(true);
            // 목록에서 bullet를 지우고싶다.
            DeActiveBulletObjectPool.Remove(bullet);
            return bullet;
        }
        // 그렇지 않다면 null을 반환하고싶다.
        return null;



        //// 총알목록에서 비활성화된 총알을 하나 가져와서 활성화 하고 반환하고 싶다.
        //for (int i = 0; i < bulletObjectPool.Count; i++)
        //{
        //    // 만약 i번째의 총알이 비활성화 되어있다면
        //    if (false == bulletObjectPool[i].activeSelf)
        //    {
        //        // 활성화하고
        //        bulletObjectPool[i].SetActive(true);
        //        // 반환하고싶다.
        //        return bulletObjectPool[i];
        //    }
        //}
        //return null;
    }
}
