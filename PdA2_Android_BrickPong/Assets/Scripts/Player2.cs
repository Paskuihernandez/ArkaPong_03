using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    public float movSpeed;
    public GameObject character;

    private Rigidbody2D characterBody;
    private float ScreenWidth;
    private float ScreenHeight;

    // Use this for initialization
    void Start()
    {
        ScreenHeight = Screen.height;
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        //Mov Player Right
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2 && Input.GetTouch(i).position.y > ScreenHeight / 2)
            {

                RunCharacter(1.0f);

            }
            if (Input.GetTouch(i).position.x > ScreenWidth / 2 && Input.GetTouch(i).position.y < ScreenHeight / 2)
            {

                RunCharacter(-1.0f);

            }
            ++i;
        }
    }

    private void RunCharacter(float verticalInput)
    {
        //characterBody.AddForce(new Vector2(horizontalInput * movSpeed * Time.deltaTime, 0));
        characterBody.transform.Translate(new Vector2(0, verticalInput * movSpeed * Time.deltaTime));
    }

}
