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

        anime.SetBool("Walking", false);

        StartCoroutine(WalkStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStartFlag)
        {
            if (jumpFlag && revaival == 1)
            {
                if (Input.GetKeyDown(JumpKey))
                {
                    jumpFlag = false;
                    Debug.Log("ジャンプ");
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

    }

    // 声の設定
    void DamageVoice()
    {
        int num = Random.Range(0, 3);

        // 3 →　うっそー
        // 7 →　そんなー
        // 13 →　おっしー

        switch (num)
        {
            case 0:
                AudioManager.instance.PlaySE(3);
                GameManager.instance.commentText1.SetActive(true);
                StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText1));
                break;
            case 1:
                AudioManager.instance.PlaySE(7);
                GameManager.instance.commentText5.SetActive(true);
                StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText5));
                break;
            case 2:
                AudioManager.instance.PlaySE(13);
                GameManager.instance.commentText9.SetActive(true);
                StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText9));
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


    IEnumerator WalkStart()
    {
        yield return new WaitForSeconds(4);

        anime.SetBool("Walking", true);
    }

}
