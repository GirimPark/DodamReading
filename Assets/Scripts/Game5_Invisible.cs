using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5_Invisible : MonoBehaviour
{
    public GameObject ChatWindow;

    private void OnMouseDown()
    {
        ChatWindow.SetActive(false);
    }

}
