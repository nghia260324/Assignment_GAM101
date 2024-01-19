using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI fillScore;
    public TextMeshProUGUI fillKill;

    private int currentScore;
    private int currentKill;

    private void Start()
    {
        FileReadWrite.Instance.UpdateKill(0);
        FileReadWrite.Instance.UpdateScore(0);
        FillInf();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore(int score)
    {
        currentScore += score;
        FileReadWrite.Instance.UpdateScore(currentScore);
        FillInf();
    }
    public void UpdateKill()
    {
        currentKill++;
        FileReadWrite.Instance.UpdateKill(currentKill);
        FillInf();
    }
    
    private void FillInf()
    {
        fillScore.text = "Score: " + currentScore;
        fillKill.text = "Kill: " + currentKill;
    }
}
