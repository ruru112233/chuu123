using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject volumePanel = null;

    public SaveData saveData = null;

    private void Start()
    {
        if (volumePanel != null)
        {
            volumePanel.SetActive(false);
        }
    }

    public void VolumeClick()
    {
        AudioManager.instance.PlaySE(15);
        volumePanel.SetActive(true);
    }

    public void CloseButton()
    {
        AudioManager.instance.PlaySE(15);
        saveData.DataSave();
        volumePanel.SetActive(false);
    }

    public void StartButton()
    {
        AudioManager.instance.PlaySE(12);
        StartCoroutine(GameSceneMove(0));
    }

    public void TitleButton()
    {
        AudioManager.instance.PlaySE(8);
        StartCoroutine(GameSceneMove(1));
    }

    public void ReTryButton()
    {
        AudioManager.instance.PlaySE(16);
        StartCoroutine(GameSceneMove(0));
    }

    IEnumerator GameSceneMove(int num)
    {
        yield return new WaitForSeconds(0.5f);

        switch (num)
        {
            case 0:
                SceneManager.LoadScene("GameScene");
                break;
            case 1:
                SceneManager.LoadScene("TitleScene");
                break;
        }
    }

}
