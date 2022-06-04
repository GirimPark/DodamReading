using UnityEngine;
using UnityEngine.SceneManagement;

public class nextButton : MonoBehaviour
{
    GameObject thisScene;
    GameObject nextScene;
    public string game;
    int sceneNum;

    void Start()
    {
        sceneNum = 0;

        thisScene = GameObject.Find("scene").transform.GetChild(sceneNum).gameObject;
        thisScene.SetActive(true);
        sceneNum++;
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
        //  마지막 씬인 경우 다음 게임/독후감으로 넘어가기
        if (thisScene.tag == "Finish")
        {
            if(game == "WritingReportScene_W")
            {
                PlayerPrefs.SetInt("witch", 10);
            }
            else if (game == "WritingReportScene_M")
            {
                PlayerPrefs.SetInt("mermaid", 20);
            }
            else if (game == "WritingReportScene_S")
            {
                PlayerPrefs.SetInt("sister", 30);
            }
            else if (game == "WritingReportScene_P")
            {
                PlayerPrefs.SetInt("prince", 40);
            }

            thisScene.SetActive(false);
            SceneManager.LoadScene(game);

            return;
        }

        //  씬 넘기기
        Debug.Log("childcount : "+GameObject.Find("scene").transform.childCount);
        Debug.Log("sceneNum : " + sceneNum);
        nextScene = GameObject.Find("scene").transform.GetChild(sceneNum).gameObject;
        sceneNum++;

        thisScene.SetActive(false);
        nextScene.SetActive(true);
        thisScene = nextScene;
        nextScene = null;
    }
}
