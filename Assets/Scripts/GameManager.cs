using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TimeManager timeManager;

    public Slider bgmSlider, seSlider;

    public GameObject text0, text1, text2, text3;
    public GameObject commentText0, commentText1, commentText2, commentText3, commentText4,
                      commentText5, commentText6, commentText7, commentText8, commentText9;

    public bool gameStartFlag = false;

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
        StartCoroutine(Init());
        CommentFalse();
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.instance.SeSliderVolume(seSlider.normalizedValue);
        AudioManager.instance.BgmSliderVolume(bgmSlider.normalizedValue);
    }

    // スタート時の処理
    IEnumerator Init()
    {
        AudioManager.instance.PlaySE(20);
        textFalse();
        text3.SetActive(true);

        yield return new WaitForSeconds(1);
        AudioManager.instance.PlaySE(19);
        textFalse();
        text2.SetActive(true);

        yield return new WaitForSeconds(1);
        AudioManager.instance.PlaySE(18);
        textFalse();
        text1.SetActive(true);

        yield return new WaitForSeconds(1);
        AudioManager.instance.PlaySE(17);
        textFalse();
        text0.SetActive(true);

        yield return new WaitForSeconds(1);
        textFalse();
        gameStartFlag = true;

    }

    // 初期化
    void textFalse()
    {
        text0.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
    }

    // コメントの初期化
    public void CommentFalse()
    {
        commentText0.SetActive(false);
        commentText1.SetActive(false);
        commentText2.SetActive(false);
        commentText3.SetActive(false);
        commentText4.SetActive(false);
        commentText5.SetActive(false);
        commentText6.SetActive(false);
        commentText7.SetActive(false);
        commentText8.SetActive(false);
        commentText9.SetActive(false);
    }

    public IEnumerator FalseObj(GameObject obj)
    {
        yield return new WaitForSeconds(0.6f);

        obj.SetActive(false);
    }

}
