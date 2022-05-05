using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoadingScene : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("reLoad");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
