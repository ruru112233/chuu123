using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private Button volumeButton = null;

    public Slider seSlider, bgmSlider;

    float bgmVol = 0;
    float seVol = 0;

    public static TitleManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    private void Start()
    {

        AudioManager.instance.PlayBGM(2);

        bgmVol = PlayerPrefs.GetFloat("BGMVOL", 0.3f);
        seVol = PlayerPrefs.GetFloat("SEVOL", 0.8f);

        seSlider.normalizedValue = seVol;
        bgmSlider.normalizedValue = bgmVol;

    }

    private void Update()
    {
        AudioManager.instance.SeSliderVolume(seSlider.normalizedValue);
        AudioManager.instance.BgmSliderVolume(bgmSlider.normalizedValue);
        
        //AudioManager.instance.SeSliderVolume(seVol);
        //AudioManager.instance.BgmSliderVolume(bgmVol);
    }

}
