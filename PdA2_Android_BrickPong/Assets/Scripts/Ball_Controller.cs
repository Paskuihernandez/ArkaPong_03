using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{

    //Tener una referencia para el rigidbody attachado al gameObject
    public Rigidbody rb;


    // Use this for initialization
    void Start()
    {

        //Get shortcut to rigidbody component
        rb = GetComponent<Rigidbody>();

        //Pause ball logic for 1.5 seconds, delay launch
        StartCoroutine(Pause());


    }

    // Update is called once per frame
    void Update()
    {

        //Si la bola va a la izquierda
        if (transform.position.x < -9.94f)
        {

            transform.position = Vector2.zero;
            rb.velocity = Vector2.zero;

            //El player 2 gana un punto
            Scoreboard_Controller.instance.GivePlayerTwoAPoint();


            StartCoroutine(Pause());
        }


        //Si la bola va a la derecha
        if (transform.position.x > 9.94f)
        {

            transform.position = Vector2.zero;
            rb.velocity = Vector2.zero;

            //El player 1 gana un punto
            Scoreboard_Controller.instance.GivePlayerOneAPoint();

            StartCoroutine(Pause());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            rb.velocity = Vector2.zero;

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            Destroy(other.gameObject);
        }
    }


    IEnumerator Pause()
    {


        //La bola vuelve salir en (1.5 seg):
        yield return new WaitForSeconds(1.5f);

        //Call function that launches the ball
        LaunchBall();
    }

    void LaunchBall()
    {

        transform.position = Vector2.zero;

        //Ball Chooses a direction

        //Flip a coin, determine direction in x-axis
        int xDirection = Random.Range(0, 2);

        //Flip another coin, determine direction in y-axis
        int yDirection = Random.Range(0, 3);


        Vector2 launchDirection = new Vector2();

        //Check results of one coin toss
        if (xDirection == 0)
        {

            launchDirection.x = -8f;
        }
        if (xDirection == 1)
        {

            launchDirection.x = 8f;
        }

        //Check results of second coin toss
        if (yDirection == 0)
        {

            launchDirection.y = -8f;
        }
        if (yDirection == 1)
        {

            launchDirection.y = 8f;
        }
        if (yDirection == 2)
        {

            launchDirection.y = 0f;
        }

        //Assign velocity based off of where we launch ball
        rb.velocity = launchDirection;
    }
}
