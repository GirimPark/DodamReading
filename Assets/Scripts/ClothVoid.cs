using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothVoid : MonoBehaviour
{
    bool isCloth; //옷장 화면으로 넘어왔는지 받아옴
    public GameObject cloth1,cloth2,cloth3,cloth4;
    GameObject player;
    public Sprite change_img1, change_img2, change_img3, change_img4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");//플레이어
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameObject.Find("imgTo").GetComponent<ChangeToCloth>().closetN);//왕자 도착했는지 받아옴   
        //Debug.Log(isCloth);
        /*Debug.Log(isCloth);
        Debug.Log("1234");
        if(isCloth==true){
            //옷 보여주기
            charCloth = GameObject.FindWithTag("cloth");
            charCloth.SetActive(true);
        }*/
        //옷 보여주기
        cloth1.SetActive(true);
        cloth2.SetActive(true);
        cloth3.SetActive(true);
        cloth4.SetActive(true);
        //옷 클릭하면 캐릭터 옷 갈아입히기
        if(Input.GetMouseButtonDown(0)){//마우스 클릭시
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);
            if(hit.collider!=null){//클릭한 오브젝트 이름 가져옴
                GameObject click_obj = hit.transform.gameObject;
                Debug.Log(click_obj.name);
                if(click_obj.name=="cloth1"){//옷1 클릭했을 때
                    player.GetComponent<Image>().sprite = change_img1;
                }else if(click_obj.name=="cloth2"){//옷2 클릭했을 때
                    player.GetComponent<Image>().sprite = change_img2;
                }else if(click_obj.name=="cloth3"){//옷3 클릭했을 때
                    player.GetComponent<Image>().sprite = change_img3;
                }else if(click_obj.name=="cloth4"){//옷4 클릭했을 때
                    player.GetComponent<Image>().sprite = change_img4;
                }
            }
        } 
    }
}
