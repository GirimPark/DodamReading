using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothVoid : MonoBehaviour
{
    public GameObject cloth1, cloth2, cloth3, cloth4; //캐릭터 옷 목록
    public Sprite change_img1, change_img2, change_img3, change_img4, player_img;//변경할 이미지 
    GameObject player;//플레이어 기본 이미지
    bool isFairy;//동화구연에서 넘어왓는지 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        /*손가락 터치
        if(Input.touchCount>0){
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began://터치 시작했을 때
                    break;
                case TouchPhase.Moved://터치한 상태에서 운직였을 때
                    break;
                case TouchPhase.Stationary://움직이다가 가만히 있을 때
                    break;
                case TouchPhase.Ended://화면에서 손 뗐을 때
                    break;
                case TouchPhase.Canceled://시스템에 의해 터치 취소됐을 때
                    break;
            }
        }
        */
        //Debug.Log(GameObject.Find("changeO").GetComponent<FairyVoid>().closetTF);
        isFairy = GameObject.Find("changeO").GetComponent<FairyVoid>().closetTF;
        //동화 구연에서 값이 넘어왔다면
        if(isFairy == true){
            //옷 목록 보여주기
            cloth1.SetActive(true);
            cloth2.SetActive(true);
            cloth3.SetActive(true);
            cloth4.SetActive(true);
            if(Input.GetMouseButtonDown(0)){//마우스 클릭시
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);
                if(hit.collider!=null){//클릭한 오브젝트 이름 가져옴
                    GameObject click_obj = hit.transform.gameObject;
                    Debug.Log(click_obj.name);
                    //옷 입히기 
                    if(click_obj.name=="cloth1"){
                        player.GetComponent<Image>().sprite = change_img1;
                    }else if(click_obj.name=="cloth2"){
                        player.GetComponent<Image>().sprite = change_img2;
                    }else if(click_obj.name=="cloth3"){
                        player.GetComponent<Image>().sprite = change_img3;
                    }else if(click_obj.name=="cloth4"){
                        player.GetComponent<Image>().sprite = change_img4;
                    }else if(click_obj.name=="btn_reset"){
                        player.GetComponent<Image>().sprite = player_img;
                    }
                }
            }
        }
    }
}
