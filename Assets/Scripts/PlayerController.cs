using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode JumpKey;

    Animator anime = null;
    Rigidbody rb = null;

    bool jumpFlag = true;

    float jumpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        anime = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpFlag)
        {
            if (Input.GetKeyDown(JumpKey))
            {
                jumpFlag = false;
                Debug.Log("ƒWƒƒƒ“ƒv");
                anime.SetTrigger("Jump");
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            jumpTime += Time.deltaTime;

            if (jumpTime > 1.4f)
            {
                jumpTime = 0;
                jumpFlag = true;
            }
        }

        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("“–‚½‚Á‚½");
            GameManager.instance.timeManager.CharTotal--;
            anime.SetTrigger("Damaged");
            rb.useGravity = true;
        }
    }

}
