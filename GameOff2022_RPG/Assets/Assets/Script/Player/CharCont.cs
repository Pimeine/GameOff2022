using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharCont : MonoBehaviour
{
    private CharacterController charcontr;
    public float Speed = 5.0f;
    public Rigidbody m_Rigidbody;

    //    Vector3 jumpForce = new Vector3(0.0f, 10.0f, 0.0f);

    float gravity = -9.81f;
    Vector3 velocity;
    Vector3 move;

    Vector3 vnull = new Vector3(0.0f, 0.0f, 0.0f);

    public Animator animator;

    bool isWalking;
    bool isRunning;
    bool isJumping;

    // private Vector3 v3_CharPos;
    [SerializeField]
    public float maxHealth = 100.0f;
    public float currentHealth;
    public Slider slider;

    private float speed = 1.0f;
    Vector3 jumpForce = new Vector3(0.0f, 2.0f, 0.0f);

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

        animator = GetComponent<Animator>();


        currentHealth = maxHealth;
        setMaxHealth(maxHealth);
        SetHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(currentHealth);
        deathRestart();

        move = Input.GetAxis("Vertical") * transform.forward * speed;
        charcontr.Move(move * Time.deltaTime * Speed);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);
        }

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
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 1.0f;
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //m_Rigidbody.AddForce(jumpForce, ForceMode.Impulse);
            velocity.y += 10f;
        }

        if (move == vnull)
        {
            animator.SetBool("isWalking", false);
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

    void OnTriggerStay(Collider Target)
    {
        if (Target.gameObject.tag == "DeathZone")
        {
            TakeDamage(1);
            Debug.Log("DEGATS");
        }

    }



    //UPDATE END

    public void setMaxHealth(float maxhp)
    {
        slider.maxValue = maxhp;
        slider.value = maxhp;
    }
    public void SetHealth(float hp)
    {
        slider.value = hp;
    }

    void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
    }

    void deathRestart()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
