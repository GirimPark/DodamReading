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

    private Rigidbody2D rigid2D;


    void Start(){
        isArriveTrue = false;//도착 위치에 맞는지
        princeArriveTrue = false;//왕자 도착 위치에 맞는지
        startPos = transform.position;//공주 시작 위치 저장하기

        rigid2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDrag();
        }
        isWithPrince = GameObject.Find("prince").GetComponent<FollowPrincess>().isWithPrince;//왕자랑 같이 있는지 받아오기
        //도착지&공주 위치 업데이트
        arrivePos = arrivePosition.transform.position;
        princessPos = transform.position;
        Debug.Log(transform.position);

        //distance = Vector2.Distance(princessPos, arrivePos);

        //왕자&공주 위치 업데이트
        princePos = princePosition.transform.position;
        distanceP = Vector2.Distance(princePos, princessPos);

        //if (isArriveTrue==false && distance<=0.5f && isWithPrince==true)//도착지 도착했을 때
        if (isArriveTrue==false && transform.position.x<6.0&&transform.position.x>4.5 && transform.position.y <3.5 &&transform.position.y>0.5 && isWithPrince==true)
        {
            transform.position = arrivePos;//공주 위치랑 도착지 위치 맞춰줌
            isArriveTrue = true;
            princeArriveTrue = true;
        }
        Debug.Log(transform.position);

        //마우스로 위치 조정
        /*float x =Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rigid2D.velocity = new Vector3(x,y,0)*5.0f;*/
        //왼쪽으로 이동
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.position += new Vector3(-0.02f, 0.0f, 0.0f);
        }
        //오른쪽으로 이동
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.position += new Vector3(0.02f, 0.0f, 0.0f);
        }
        //앞으로 이동
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.position += new Vector3(0.0f, -0.02f, 0.0f);
        }
        //뒤로 이동
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.position += new Vector3(0.0f, 0.02f, 0.0f);
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