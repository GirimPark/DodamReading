using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            //Debug.Log("드래그 횟수:"+dragN);
        }
        //이미지 투명도 조절
        GameObject goImg = GameObject.Find("Canvas/marble");
        Color color = goImg.GetComponent<Image>().color;
        if(0<=dragN && dragN<50){
            color.a=1.0f;
        }else if(50<=dragN && dragN<90){
            color.a=0.8f;
        }else if(90<=dragN && dragN<110){
            color.a=0.6f;
        }else if(110<=dragN && dragN<150){
            color.a = 0.4f;
        }else{
            color.a = 0f;
            //1초 기다렸다가 다음 신으로 이동하기
            StartCoroutine(WaitAndLoadScene()); 
            IEnumerator WaitAndLoadScene()
            {
            yield return new WaitForSeconds(1.0f);

            SceneManager.LoadScene("W2_StoryScene");//신 변경
            }
        }
        goImg.GetComponent<Image>().color = color;
    }
}
