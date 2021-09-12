using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public GameObject birdPool, bird2Pool, bird3Pool;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BirdInstance", 4.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 鳥の生成
    void BirdInstance()
    {
        GameObject objPool = TargetObjectPool();

        if (objPool != null)
        {
            RiactionVoiseSet();

            foreach (Transform t in objPool.transform)
            {
                if (!t.gameObject.activeSelf)
                {
                    t.SetPositionAndRotation(InstancePoint(), Quaternion.identity);
                    t.gameObject.SetActive(true);
                    return;
                }
            }

            GameObject obj = objPool.transform.GetChild(0).gameObject;
            Instantiate(obj, InstancePoint(), Quaternion.identity, birdPool.transform);
        }
        
    }

    // 声を設定

    void RiactionVoiseSet()
    {
        // 2 「あっ！」
        // 3 「うっそお」
        // 4 「えーーー！」
        // 5 「おっ！」
        int num = Random.Range(2, 6);

        switch (num)
        {
            case 2:
                AudioManager.instance.PlaySE(2);
                GameManager.instance.commentText0.SetActive(true);
                StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText0));
                break;
            case 3:
                AudioManager.instance.PlaySE(3);
                GameManager.instance.commentText1.SetActive(true);
                StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText1));
                break;
            case 4:
                AudioManager.instance.PlaySE(4);
                GameManager.instance.commentText2.SetActive(true);
                StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText2));
                break;
            case 5:
                AudioManager.instance.PlaySE(5);
                GameManager.instance.commentText3.SetActive(true);
                StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText3));
                break;
        }
        
    }

    


    Vector3 InstancePoint()
    {
        Vector3 pos = new Vector3();

        pos = new Vector3(0, 0.1f, -6);


        return pos;
    }

    // 対象のオブジェクトを選択
    GameObject TargetObjectPool()
    {
        int num = Random.Range(0, 10);

        GameObject objectPool = null;

        switch (num)
        {
            case 0:
                objectPool = birdPool;
                break;
            case 1:
                objectPool = bird2Pool;
                break;
            case 2:
                objectPool = bird3Pool;
                break;
        }

        return objectPool;
    }

}
