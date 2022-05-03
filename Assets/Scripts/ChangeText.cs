using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    bool isWithPrince;//공주가 왕자 데리고왔을 때
    bool isArriveTrue;//도착 지점에 도착했을 때
    float distance;//공주-도착지점 거리
    private TextMeshProUGUI textArrive;//변경 텍스트
    
    // Start is called before the first frame update
    void Start()
    {
        distance = GameObject.Find("princess").GetComponent<AvoidObstacle>().distance;
        textArrive = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        isWithPrince = GameObject.Find("princess").GetComponent<AvoidObstacle>().isWithPrince;
        isArriveTrue = GameObject.Find("princess").GetComponent<AvoidObstacle>().isArriveTrue;

        if(isArriveTrue == true){
            textArrive.text = "다음 게임으로 넘어가겠습니다.";//텍스트 변경
            textArrive.color = Color.blue;//텍스트 색상 변경
        }else{
            textArrive.text = "왕자를 데리고 와주세요";//텍스트 변경
            textArrive.color = Color.red;//텍스트 색상 변경
        }
    }
}
