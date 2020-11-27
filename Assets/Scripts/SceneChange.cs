using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void btn_scene_change(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
