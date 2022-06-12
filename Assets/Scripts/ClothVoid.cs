using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClothVoid : MonoBehaviour
{
    public GameObject cloth1, cloth2, cloth3, cloth4; //캐릭터 옷 목록
    public Sprite change_img1, change_img2, change_img3, change_img4, player_img;//변경할 이미지 
    bool isMermaid, isTrue, isSister, isWitch, isPrince;//동화구연에서 넘어왓는지 
    Image thisImg; //현재 이미지
    int trueCount, trueCountS, trueCountP,trueCountW;

    //효과음
    public AudioClip audio;
    AudioSource audioSource;
    
    void Awake(){
        this.audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //옷장씬 갔다와야지만 isFairy 활성화 되도록
        if(PlayerPrefs.HasKey("mermaid")){//인어공주
            isMermaid=true;
        }if(PlayerPrefs.HasKey("sister")){//인어공주 언니
            isSister=true;
        }if(PlayerPrefs.HasKey("witch")){//마녀
            isWitch=true;
        }if(PlayerPrefs.HasKey("prince")){//왕자
            isPrince=true;
        }
        thisImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("공주:"+isMermaid);
        Debug.Log("왕자:"+isPrince);
        Debug.Log("마녀:"+isWitch);
        Debug.Log("언니:"+isSister);
        //동화 구연에서 값이 넘어왔다면
        if(isMermaid == true){
            cloth4.SetActive(true);
        }if(isSister==true){
            Debug.Log("공주공주");
            cloth2.SetActive(true);
        }if(isWitch==true){
            cloth1.SetActive(true);
        }if(isPrince==true){
            cloth3.SetActive(true);
            Debug.Log("오아자왕자");
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
                    PlaySound("play");//효과음 재생
                }else if(click_obj.name=="cloth2"){
                    transform.localScale = new Vector2(0.29f,0.34f);//크기 맞춰주기
                    thisImg.sprite = change_img2;
                    PlaySound("play");//효과음 재생
                }else if(click_obj.name=="cloth3"){
                    transform.localScale = new Vector2(0.2f,0.35f);//크기 맞춰주기
                    thisImg.sprite = change_img3;
                    PlaySound("play");//효과음 재생
                }else if(click_obj.name=="cloth4"){
                    transform.localScale = new Vector2(0.23f,0.35f);//크기 맞춰주기
                    thisImg.sprite = change_img4;
                    PlaySound("play");//효과음 재생
                }else if(click_obj.name=="btn_reset"){
                    transform.localScale = new Vector2(0.2f,0.35f);//크기 맞춰주기
                    thisImg.sprite = player_img;
                    PlaySound("play");//효과음 재생
                }
            }
        }
    }
    void PlaySound(string action){
        switch(action){
            case "play":
                audioSource.clip=audio;
                break;
        }
        audioSource.Play();
    }
    
}
