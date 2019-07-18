using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int score;
    private int lives; 
    public float speed;
    public Text scoreText;            
    public Text winText;

    public Text loseText;
    public Text livesText;
    public float JumpForce;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        score = 0;

        lives = 3;

        winText.text = "";

        loseText.text = "";

        SetScoreText ();

        SetLivesText ();
        
        musicSource.clip = musicClipOne;
        musicSource.Play();
        musicSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground"){

            if(Input.GetKey(KeyCode.UpArrow)){

                rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
        other.gameObject.SetActive(false);

        score = score + 1;

        SetScoreText ();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
        other.gameObject.SetActive(false);

        lives = lives - 1;
        SetLivesText ();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString ();
        
        if (score == 4)
           { 
            transform.position = new Vector2(17.5f, -1.5f);
            lives = 3; 
           }
        else if (score >= 8)
        {
            winText.text = "You Win!";

            musicSource.clip = musicClipTwo;
            musicSource.Play();
            musicSource.loop = true;
        }
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString ();
        
        if (lives == 0)
        {   
            loseText.text = "You Lose!";
        }
        if (lives ==0)
        {
            gameObject.SetActive(false);
        }
    }
}
