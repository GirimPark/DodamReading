using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Writing : MonoBehaviour
{
    GameObject done;
    GameObject[] objArr;
    GameObject curParent;
    int num;
    int maxNum;
    string hittedTag;

    void Start()
    {
        num = 1;
        maxNum = 4;

        done = GameObject.Find("완료");

        ActivateText();
    }

    
    void Update()
    {
        
    }

    int Compare(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

    void ActivateText()
    {
        //  유도텍스트 활성화
        objArr = GameObject.FindGameObjectsWithTag(num.ToString());
        Array.Sort<GameObject>(objArr, Compare);
        //  sorting 후 오브젝트 순서 : 빈칸, 선택, 유도
        
        curParent = objArr[2];
        Debug.Log("현재 찾아진 부모오브젝트 이름(정답 유도텍스트1) : " + curParent.name);
        curParent.transform.GetChild(0).gameObject.SetActive(true);

        //  선택텍스트 활성화
        curParent = objArr[1];
        Debug.Log("현재 찾아진 부모오브젝트 이름(정답 선택텍스트1) : " + curParent.name);
        curParent.transform.GetChild(0).gameObject.SetActive(true);
        curParent.transform.GetChild(1).gameObject.SetActive(true);
        curParent.transform.GetChild(2).gameObject.SetActive(true);
        curParent.transform.GetChild(3).gameObject.SetActive(true);
    }
}
