using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3_picturepuzzle : MonoBehaviour
{
    Rigidbody2D body;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (transform.localPosition.y >= 250)
            body.velocity = Vector2.zero;
    }


    private void OnMouseDown()
    {
        Debug.Log("Click!");
        body.AddForce(new Vector2(0, 70f)); 
    }
}
