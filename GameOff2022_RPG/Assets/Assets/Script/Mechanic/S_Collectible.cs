using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Collectible : MonoBehaviour
{
    [SerializeField] private AudioSource audioData;
    bool played = false;
    Collider m_Collider;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        m_Collider = GetComponent<Collider>();
    }
    [SerializeField] private Vector3 _rotation;
    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);

        if (played == true && !audioData.isPlaying)
        {

            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            audioData.Play();
            played = true;
            m_Collider.enabled = !m_Collider.enabled;
            //Destroy(gameObject);
        }
    }
}
