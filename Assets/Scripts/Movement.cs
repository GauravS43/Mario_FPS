using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 50;
    public float gravity = -9.81f;
    Vector3 velocity;
    public float jumpHeight = 3;
    public Image blood;

    //Variables used to determine if the player is on the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask oceanMask;
    public LayerMask flagMask;
    public LayerMask enemyMask;
    public int health = 5;

    bool nearEnemy;
    bool isFlag;
    bool isDead;
    bool fallen;
    bool isGrounded;
    bool hurt;

    // Update is called once per frame
    void Update()
    {
        Heal();


        nearEnemy = Physics.CheckSphere(transform.position, 2, enemyMask);
        if (nearEnemy)
        {
            hurt = true;
            TakeDamage();
        }

        //Death function, checks if groundcheck collides
        fallen = Physics.CheckSphere(groundCheck.position, groundDistance, oceanMask);
        if (isDead || fallen)
        {
            SceneManager.LoadScene("DeathScreen");
        }

        //Checks if player won
        isFlag = Physics.CheckSphere(groundCheck.position, groundDistance, flagMask);
        if (isFlag)
        {
            SceneManager.LoadScene("WinScreen"); 
        }

        if (velocity.y < -50)
        {
            hurt = true;
        }

        //Checks if player is grounded, if so, resets velocity to -2
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            TakeDamage();
        }

        //Character movement using unity's baked inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //Character jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void TakeDamage()
    {
        var tempColor = blood.color;
        if (tempColor.a < 5 && hurt)
        {
            tempColor.a += 5;
            hurt = false;
            health--;
        }

        if (health < 0)
        {
            isDead = true;
        }
        blood.color = tempColor;
    }

    void Heal()
    {
        var tempColor = blood.color;

        if (tempColor.a > 0)
        {
            tempColor.a-= 0.05f;
        }
        blood.color = tempColor;
    }
}
