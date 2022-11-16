using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Can_AreaName"), 5);
    }
}
