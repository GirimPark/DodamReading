using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOX : MonoBehaviour
{
    GameObject positive1, positive2, negative;//기존 이미지
    public GameObject o1, x1, x2;
    // Start is called before the first frame update
    void Start()
    {
        positive1 = GameObject.Find("positive1");
        negative = GameObject.Find("negative");
        positive2 = GameObject.Find("positive2");
    }

   void Update(){
       if(Input.GetMouseButtonDown(0)){//마우스 클릭시
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);
            if(hit.collider!=null){//클릭한 오브젝트 이름 가져옴
                GameObject click_obj = hit.transform.gameObject;
                Debug.Log(click_obj.name);
                if(click_obj.name=="negative"){//공주3 클릭했을 때
                    o1.SetActive(true);
                    //1초 기다렸다가 다음 신으로 이동하기
                    StartCoroutine(WaitAndLoadScene()); 
                    IEnumerator WaitAndLoadScene()
                    {
                    yield return new WaitForSeconds(1.0f);

                    SceneManager.LoadScene("S2_StoryScene");//신 변경
                    }
                }else if(click_obj.name=="positive1"){
                    x1.SetActive(true);
                }else if(click_obj.name=="positive2"){
                    x2.SetActive(true);
                }
            }
        }
   }
}
