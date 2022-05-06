using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3_picturepuzzle : MonoBehaviour
{
    GameObject pass;


    private void Start()
    {
        pass = transform.GetChild(1).gameObject;
    }


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
    }


    private void OnMouseDown()
    {
        Debug.Log("Click!");
        pass.GetComponent<SpriteRenderer>().enabled = true;
    }
}
