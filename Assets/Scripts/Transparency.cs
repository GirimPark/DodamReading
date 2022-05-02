using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparency : MonoBehaviour
{
    Image this_img;//현재 이미지

    Vector2 startPos, deltaPos, nowPos;
    bool isDragged;
    const float dragAccuracy = 50f;
    //드래그 횟수 세주기
    int dragN=0;
 
 void Start(){
     //기본 이미지
     this_img=GetComponent<Image>();
 }
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
 
        if(Input.GetMouseButton(0)) //터치했다면
        /*손가락터치 if(Input.GetTouch(0))*/
        {
            /*손가락터치 Input.GetTouch(0).position*/
            nowPos = (Input.touchCount == 0) ? (Vector2)Input.mousePosition : Input.GetTouch(0).position;
 
            if (Input.GetMouseButtonDown(0)) //터치 시작인경우
            /*손가락터치 if(Input.GetTouch(0))*/
                startPos = nowPos;
 
            deltaPos = startPos - nowPos;
 
            if(deltaPos.sqrMagnitude > dragAccuracy)    //정확도 계산
            {
                startPos = nowPos;
                isDragged = true;
            }
        }
        /*손가락터치
        Touch touch = Input.GetTouch(0);
        switch(touch.phase){
            case TouchPhase.Moved://드래그
            case TouchPhase.Ended://화면에서 손 뗐을 때
        }
        */
        if (Input.GetMouseButtonUp(0))  //터치 끝
        {
            isDragged = false;
        }
        
        //드래그 했을 때
        if (isDragged==true){
            dragN++;
            Debug.Log("드래그 횟수:"+dragN);
        }
        //이미지 투명도 조절
        GameObject goImg = GameObject.Find("Canvas/princess1");
        Color color = goImg.GetComponent<Image>().color;
        if(0<=dragN && dragN<100){
            color.a=1.0f;
        }else if(100<=dragN && dragN<200){
            color.a=0.8f;
        }else if(200<=dragN && dragN<300){
            color.a=0.6f;
        }else if(300<=dragN && dragN<400){
            color.a = 0.4f;
        }else{
            color.a = 0f;
        }
        goImg.GetComponent<Image>().color = color;
    }
}
