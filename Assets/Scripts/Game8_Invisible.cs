using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_Invisible : MonoBehaviour
{
    GameObject ChatWindow;
    GameObject prince;
    GameObject princess;

    private void Start()
    {
        ChatWindow = GameObject.Find("¸»Ç³¼±");
        prince = GameObject.Find("¿ÕÀÚ");
        princess = GameObject.Find("°øÁÖ");
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
        prince.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        princess.GetComponent<SpriteRenderer>().enabled = true;
        princess.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    }

}
