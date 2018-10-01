using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementandoseSize : MonoBehaviour
{
    
    float y;
    float x;
    float z;

    Vector3 nevSize;
	
	
	void Update ()


    {

        z  = 0.10f;
        x  = 0.5344744f;
        y  += 1.568355f * Time.deltaTime;
 
        transform.localScale = new Vector3(x, y, z);


        if (transform.localScale.y >= 1.98399f)
        {
            y -= 1.568355f * Time.deltaTime;
        }


    }
}
