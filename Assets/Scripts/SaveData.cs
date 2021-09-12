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
    public float bgmVol = 0.5f;
    public float seVol = 0.5f;

    public static SaveData instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (this != instance)
        {
            Destroy(this.gameObject);

            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        // ロード
        bgmVol = PlayerPrefs.GetFloat("BGMVOL", 0.3f);
        seVol = PlayerPrefs.GetFloat("SEVOL", 0.8f);

        DataLoad();
    }

    void DataLoad()
    {
        Data Data = JsonData.Load();

        //AudioManager.instance.BgmSliderVolume(Data.bgmVolume);
        //AudioManager.instance.SeSliderVolume(Data.seVolume);

        AudioManager.instance.BgmSliderVolume(bgmVol);
        AudioManager.instance.SeSliderVolume(seVol);

        string objNm = SceneManager.GetActiveScene().name;

        if (objNm == "TitleScene")
        {
            TitleManager.instance.bgmSlider.normalizedValue = bgmVol;
            TitleManager.instance.seSlider.normalizedValue = seVol;
        }
        else
        {
            GameManager.instance.bgmSlider.normalizedValue = bgmVol;
            GameManager.instance.seSlider.normalizedValue = seVol;
        }

    }


    // セーブ
    public void DataSave()
    {
        //Data data = new Data();

        //data.bgmVolume = AudioManager.instance.GetBgmVolume();
        //data.seVolume = AudioManager.instance.GetSeVolume();
        //JsonData.Save(data);

        PlayerPrefs.SetFloat("BGMVOL", AudioManager.instance.GetBgmVolume());
        PlayerPrefs.SetFloat("SEVOL", AudioManager.instance.GetSeVolume());

    }
}
