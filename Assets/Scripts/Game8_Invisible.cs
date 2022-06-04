using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_Invisible : MonoBehaviour
{
    GameObject ChatWindow;
    GameObject prince;
    GameObject princess;

    GameObject heart;
    GameObject heartMold;

    private void Start()
    {
        ChatWindow = GameObject.Find("말풍선");
        prince = GameObject.Find("왕자");
        princess = GameObject.Find("공주");

        heart = GameObject.Find("dragHeart");
        heartMold = GameObject.Find("heart");
    }


    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
    }


    private void OnMouseDown()
    {
        ChatWindow.SetActive(false);

        prince.GetComponent<SpriteRenderer>().enabled = true;
        princess.GetComponent<SpriteRenderer>().enabled = true;

        heart.GetComponent<BoxCollider2D>().enabled = true;
        heartMold.GetComponent<SpriteRenderer>().enabled = true;
    }

}
