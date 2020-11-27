using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
<<<<<<< HEAD
    public LevelManager GM;
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

    public void btn_scene_change(string scene_name)

=======
    // Start is called before the first frame update
    public void btn_scene_change(string scene_name)
>>>>>>> parent of 326840c... nothing
    {
        SceneManager.LoadScene(scene_name);
    }
}
