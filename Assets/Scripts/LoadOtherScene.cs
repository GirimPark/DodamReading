using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOtherScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){//마우스 클릭시
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);
            if(hit.collider!=null){//클릭한 오브젝트 이름 가져옴
                GameObject click_obj = hit.transform.gameObject;
                Debug.Log(click_obj.name);
                if(click_obj.name=="btn_setting"){//설정 클릭
                    SceneManager.LoadScene("SettingScene");
                }else if(click_obj.name=="btn_store"){//상점 클릭
                    SceneManager.LoadScene("ClosetScene");
                }else if(click_obj.name=="sign"){//도서관 팻말 클릭
                    SceneManager.LoadScene("MainLibraryScene");
                }else if(click_obj.name=="reportSign"){//독후감 팻말 클릭
                    SceneManager.LoadScene("BookReportScene");
                }else if(click_obj.name=="book1"){//인어공주 책 클릭
                    SceneManager.LoadScene("FairyStoryScene");
                } 
            }
        }  
    }
}