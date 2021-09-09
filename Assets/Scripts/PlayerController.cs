using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode JumpKey;

    Animator anime = null;

    [SerializeField]
    private Transform base_transform;

    Transform savePos;

    // Start is called before the first frame update
    void Start()
    {
        anime = this.GetComponent<Animator>();
        savePos = base_transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            Debug.Log("ƒWƒƒƒ“ƒv");
            anime.SetTrigger("Jump");

        }
    }

}
