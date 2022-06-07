using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStory : MonoBehaviour
{
    public GameObject panel_ys;//, panel;
    int who;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
        if(Input.GetMouseButtonDown(0)){//마우스 클릭시
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);
            if(hit.collider!=null){//클릭한 오브젝트 이름 가져옴
                GameObject click_obj = hit.transform.gameObject;
                Debug.Log(click_obj.name);
                if(click_obj.name=="yes_im"){
                    if(PlayerPrefs.HasKey("clickMermaid")){
                        SceneManager.LoadScene("M1_StoryScene");
                    }else if(PlayerPrefs.HasKey("clickPrince")){
                        SceneManager.LoadScene("P1_StoryScene");
                    }else if(PlayerPrefs.HasKey("clickWitch")){
                        SceneManager.LoadScene("W1_StoryScene");
                    }else if(PlayerPrefs.HasKey("clickSister")){
                        SceneManager.LoadScene("S1_StoryScene");
                    }
                }else if(click_obj.name=="no_im"){
                    panel_ys.SetActive(false);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        who = int.Parse(this.tag);
        switch (who)
        {
            case 0:
                //panel.SetActive(false);
                panel_ys.SetActive(true);
                PlayerPrefs.SetInt("clickMermaid", 10);
                PlayerPrefs.DeleteKey("clickPrince");
                PlayerPrefs.DeleteKey("clickWitch");
                PlayerPrefs.DeleteKey("clickSister");
                //SceneManager.LoadScene("M1_StoryScene");
                break;
            case 1:
                //panel.SetActive(false);
                panel_ys.SetActive(true);
                PlayerPrefs.SetInt("clickPrince", 10);
                PlayerPrefs.DeleteKey("clickMermaid");
                PlayerPrefs.DeleteKey("clickWitch");
                PlayerPrefs.DeleteKey("clickSister");
                //SceneManager.LoadScene("P1_StoryScene");
                break;
            case 2:
                //panel.SetActive(false);
                panel_ys.SetActive(true);
                PlayerPrefs.SetInt("clickWitch", 10);
                PlayerPrefs.DeleteKey("clickPrince");
                PlayerPrefs.DeleteKey("clickMermaid");
                PlayerPrefs.DeleteKey("clickSister");
                //SceneManager.LoadScene("W1_StoryScene");
                break;
            case 3:
                //panel.SetActive(false);
                panel_ys.SetActive(true);
                PlayerPrefs.SetInt("clickSister", 10);
                PlayerPrefs.DeleteKey("clickPrince");
                PlayerPrefs.DeleteKey("clickWitch");
                PlayerPrefs.DeleteKey("clickMermaid");
                //SceneManager.LoadScene("S1_StoryScene");
                break;
        }

    }
}
