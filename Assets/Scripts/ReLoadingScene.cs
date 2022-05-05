using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoadingScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
    }


    private void OnMouseDown()
    {
        Debug.Log("reLoad");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
