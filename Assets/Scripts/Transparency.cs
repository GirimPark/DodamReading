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
        if(Input.GetMouseButton(0)) //터치했다면
        {
            nowPos = (Input.touchCount == 0) ? (Vector2)Input.mousePosition : Input.GetTouch(0).position;
 
            if (Input.GetMouseButtonDown(0)) //터치 시작인경우
                startPos = nowPos;
 
            deltaPos = startPos - nowPos;
 
            if(deltaPos.sqrMagnitude > dragAccuracy)    //정확도 계산
            {
                startPos = nowPos;
                isDragged = true;
            }
        }
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
