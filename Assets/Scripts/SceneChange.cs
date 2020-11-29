using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public string scene_name;
    public int num;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelManager.instance.level[num] = 1;
            SceneManager.LoadScene(scene_name);
        }
    }

    // Start is called before the first frame update
    public void btn_scene_change(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
