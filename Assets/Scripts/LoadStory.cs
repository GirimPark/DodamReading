using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStory : MonoBehaviour
{
    int who;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
    }

    private void OnMouseDown()
    {
        who = int.Parse(this.tag);

        switch (who)
        {
            case 0:
                SceneManager.LoadScene("M1_StoryScene");
                break;
            case 1:
                SceneManager.LoadScene("P1_StoryScene");
                break;
            case 2:
                SceneManager.LoadScene("W1_StoryScene");
                break;
            case 3:
                SceneManager.LoadScene("S1_StoryScene");
                break;
        }

    }
}
