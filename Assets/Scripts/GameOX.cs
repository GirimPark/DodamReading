using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOX : MonoBehaviour
{
    GameObject positive1, positive2, negative;//기존 이미지
    public Sprite change_img;
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
                    negative.GetComponent<Image>().sprite = change_img;//이미지 변경
                }
            }
        } 
   }
}
