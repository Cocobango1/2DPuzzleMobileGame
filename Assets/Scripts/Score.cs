using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int ScoreCount = 23;
    public Text scoreText;

     private void Start()
    {
        scoreText.GetComponent<Text>();
        scoreText.text = ScoreCount.ToString();
    }

    public void ScoreUpdate()
    {
        ScoreCount--;
        scoreText.text = ScoreCount.ToString();
    }
}
