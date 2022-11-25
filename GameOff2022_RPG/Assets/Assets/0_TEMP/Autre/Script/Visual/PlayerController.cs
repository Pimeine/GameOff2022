using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    Vector3 jumpForce = new Vector3(0.0f, 10.0f, 0.0f);

    //UPDATED
    public GameObject pauseMenu;
    public int coinNumber = 0;

    public ScoreUpdate scoring;

    //UPDATE END

    // private Vector3 v3_CharPos;
    [SerializeField]
    private float speed = 10.0f;

    void start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(-1.0f, 0.0f, 0.0f) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0.0f, -10.0f, 0.0f) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0.0f, 10.0f, 0.0f) * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody.AddForce(jumpForce, ForceMode.Impulse);
            Debug.Log("Jump");
        }



        //UPDATE




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(pauseMenu);
        }

    }

    //Take a coin and add it to the total coin score.
    void OnTriggerEnter(Collider Target)
    {
        if (Target.gameObject.tag == "Coin")
        {
            coinNumber += 1;
            Debug.Log("COIN TOTAL = " + coinNumber);

            scoring.UpdateScore(coinNumber);
        }
    }


    //UPDATE END





    private void sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + 20.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed - 20.0f;
        }
    }
}
