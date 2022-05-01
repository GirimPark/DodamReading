using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothVoid : MonoBehaviour
{
    bool isCloth; //옷장 화면으로 넘어왔는지 받아옴
    GameObject charCloth; //캐릭터 옷 목록

    // Start is called before the first frame update
    void Start()
    {
        isCloth = false;
    }

    // Update is called once per frame
    void Update()
    {
        isCloth = GameObject.Find("Text1").GetComponent<FairyVoid>().closetTF;//왕자 도착했는지 받아옴   
        Debug.Log(isCloth);
        Debug.Log("1234");
        if(isCloth==true){
            //옷 보여주기
            charCloth = GameObject.FindWithTag("cloth");
            charCloth.SetActive(true);
        }
    }
}
