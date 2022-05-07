using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseEvent : MonoBehaviour
{
    Image this_img;//현재 이미지
    public Sprite change_img;//바꿀 이미지

    Vector2 startPos, deltaPos, nowPos;
    bool isDragged;
    const float dragAccuracy = 50f;
    //드래그 횟수 세주기
    int dragN=0;

    [SerializeField] Slider slider = null;
 
 void Start(){
     //기본 이미지
     this_img=GetComponent<Image>();
     //프로그레스바 진행 상황
     //SetFillAmount(0);
     slider.value = 0;
 }
 void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
        //드래그 횟수 500 넘으면 이미지 바꿔주기
        if (dragN<500){
            slider.value = (dragN/5);
        }
        else if(dragN>500){
            this_img.sprite=change_img;
            slider.value = 100;
        }
    }
}
