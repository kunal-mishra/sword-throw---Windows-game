using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    bool a = true;
    int bossdeath;
    public Text won;
    public Text gameover;
    float time3 = 2f;
    public Image[] hearts;
    public GameObject sword;
    public Animator anim;
    public float speed;
    public int maxh = 3;
    public int curh;
    int i;
    public int thrust;
    public bool inviframe;
    SpriteRenderer sr;
    float time2 = 1f;

    public GameObject p;
    int tempo;
    public GameObject potion;
    public Transform newpos, newpos2;

    public Camera cam;
    public bool camerao;

    public bool up = false;
    public bool right = false;
    public bool left = false;
    public bool down = false;
    float t = 0.1f; 

    void Start()
    {

        anim = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("m"))
            loadgame();
        else
            curh = maxh;

        tempo = maxh;
        sr = GetComponent<SpriteRenderer>();
        camerao = true;


    }

   
   
   

   public void Update()
    {
        if (camerao == true)
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
        }
        gethealth();
        attack();
        movement();
        life();
        death();
        winner();

        if (inviframe == true)
        {
            int rn = Random.Range(0, 100);
            if (rn < 50) sr.enabled = false;
            if (rn > 50) sr.enabled = true;

            time2 -= Time.deltaTime;
            if (time2 <= 0)
            {
                time2 = 1f;
                inviframe = false;
                sr.enabled = true;

            }

        }
    }












    void gethealth()
    {
        for (int i = 0; i < curh; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
        if (curh < maxh)
            hearts[curh].gameObject.SetActive(false);
    }



   

    public void movement()
    {
        
            if (Input.GetKey(KeyCode.W))
            { transform.Translate(0, speed * Time.deltaTime, 0); anim.SetInteger("dir", 0); anim.speed = 1;
             
            }
            else if (Input.GetKey(KeyCode.A))
            { transform.Translate(-speed * Time.deltaTime, 0, 0); anim.SetInteger("dir", 1); anim.speed = 1;
              
            }
            else if (Input.GetKey(KeyCode.S))
            { transform.Translate(0, -speed * Time.deltaTime, 0); anim.SetInteger("dir", 3); anim.speed = 1;
              
            }
            else if (Input.GetKey(KeyCode.D))
            {
               transform.Translate(speed * Time.deltaTime, 0, 0); anim.SetInteger("dir", 2); anim.speed = 1;
              
            }
            else { anim.speed = 0; }
        
    }

    void attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject newsword = Instantiate(sword, transform.position, sword.transform.rotation);
            int swordDir = anim.GetInteger("dir");
            int swordDir2 = anim.GetInteger("attackdir");

            if (swordDir == 0)
            {

                newsword.transform.Rotate(0, 0, 0);
                newsword.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrust);

            }
            else if (swordDir == 3)
            {
                newsword.transform.Rotate(0, 0, 180);
                newsword.GetComponent<Rigidbody2D>().AddForce(Vector2.up * -thrust);
            }
            else if (swordDir == 1)
            {
                newsword.transform.Rotate(0, 0, 90);
                newsword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -thrust);
            }
            else if (swordDir == 2)
            {

                newsword.transform.Rotate(0, 0, -90);
                newsword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrust);




            }


        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ball")
        {
            curh--;


            Destroy(col.gameObject);
            inviframe = true;
            p = Instantiate(p, transform.position, p.transform.rotation);

        }
        if (col.gameObject.tag == "potion")
        {
            curh++;
            Destroy(col.gameObject);
            tempo++;
        }
        if (col.gameObject.tag == "trans")
        {
            SceneManager.LoadScene(2);
        }


    }

    void life() {


        if (curh != tempo) {

            if (curh == 2)
                Instantiate(potion, newpos.position, Quaternion.identity);
            if (curh == 1)
                Instantiate(potion, newpos2.position, Quaternion.identity);
            tempo--; }
    }

    public void savegame() {
        PlayerPrefs.SetInt("m", maxh);
        PlayerPrefs.SetInt("c", curh); }

    void loadgame() {
        maxh = PlayerPrefs.GetInt("m");
        curh = PlayerPrefs.GetInt("c");
    }


    void death() {
        if (curh <= 0)
        {
            anim.speed = 0;
            gameover.gameObject.SetActive(true);
            PlayerPrefs.SetInt("m", 3);
            PlayerPrefs.SetInt("c", 3);
            time3 -= Time.deltaTime;
            if (time3 <= 0)
            {
                time3 = 2f;

                SceneManager.LoadScene(0);
            }
        }
    }

    void winner()
    {
        if (a == true)
        {
            bossdeath = GameObject.FindGameObjectWithTag("boss").GetComponent<boss>().health;
            if (bossdeath <= 0)
            {
                a = false;
            }
        }


        if ( bossdeath <= 0)
        {

            won.gameObject.SetActive(true);
            time3 -= Time.deltaTime;
            if (time3 <= 0)
            {
                time3 = 2f;

                SceneManager.LoadScene(0);
            }

        }
    }
}

