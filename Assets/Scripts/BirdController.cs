using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    float speed = 2f;
    Rigidbody rb = null;

    // bird2‚Ì‹““®—p
    bool upFlag = false;
    float upTime = 0;

    public enum BirdType
    {
        bird1,
        bird2,
        none,
    }

    public BirdType birdType;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

        BirdMove();

        if (transform.position.z > 10f)
        {
            rb.isKinematic = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }
    }

    // ’¹‚Ì‹““®§Œä
    void BirdMove()
    {
        if (BirdType.bird1 == birdType)
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        else if(BirdType.bird2 == birdType)
        {
            float upSpeed = 3.0f;

            upTime += Time.deltaTime;

            if (upTime > 1.0f)
            {
                upTime = 0;
                upFlag = !upFlag;
            }

            if (upFlag)
            {
                transform.position += new Vector3(0, upSpeed * Time.deltaTime, speed * Time.deltaTime);
            }
            else
            {
                transform.position += new Vector3(0, -upSpeed * Time.deltaTime, speed * Time.deltaTime);
            }
            
        }
    }



}
