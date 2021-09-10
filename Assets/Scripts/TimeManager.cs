using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text distanceText = null;

    float distance = 0;

    private int charTotal = 4;

    public int CharTotal
    {
        get { return charTotal; }
        set { charTotal = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        distanceText.text = distance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (CharTotal <= 0) CharTotal = 0;

        distanceText.text = "ˆÚ“®‹——£F@" + DistanceCalc(CharTotal).ToString("F1") + " m";
    }

    // ‹——£‚ÌŒv‘ª
    float DistanceCalc(int member)
    {
        distance += Time.deltaTime * member;

        return distance;
    }
}
