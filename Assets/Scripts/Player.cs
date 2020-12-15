using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed = 5f, jumpPow = 556f;
    public bool grounded = true, doublejump = false;
    public float maxVelocity = 6f;
    public Rigidbody2D r2;
    public Animator anim;

    public int ourHealth;
    public int maxhealth = 5;

    // Use this for initialization
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ourHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);

            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.7f);
                }
            }

        }
    }

    void FixedUpdate()
    {
        float ForceX = 0f;
        float vel = Mathf.Abs(r2.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");
        // r2.AddForce((Vector2.right) * speed * h);

        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                ForceX = speed;
            }
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
        }



        if (h < 0)
        {
            if (vel < maxVelocity)
            {
                ForceX = -speed;
            }
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
        }
        r2.AddForce(new Vector2(ForceX, 0));

        if (ourHealth<=0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        SceneManager.LoadScene(0);
    }
}