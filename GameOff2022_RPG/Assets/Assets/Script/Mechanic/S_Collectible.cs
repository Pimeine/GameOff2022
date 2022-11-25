using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Collectible : MonoBehaviour
{

    [SerializeField] private Vector3 _rotation;
    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
