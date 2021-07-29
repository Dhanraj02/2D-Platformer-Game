using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public scoreController scorecontroller;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        Debug.Log("player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void killplayer()
    {
        Debug.Log("player killed by enemy");
        Reloadlevel();
    }

    private void Reloadlevel()
    {
        SceneManager.LoadScene(0);
    }

    public void pickupkey()
    {
        Debug.Log("player picked up the key");
        scorecontroller.IncreaseScore(10);
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal , vertical);
        PlayMovementAnimation(horizontal , vertical);
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        crouchAnimation(crouch);

    }
    private void MoveCharacter(float horizontal , float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }

    }
    private void crouchAnimation(bool crouch)
    {
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
        if(crouch)
        {
            animator.SetBool("crouch", true);
        }
        else
        {
            animator.SetBool("crouch", false);
        }

    }
    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {



            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        Input.GetAxisRaw("Vertical");
        Input.GetKeyDown(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }
}   
    

