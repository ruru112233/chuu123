using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Data
{
    public float bgmVolume;
    public float seVolume;
}

public class SaveData : MonoBehaviour
{
    void Start()
    {
        // ロード
        DataLoad();
    }

    void DataLoad()
    {
        Data Data = JsonData.Load();

        AudioManager.instance.BgmSliderVolume(Data.bgmVolume);
        AudioManager.instance.SeSliderVolume(Data.seVolume);

        Debug.Log("Data.bgmVolume" + Data.bgmVolume);
        Debug.Log("Data.seVolume" + Data.seVolume);

        string objNm = SceneManager.GetActiveScene().name;

        Debug.Log("Data.bgmVolume>>>>:" + Data.bgmVolume);
        Debug.Log("Data.seVolume>>>>:" + Data.seVolume);

        if (objNm == "TitleScene")
        {
            TitleManager.instance.bgmSlider.normalizedValue = Data.bgmVolume;
            TitleManager.instance.seSlider.normalizedValue = Data.seVolume;
        }
        else if (objNm == "GameScene")
        {
            //GameManager.instance.bgmSlider.normalizedValue = Data.bgmVolume;
            //GameManager.instance.seSlider.normalizedValue = Data.seVolume;
        }

    }


    // セーブ
    public void DataSave()
    {
        Data data = new Data();

        data.bgmVolume = AudioManager.instance.GetBgmVolume();
        data.seVolume = AudioManager.instance.GetSeVolume();
        JsonData.Save(data);

    }
}
