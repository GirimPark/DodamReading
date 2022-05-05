using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5_Invisible : MonoBehaviour
{
    public GameObject ChatWindow;

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
    }

}
