using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject Panel_Setting;
    public GameObject Panel_Main;

    void Start()
    {
        Panel_Setting.SetActive(false);
        Panel_Main.SetActive(true);
    }

    public void ActiveSettings()
    {
        Panel_Setting.SetActive(true);
        Panel_Main.SetActive(false);
    }

    public void DeActiveSettings()
    {
        Panel_Setting.SetActive(false);
        Panel_Main.SetActive(true);
    }
}
