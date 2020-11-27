using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int[] level;
    public GameObject[] levels;
    // Start is called before the first frame update
    void Start()
    {
       // level[0] = 1;
    }
    private void Awake()
    {
        instance = this;

        if (LevelManager.instance != this)
            Destroy(LevelManager.instance);

        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < level.Length; i++)
        {
            if (level[i] == 1 && levels[i] != null)
            {
                levels[i].SetActive(true);
            }
            else if (level[i] != 1 && levels[i] != null)
            {
                levels[i].SetActive(false);
            }
        }
    }
}
