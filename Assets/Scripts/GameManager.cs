using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimeManager timeManager;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
