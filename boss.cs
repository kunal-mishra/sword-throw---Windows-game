using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class boss : MonoBehaviour
{
  
    public int health;
    float timer = 1f;
    float timer2 = .8f;
    int direction;
    Animator anim;
    public int speed;
    public GameObject ball;
    public int thrust;
    public GameObject swordp2;

    void Start()
    {
        health = 10;
        direction = 0;
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        movement();
        death();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1f;
            direction++;
            if (direction == 4)
                direction = 0;
        }

        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            timer2 = .8f;
            attack();
        }

        

    }

    void movement()
    {
        if (direction == 0)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            anim.SetInteger("direc", 0);
            anim.speed = 1;
        }
        else if (direction == 1)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetInteger("direc", 1);
            anim.speed = 1;
        }
        else if (direction == 2)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            anim.SetInteger("direc", 2);
            anim.speed = 1;
        }
        else if (direction == 3)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            anim.SetInteger("direc", 3);
            anim.speed = 1;
        }
    }

    void attack()
    {

        GameObject ball1 = Instantiate(ball, transform.position, Quaternion.identity);
        ball1.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrust);
        GameObject ball2 = Instantiate(ball, transform.position, Quaternion.identity);
        ball2.GetComponent<Rigidbody2D>().AddForce(Vector2.up * -thrust);
        GameObject ball3 = Instantiate(ball, transform.position, Quaternion.identity);
        ball3.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrust);
        GameObject ball4 = Instantiate(ball, transform.position, Quaternion.identity);
        ball4.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -thrust);


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sword")
        {
            health--;
            Destroy(col.gameObject);
            Instantiate(swordp2, transform.position, transform.rotation);
        }

    }
    void death()
    {

        if (health <= 0)
        { 
            PlayerPrefs.SetInt("m", 3);
            PlayerPrefs.SetInt("c", 3);
            
            Destroy(gameObject);
        }
    }
}
