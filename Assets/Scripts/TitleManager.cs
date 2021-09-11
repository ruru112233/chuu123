using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private Button volumeButton = null;

    public Slider seSlider, bgmSlider;

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
        


    }

    private void Update()
    {
        AudioManager.instance.SeSliderVolume(seSlider.normalizedValue);
        AudioManager.instance.BgmSliderVolume(bgmSlider.normalizedValue);
    }

}
