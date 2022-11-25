using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TMP_Text scoreTxt;
    int score = 0;

    void Start()
    {
        //scoreTxt = GetComponent<TMPro.TextMeshProUGUI>().text;
        scoreTxt.text = score.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }
}
