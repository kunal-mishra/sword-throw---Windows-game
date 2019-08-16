using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crab : MonoBehaviour
{
    public int health;
    public GameObject swordp;
    SpriteRenderer spriterenderer;
    public float speed;
    public Sprite fup;
    public Sprite fdown;
    public Sprite fleft;
    public Sprite fright;
    int direction;
    float time = 1f;

  

    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        direction = 0;

    }

    
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 1f;
            direction = Random.Range(0,4);
            
        }
        
        
        movement();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sword")
        {
            health--;
            if (health <= 0)
                Destroy(gameObject);
            Destroy(col.gameObject);
            Instantiate(swordp, transform.position, transform.rotation);
        }

    }

    void movement()
    {
        if (direction == 0)
        {
            spriterenderer.sprite = fup;
            transform.Translate(0, speed, 0);
        }
        if (direction == 1)
        {
            spriterenderer.sprite = fdown;
            transform.Translate(0, -speed, 0);
        }
        if (direction == 2)
        {
            spriterenderer.sprite = fleft;
            transform.Translate(-speed, 0, 0);
        }
        if (direction == 3)
        {
            spriterenderer.sprite = fright;
            transform.Translate(speed, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D bol)
    {
        if (bol.gameObject.tag == "Player")
        {
            bol.gameObject.GetComponent<player>().curh--;

            bol.gameObject.GetComponent<player>().inviframe = true;
        }


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
