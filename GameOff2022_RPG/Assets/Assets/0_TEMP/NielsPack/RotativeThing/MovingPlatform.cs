using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    void FixedUpdate()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }



    private void OnTriggerEnter(Collider Target)
    {
        if (Target.gameObject.tag == "Player")
        {
            Target.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider Target)
    {
        if (Target.gameObject.tag == "Player")
        {
            Target.transform.SetParent(null);
        }
    }

}
