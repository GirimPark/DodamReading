using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoWritingReport : MonoBehaviour
{
    string scene = "WritingReportScene_";
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            OnMouseDown();
        }
    }


    private void OnMouseDown()
    {
        scene = scene + SceneManager.GetActiveScene().name[0];
        SceneManager.LoadScene(scene);
    }
}
