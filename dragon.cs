using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon : MonoBehaviour
{
    float timer = 1f;

    public float speed;
    public int thrust;
    int direction;

    Animator anim;

    public GameObject ball;
    bool a;
    float timer2 = 1.5f;
    int health = 3;
    public GameObject p2;


    void Start()
    {
        anim = GetComponent<Animator>();
        a = false;
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1f;

            direction = Random.Range(0, 4);

        }
        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            timer2 = 1.5f;

            a = true;

        }
        attack();

        movement();
    }

    void movement()
    {
        if (direction == 0)
        {
            anim.SetInteger("Dir", 0); anim.speed = 1;
            transform.Translate(0, speed, 0);
        }
        if (direction == 1)
        {
            anim.SetInteger("Dir", 01); anim.speed = 1;
            transform.Translate(0, -speed, 0);
        }
        if (direction == 2)
        {
            anim.SetInteger("Dir", 02); anim.speed = 1;
            transform.Translate(-speed, 0, 0);

        }
        if (direction == 3)
        {
            anim.SetInteger("Dir", 03); anim.speed = 1;
            transform.Translate(speed, 0, 0);

        }
    }

    void attack()
    {
        if (a == true)
        {
            GameObject sn = Instantiate(ball, transform.position, ball.transform.rotation);
            int direction2 = anim.GetInteger("Dir");
            if (direction2 == 0)
                sn.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrust);
            else if (direction2 == 1)
                sn.GetComponent<Rigidbody2D>().AddForce(Vector2.up * -thrust);
            else if (direction2 == 2)
                sn.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -thrust);
            else if (direction2 == 3)
                sn.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrust);
            a = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sword")
        {
            health--;
            if (health <= 0)
                Destroy(gameObject);
            Destroy(col.gameObject);
            Instantiate(p2, transform.position, transform.rotation);
        }
    }






    void OnCollisionEnter2D(Collision2D bol)
    {

        if (bol.gameObject.tag == "Finish")

        {
            if (direction == 0)
            {
                direction = 1;
            }
            else if (direction == 1)
            {
                direction = 0;
            }
            else if (direction == 2)
            {
                direction = 3;
            }
            else if (direction == 3)
            {
                direction = 2;
            }

        }
    }
}

