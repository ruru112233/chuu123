using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public GameObject birdPool;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BirdInstance", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // íπÇÃê∂ê¨
    void BirdInstance()
    {
        foreach (Transform t in birdPool.transform)
        {
            if (!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(InstancePoint(), Quaternion.identity);
                t.gameObject.SetActive(true);
                return;
            }
        }

        GameObject obj = birdPool.transform.GetChild(0).gameObject;
        Instantiate(obj, InstancePoint(), Quaternion.identity, birdPool.transform);
    }

    Vector3 InstancePoint()
    {
        Vector3 pos = new Vector3();

        pos = new Vector3(0, 0.1f, -5);


        return pos;
    }

}
