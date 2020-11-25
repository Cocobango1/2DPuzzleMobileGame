using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleControl : MonoBehaviour
{
    public float timer; 
    public float delay;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
        if(timer < 0)
        {
            timer = 0;
        }
        if(!Input.anyKey && timer == 0)
        {
            image.SetActive(true);
        }
        if (Input.anyKey)
        {
            image.SetActive(false);
            timer = delay;
        }
    }
}
