using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClothVoid : MonoBehaviour
{
    public GameObject cloth1, cloth2, cloth3, cloth4; //캐릭터 옷 목록
    public Sprite change_img1, change_img2, change_img3, change_img4, player_img;//변경할 이미지 
    bool isMermaid, isTrue;//동화구연에서 넘어왓는지 
    Image thisImg; //현재 이미지
    int trueCount;

    // Start is called before the first frame update
    void Start()
    {
        /*if((object)GameObject.Find("changeO").GetComponent<FairyVoid>().closetTF!=null){
            isFairy=true;
        }else{
            isFairy=false;
        }*/
        /*if(SceneManager.GetActiveScene().name=="ClosetScene"){
            PlayerPrefs.DeleteKey("key");
        }else if(SceneManager.GetActiveScene().name=="FairyStoryScene"){
            PlayerPrefs.SetInt("key", 10);
        }*/
        //PlayerPrefs.DeleteAll();
        //옷장씬 갔다와야지만 isFairy 활성화 되도록
        if(PlayerPrefs.HasKey("mermaid")==true){
            trueCount++;
            if(trueCount>=1){
                isMermaid=true;
                PlayerPrefs.DeleteKey("mermaid");
            }
        }
        thisImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //동화 구연에서 값이 넘어왔다면
        if(isMermaid == true){
            //옷 목록 보여주기
            //cloth1.SetActive(true);
            //cloth2.SetActive(true);
            //cloth3.SetActive(true);
            cloth4.SetActive(true);
        }
        if(Input.GetMouseButtonDown(0)){//마우스 클릭시
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);
            if(hit.collider!=null){//클릭한 오브젝트 이름 가져옴
                GameObject click_obj = hit.transform.gameObject;
                Debug.Log(click_obj.name);
                //옷 입히기 
                if(click_obj.name=="cloth1"){
                    transform.localScale = new Vector2(0.40f,0.36f);//크기 맞춰주기
                    thisImg.sprite = change_img1;
                }else if(click_obj.name=="cloth2"){
                    transform.localScale = new Vector2(0.29f,0.34f);//크기 맞춰주기
                    thisImg.sprite = change_img2;
                }else if(click_obj.name=="cloth3"){
                    transform.localScale = new Vector2(0.2f,0.35f);//크기 맞춰주기
                    thisImg.sprite = change_img3;
                }else if(click_obj.name=="cloth4"){
                    transform.localScale = new Vector2(0.23f,0.35f);//크기 맞춰주기
                    thisImg.sprite = change_img4;
                }else if(click_obj.name=="btn_reset"){
                    transform.localScale = new Vector2(0.2f,0.35f);//크기 맞춰주기
                    thisImg.sprite = player_img;
                }
            }
        }
    }
    
}
