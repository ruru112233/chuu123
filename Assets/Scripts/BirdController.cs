using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    float speed = 2f;
    Rigidbody rb = null;

    // bird2の挙動用
    bool upFlag = false;
    float upTime = 0;

    // bird3の挙動用
    [SerializeField] Transform pivot; //回転中心
    [SerializeField] Transform bob; //振り子

    float angularVelocity = 0;
    float angularAcceleration = 0f;
    float angularAccelerationValue = 15.0f;


    public enum BirdType
    {
        bird1,
        bird2,
        bird3,
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

    // 鳥の挙動制御
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
        else if (BirdType.bird3 == birdType)
        {
            angularVelocity += angularAcceleration * Time.deltaTime;
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            bob.RotateAround(pivot.position, Vector3.forward, angularVelocity);
            if (bob.position.x > pivot.position.x)
            {
                angularAcceleration = -angularAccelerationValue;
            }
            else
            {
                angularAcceleration = angularAccelerationValue;
            }
        }


    }

    public Vector3 GetCurrentVelocity()
    {
        float r = Vector2.Distance(pivot.position, bob.position);
        Vector2 dir = bob.position - pivot.position;
        Vector2 velocityDir = new Vector2(-dir.y, dir.x);
        velocityDir.Normalize();
        return (r * angularVelocity * velocityDir);
    }

}
