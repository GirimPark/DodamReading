using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AvoidObstacle : MonoBehaviour
{
    bool isArriveTrue;//도착지랑 위치 맞았는지
    bool isWithPrince;//왕자랑 같이 왔는지
    float distance;

    public GameObject arrivePosition;//도착 오브젝트
    public Vector2 arrivePos;//도착지 위치
    public Vector2 princessPos;//공주 위치
    public Vector2 startPos;//시작 위치

    public Text arriveText; //텍스트
    //TextMeshProUGUI arriveText;

   /* [SerializeField] SpriteRenderer spriteRenderer;
    public Vector3 LoadedPos;
    float startPosx;
    float startPosY;
    bool isBeingHeld = false;
    public bool isInLine;
    float timelinePosY;

    private void Start() 
    {
        LoadedPos = this.transform.position; 
    }
    private void Update() 
    {
        if(isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position = new Vector2(mousePos.x - startPosx, mousePos.y - startPosY);
        }
    }


    #region 마우스 드래그앤 드롭



    private void OnMouseDown() 
    {
        if(Input.GetMouseButtonDown(0))
        {

            spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            startPosx = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;


            isBeingHeld = true;

        }
    }

    private void OnMouseUp() 
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        isBeingHeld = false;

        if(isInLine)
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.localPosition.x, timelinePosY, -1f);
        else 
            this.gameObject.transform.position = LoadedPos;
    }



    #endregion
    
    
    #region 타임라인이랑 맞는지
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("TimeLine"))
        {
            isInLine = true;
            timelinePosY = other.transform.position.y;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("TimeLine"))
        {
            isInLine = false;
        }
    }


    #endregion*/

    void Start(){
        isArriveTrue = false;//도착 위치에 맞는지
        isWithPrince = false;//왕자랑 같이 왔는지
        startPos = transform.position;//공주 시작 위치 저장하기
        //arriveText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        arrivePos = arrivePosition.transform.position;
        princessPos = transform.position;

        distance = Vector2.Distance(princessPos, arrivePos);

        /*if (isArriveTrue==false && distance<=0.5f)
        {
            transform.position = arrivePos;//공주 위치랑 도착지 위치 맞춰줌
            isArriveTrue = true;
        }
        if(isArriveTrue==true){
            //왕자랑 같이 왔을 때
            if(isWithPrince==true){
                arriveText.text="다음 게임으로 넘어가겠습니다.";
            }
            //왕자 안데리고 왔을 때
            else if(isWithPrince==false){
                //arriveText.text = resource.ToString();
                arriveText.text="왕자를 데리고 오세요";
                //transform.position = startPos;//위치 시작 위치로 바꿔주기
            }
        }*/
        if (isArriveTrue==false && distance<=0.5f && isWithPrince==true)
        {
            //왕자를 데리고 왔을 때
            transform.position = arrivePos;//공주 위치랑 도착지 위치 맞춰줌
            isArriveTrue = true;
            arriveText.text="다음 게임으로 넘어가겠습니다.";
        }else if(distance<=0.5f && isWithPrince==false){
            //왕자를 못데리고 왔을 때
            arriveText.text="왕자를 데리고 오세요";
        }
    }

    void OnMouseDrag() 
    {
        if (distance <= 0.5f && isWithPrince==true) return;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

} 