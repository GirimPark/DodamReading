using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5_Invisible : MonoBehaviour
{
    GameObject ChatWindow;
    GameObject paper;

    private void Start()
    {
        ChatWindow = GameObject.Find("말풍선");
        paper = GameObject.Find("두루마기");
        paper.GetComponent<SpriteRenderer>().enabled = false;
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
        paper.GetComponent<SpriteRenderer>().enabled = true;
    }

}
