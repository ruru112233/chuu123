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
        volumePanel.SetActive(true);
    }

    public void CloseButton()
    {
        volumePanel.SetActive(false);
        saveData.DataSave();
    }

    public void StartButton()
    {
        AudioManager.instance.PlaySE(12);
        saveData.DataSave();
        SceneManager.LoadScene("GameScene");
    }

    public void TitleButton()
    {
        AudioManager.instance.PlaySE(8);
        saveData.DataSave();
        SceneManager.LoadScene("TitleScene");
    }

    public void ReTryButton()
    {
        AudioManager.instance.PlaySE(16);
        saveData.DataSave();
        SceneManager.LoadScene("GameScene");
    }

}
