using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text distanceText = null;

    float distance = 0;

    private int charTotal = 4;

    bool endFlag = false;
    bool rankingFlag = false;

    public int CharTotal
    {
        get { return charTotal; }
        set { charTotal = value; }
    }

    // チェック用の変数
    float check1 = 0;
    float check2 = 0;

    float score = 0;


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
        

        if (GameManager.instance.gameStartFlag)
        {
            score = DistanceCalc(CharTotal);

            if (CharTotal <= 0)
            {
                CharTotal = 0;
                endFlag = true;
            }

            if (BorderCheck(50.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(100.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(200.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(300.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(400.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(500.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(600.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(700.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(800.0f, score))
            {
                DistanceVoice(score);
            }
            else if (BorderCheck(900.0f, score))
            {
                DistanceVoice(score);
            }


            if (endFlag && !rankingFlag)
            {
                string newScore = score.ToString("F1");
                double newScore1 = double.Parse(newScore);
                rankingFlag = true;
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking(newScore1);
            }

            // 生存しているキャラクターの数をチェック
            CharTotal = TotalRevaival(player1.revaival,
                                      player2.revaival,
                                      player3.revaival,
                                      player4.revaival);
        }

        distanceText.text = "移動距離：　" + score.ToString("F1") + " m";
    }

    // 距離の計測
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

    // 距離が特定の値を超えたかチェック
    bool BorderCheck(float targetDistance, float distance)
    {
        if (Time.frameCount % 2 == 0)
        {
            check1 = distance;
        }
        else
        {
            check2 = distance;
        }

        if (check1 >= targetDistance && check2 < targetDistance || check1 < targetDistance && check2 >= targetDistance)
        {
            return true;
        }

        return false;

    }

    // 距離による声の設定
    // 6 → すごいすごい
    // 9 → エクセレント
    // 10 → グッド
    // 11 → マーベラス
    void DistanceVoice(float distance)
    {
        if (distance >= 300)
        {
            AudioManager.instance.PlaySE(11);
            GameManager.instance.commentText8.SetActive(true);
            StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText8)); 
        }
        else if(distance >= 200)
        {
            AudioManager.instance.PlaySE(9);
            GameManager.instance.commentText6.SetActive(true);
            StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText6));
        }
        else if(distance >= 100)
        {
            AudioManager.instance.PlaySE(6);
            GameManager.instance.commentText4.SetActive(true);
            StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText4));
        }
        else
        {
            AudioManager.instance.PlaySE(10);
            GameManager.instance.commentText7.SetActive(true);
            StartCoroutine(GameManager.instance.FalseObj(GameManager.instance.commentText7));
        }

    }

}
