using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextButton : MonoBehaviour
{
    public GameObject thisScene;
    public GameObject Lastm1Scene;
    GameObject nextScene;
    public string game;
    int tagNum;

    void Start()
    {
        tagNum = 0;
        thisScene.SetActive(true);
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
        tagNum++;

        if (thisScene.tag == "Finish")
        {
            SceneManager.LoadScene(game);
        }

        if (thisScene == Lastm1Scene)
        {
            nextScene = GameObject.FindGameObjectWithTag("Finish").transform.GetChild(0).gameObject;
            Debug.Log(nextScene.name);

            thisScene.SetActive(false);
            nextScene.SetActive(true);
            thisScene = nextScene;
            nextScene = null;
        }
        else
        {
            nextScene = GameObject.FindGameObjectWithTag(tagNum.ToString()).transform.GetChild(0).gameObject;
            Debug.Log(nextScene.name);

            thisScene.SetActive(false);
            nextScene.SetActive(true);
            thisScene = nextScene;
            nextScene = null;
        }
    }
}
