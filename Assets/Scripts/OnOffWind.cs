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

    public GameObject scene1, scene2, scene3;//신123
    public GameObject scene4, scene5;//신123
    public GameObject scene6, scene7, scene8, scene9;//신6789
     public GameObject scene10;//신10
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
        if(SceneManager.GetActiveScene().name=="M1_StoryScene"){
            if(clickN==1){
                scene1.SetActive(false);
                scene2.SetActive(true);
            }else if(clickN==2){
                scene2.SetActive(false);
                scene3.SetActive(true);
            }else if(clickN==3){
                scene3.SetActive(false);
                SceneManager.LoadScene("Game1_Obstacle");
            }
        }else if(SceneManager.GetActiveScene().name=="M2_StoryScene"){
            if(clickN==1){
                scene3.SetActive(false);
                scene4.SetActive(true);
            }else if(clickN==2){
                scene4.SetActive(false);
                scene5.SetActive(true);
            }else if(clickN==3){
                scene5.SetActive(false);
                SceneManager.LoadScene("Game2_HJ");
            }
        }else if(SceneManager.GetActiveScene().name=="M3_StoryScene"){
            if(clickN==1){
                scene6.SetActive(false);
                scene7.SetActive(true);
            }else if(clickN==2){
                scene7.SetActive(false);
                scene8.SetActive(true);
            }else if(clickN==3){
                scene8.SetActive(false);
                scene9.SetActive(true);
            }else if(clickN==4){
                scene9.SetActive(false);
                SceneManager.LoadScene("Game3_picturepuzzle");
            }
        }else if(SceneManager.GetActiveScene().name=="M4_StoryScene"){
            if(clickN==1){
                scene9.SetActive(false);
                scene10.SetActive(true);
            }else if(clickN==2){
                scene10.SetActive(false);
                PlayerPrefs.SetInt("mermaid", 10);
                Debug.Log(PlayerPrefs.HasKey("mermaid"));
                SceneManager.LoadScene("ClosetScene");  
            }
        }
    }
}
