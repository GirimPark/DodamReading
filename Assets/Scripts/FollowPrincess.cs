using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPrincess : MonoBehaviour
{
    public float speed;//왕자 움직이는 속도
    float distanceP;//왕자-공주 거리
    public bool closeDistance;//왕자-공주 가까운지
    bool princeArrive;//왕자 도착지에 도착했는지
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("princess").transform;
    }

    // Update is called once per frame
    void Update()
    {
        princeArrive = GameObject.Find("princess").GetComponent<AvoidObstacle>().princeArriveTrue;//왕자 도착했는지 받아옴

        if(GameObject.Find("princess").GetComponent<AvoidObstacle>().distanceP<0.5f && transform.position.y- player.position.y<1){
            //왕자와 공주가 만났을 때
            closeDistance = true;
        }
        if(closeDistance==true){
            //왕자 움직임 줌
            transform.Translate(new Vector2(-1,0)*Time.deltaTime*speed);
            DirectionPrince();
        }
        if(princeArrive==true){//도착지 도착했으면 멈추기
            speed=0;
        }
    }
    void DirectionPrince(){
        //공주 움직이는 방향에 맞춰 왕자 방향 바꿔줌
        if(transform.position.x- player.position.x<0){
            transform.eulerAngles = new Vector3(0,180,0);
        }else{
            transform.eulerAngles = new Vector3(0,0,0);
        }
    }
}
