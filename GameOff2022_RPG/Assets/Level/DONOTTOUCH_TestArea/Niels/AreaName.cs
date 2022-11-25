using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PLACE THIS SCRIPT INSIDE A LEVEL TO DISPLAY IT'S NAME OR SOMETHING ON SCREEN FOR 5s WHEN THE PLAYER LOAD IT.

public class AreaName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Can_AreaName"), 5);
    }
}
