using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeMenu : MonoBehaviour
{
    public GameObject UI;
    private bool change;

    public void menu()
    {
        change = !change;
        UI.SetActive(change);
    }

}
