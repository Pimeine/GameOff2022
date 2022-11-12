using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    //animations du persov - Aucunes

    //Vitesse du personnage
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    //Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        // Pour avancer
        if (Input.GetKey(inputFront))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }
        // Pour reculer
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
        }
        // Rotation gauche
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        // Pour aller à droite
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
        //Pour Sprinter
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
        }
        //Pour Sauter
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //Préparation du saut nécessaire en C#
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;

            //Saut
            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
        }
    }
}
