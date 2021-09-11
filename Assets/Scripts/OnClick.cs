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
        volumePanel.SetActive(false);
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
        SceneManager.LoadScene("GameScene");
    }

    public void TitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
