using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{

    int direccionX;
    int direccionY;

    float speed;

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

        speed = Random.Range(6, 11);

        direccionX = Random.Range(0, 2);
        if (direccionX == 0)
        {
            direccionX = 1;
        }
        else
        {
            direccionX = -1;
        }

        direccionY = Random.Range(0, 2);
        if (direccionY == 0)
        {
            direccionY = 1;
        }
        else
        {
            direccionY = -1;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(speed * direccionX, speed * direccionY, 0);


    }
}
