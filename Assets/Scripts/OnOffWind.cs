using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OnOffWind : MonoBehaviour, IPointerClickHandler
{
    /*public GameObject[] On = new GameObject[0];
    public GameObject[] Off = new GameObject[0];
    public GameObject[] destroy = new GameObject[0];*/
    //인어공주 신
    public GameObject scene1, scene2, scene3;//신123
    public GameObject scene4, scene5;//신456
    public GameObject scene6, scene7, scene8, scene9;//신6789
    public GameObject scene10;//신10
    //언니들 신
    public GameObject Sscene1, Sscene2, Sscene3, Sscene4, Sscene5, Sscene6, Sscene7, Sscene8;

    string scene = "WritingReportScene_";
    int clickN=0;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnOffWind 실행중");

        /*for(int i = 0; i < On.Length; i++)
        {
            On[i].SetActive(true);
        }
        for (int i = 0; i < Off.Length; i++)
        {
            Off[i].SetActive(false);
        }
        for (int i = 0; i < destroy.Length; i++)
        {
            Destroy(destroy[i]);
        }*/
        clickN++;
        
        
    }
    void Start(){
        PlayerPrefs.DeleteKey("mermaid");
    }
    void Update(){
        if (SceneManager.GetActiveScene().name == "M1_StoryScene")
        {
            if (clickN == 1)
            {
                scene1.SetActive(false);
                scene2.SetActive(true);
            }
            else if (clickN == 2)
            {
                scene2.SetActive(false);
                scene3.SetActive(true);
            }
            else if (clickN == 3)
            {
                scene3.SetActive(false);
                SceneManager.LoadScene("Game1_Obstacle");
            }
        }
        else if (SceneManager.GetActiveScene().name == "M2_StoryScene")
        {
            if (clickN == 1)
            {
                scene3.SetActive(false);
                scene4.SetActive(true);
            }
            else if (clickN == 2)
            {
                scene4.SetActive(false);
                scene5.SetActive(true);
            }
            else if (clickN == 3)
            {
                scene5.SetActive(false);
                SceneManager.LoadScene("Game2_HJ");
            }
        }
        else if (SceneManager.GetActiveScene().name == "M3_StoryScene")
        {
            if (clickN == 1)
            {
                scene6.SetActive(false);
                scene7.SetActive(true);
            }
            else if (clickN == 2)
            {
                scene7.SetActive(false);
                scene8.SetActive(true);
            }
            else if (clickN == 3)
            {
                scene8.SetActive(false);
                scene9.SetActive(true);
            }
            else if (clickN == 4)
            {
                scene9.SetActive(false);
                SceneManager.LoadScene("Game3_picturepuzzle");
            }
        }
        else if (SceneManager.GetActiveScene().name == "M4_StoryScene")
        {
            if (clickN == 1)
            {
                scene9.SetActive(false);
                scene10.SetActive(true);
            }
            else if (clickN == 2)
            {
                scene10.SetActive(false);
                //인어공주 옷 활성화
                PlayerPrefs.SetInt("mermaid", 10);
                Debug.Log(PlayerPrefs.HasKey("mermaid"));
                scene = scene + SceneManager.GetActiveScene().name[0];
                SceneManager.LoadScene(scene);
            }
        }
        else if (SceneManager.GetActiveScene().name == "S1_StoryScene")
        {//인어공주 언니들 신
            if (clickN == 1)
            {
                Sscene1.SetActive(false);
                SceneManager.LoadScene("Game10_OX");
            }
        }
        else if (SceneManager.GetActiveScene().name == "S2_StoryScene")
        {
            if (clickN == 1)
            {
                Sscene1.SetActive(false);
                Sscene2.SetActive(true);
            }
            else if (clickN == 2)
            {
                Sscene2.SetActive(false);
                Sscene3.SetActive(true);
            }
            else if (clickN == 3)
            {
                Sscene3.SetActive(false);
                Sscene4.SetActive(true);
            }
            else if (clickN == 4)
            {
                Sscene4.SetActive(false);
                SceneManager.LoadScene("Game11Cutting");
            }
        }
        else if (SceneManager.GetActiveScene().name == "S4_StoryScene")
        {
            if (clickN == 1)
            {
                Sscene4.SetActive(false);
                Sscene5.SetActive(true);
            }
            else if (clickN == 2)
            {
                Sscene5.SetActive(false);
                SceneManager.LoadScene("Game12_Calendar");
            }
        }
        else if (SceneManager.GetActiveScene().name == "S5_StoryScene")
        {
            if (clickN == 1)
            {
                Sscene6.SetActive(false);
                Sscene7.SetActive(true);
            }
            else if (clickN == 2)
            {
                Sscene7.SetActive(false);
                Sscene8.SetActive(true);
                //언니들 옷 활성화
                PlayerPrefs.SetInt("sister", 10);
                Debug.Log(PlayerPrefs.HasKey("sister"));
            }
        }
        else if (SceneManager.GetActiveScene().name == "P1_StoryScene")
        {
            if (clickN == 1)
            {
                scene1.SetActive(false);
                scene2.SetActive(true);
            }
            else if (clickN == 2)
            {
                scene2.SetActive(false);
                scene3.SetActive(true);
            }
            else if (clickN == 3)
            {
                scene3.SetActive(false);
                scene4.SetActive(true);
            }
            else if (clickN == 4)
            {
                //   scene3.SetActive(false);
                SceneManager.LoadScene("Game7FindPricess");
            }
        }
        else if (SceneManager.GetActiveScene().name == "P2_StoryScene")
        {
            if (clickN == 1)
            {
                scene4.SetActive(false);
                scene5.SetActive(true);
            }
            else if (clickN == 2)
            {
                scene5.SetActive(false);
                scene6.SetActive(true);
            }
            else if (clickN == 3)
            {
              //  scene7.SetActive(false);
                SceneManager.LoadScene("game8_heart");
            }
        }
        else if (SceneManager.GetActiveScene().name == "P3_StoryScene")
        {
            if (clickN == 1)
            {
                scene7.SetActive(false);
                scene8.SetActive(true);

            }
            else if (clickN == 2)
            {

                // scene7.SetActive(false);
                SceneManager.LoadScene("Game9_findLetter");
            }

        }
        else if (SceneManager.GetActiveScene().name == "P4_StoryScene")
        {
            //제일 마지막페이지
            if (clickN == 1)
            {
                scene8.SetActive(false);
                scene9.SetActive(true);
            }
            else if (clickN == 2)
            {
                //왕자 옷 활성화
                //  PlayerPrefs.SetInt("prince", 10);
                // Debug.Log(PlayerPrefs.HasKey("prince"));
            }

        }


    }
}
