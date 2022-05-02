using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FairyVoid : MonoBehaviour
{
    public GameObject fairyT, img;
    //public bool closetTF;//옷장으로 이동했는지 확인
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("누름");
            //텍스트 보여주기 
            fairyT.SetActive(true);
            img.SetActive(true);
        }
    }
}
