using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : MonoBehaviour
{
    private CharacterController charcontr;
    public float Speed = 5.0f;
    public Rigidbody m_Rigidbody;

    float gravity = -9.81f;
    Vector3 velocity;
    Vector3 move;


    private float speed = 1.0f;
    Vector3 jumpForce = new Vector3(0.0f, 10.0f, 0.0f);

    //UPDATED
    public GameObject pauseMenu;
    public int coinNumber = 0;

    public ScoreUpdate scoring;

    //UPDATE END

    // Start is called before the first frame update
    void Start()
    {
        charcontr = GetComponent<CharacterController>();
        m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Vertical") * transform.forward * speed;
        charcontr.Move(move * Time.deltaTime * Speed);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0.0f, -10.0f, 0.0f) * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0.0f, 10.0f, 0.0f) * 10 * Time.deltaTime);
        }

        if (charcontr.isGrounded == false)
        {
            velocity.y += gravity * Time.deltaTime;
            charcontr.Move(velocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 2.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //m_Rigidbody.AddForce(jumpForce, ForceMode.Impulse);
            velocity.y += 10f;
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
}
