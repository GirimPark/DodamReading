using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AvoidObstacle : MonoBehaviour
{
    public bool isArriveTrue;//공주 도착지랑 위치 맞았는지
    public bool princeArriveTrue;//왕자 도착지랑 위치 맞았는지
    public bool isWithPrince;//왕자랑 같이 왔는지
    public float distance;

    public GameObject arrivePosition;//도착 오브젝트
    public Vector2 arrivePos;//도착지 위치
    public Vector2 princessPos;//공주 위치
    public Vector2 startPos;//시작 위치

    public GameObject princePosition;//왕자 오브젝트
    public Vector2 princePos;//왕자 위치
    public float distanceP;


    void Start(){
        isArriveTrue = false;//도착 위치에 맞는지
        princeArriveTrue = false;//왕자 도착 위치에 맞는지
        startPos = transform.position;//공주 시작 위치 저장하기
    }
    void Update()
    {
        isWithPrince = GameObject.Find("prince").GetComponent<FollowPrincess>().closeDistance;//왕자랑 같이 있는지 받아오기
        //도착지&공주 위치 업데이트
        arrivePos = arrivePosition.transform.position;
        princessPos = transform.position;

        distance = Vector2.Distance(princessPos, arrivePos);

        //왕자&공주 위치 업데이트
        princePos = princePosition.transform.position;
        distanceP = Vector2.Distance(princePos, princessPos);

        if (isArriveTrue==false && distance<=0.5f && isWithPrince==true)//도착지 도착했을 때
        {
            transform.position = arrivePos;//공주 위치랑 도착지 위치 맞춰줌
            isArriveTrue = true;
            princeArriveTrue = true;
        }
    }

    void OnMouseDrag() 
    {
        if (isArriveTrue == true && isWithPrince==true) return;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

} 