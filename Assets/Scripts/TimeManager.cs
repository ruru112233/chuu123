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


    [SerializeField]
    private PlayerController player1, player2, player3, player4;

    // Start is called before the first frame update
    void Start()
    {
        distanceText.text = distance.ToString();
        CharTotal = TotalRevaival(player1.revaival,
                                  player2.revaival,
                                  player3.revaival,
                                  player4.revaival);
    }

    // Update is called once per frame
    void Update()
    {
        if (CharTotal <= 0) CharTotal = 0;

        CharTotal = TotalRevaival(player1.revaival,
                                  player2.revaival,
                                  player3.revaival,
                                  player4.revaival);

        Debug.Log(CharTotal);

        distanceText.text = "ˆÚ“®‹——£F@" + DistanceCalc(CharTotal).ToString("F1") + " m";
    }

    // ‹——£‚ÌŒv‘ª
    float DistanceCalc(int member)
    {
        distance += Time.deltaTime * member;

        return distance;
    }


    int TotalRevaival(int p1, int p2, int p3, int p4)
    {
        int total = p1 + p2 + p3 + p4;

        return total;
    }
}
