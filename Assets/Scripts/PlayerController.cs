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

    public int revaival = 1;

    // Start is called before the first frame update
    void Start()
    {
        anime = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpFlag && revaival == 1)
        {
            if (Input.GetKeyDown(JumpKey))
            {
                jumpFlag = false;
                Debug.Log("ÉWÉÉÉìÉv");
                anime.SetTrigger("Jump");
                AudioManager.instance.PlaySE(14);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            jumpTime += Time.deltaTime;

            if (jumpTime > 1.2f)
            {
                jumpTime = 0;
                jumpFlag = true;
            }
        }

        
    }

    // ê∫ÇÃê›íË
    void DamageVoice()
    {
        int num = Random.Range(0, 3);

        switch (num)
        {
            case 0:
                AudioManager.instance.PlaySE(3);
                break;
            case 1:
                AudioManager.instance.PlaySE(7);
                break;
            case 2:
                AudioManager.instance.PlaySE(13);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            anime.SetTrigger("Damaged");
            DamageVoice();
            revaival = 0;
            rb.useGravity = true;
        }
    }

}
