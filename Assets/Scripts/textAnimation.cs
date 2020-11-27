using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textAnimation : MonoBehaviour
{
    [SerializeField] private Text tapText;
    private bool isSeen = true; 
    [SerializeField] private float maxBlinkTime = 2f;
    private float currentTime;
    // Update is called once per frame
    void Update()
    {
        TextAnimation();
    }

    private void TextAnimation() 
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxBlinkTime) 
        {
            currentTime = 0;
            if (tapText != null)
            {
                isSeen = !isSeen;
                tapText.enabled = isSeen;
            }
        }   
    }
}
