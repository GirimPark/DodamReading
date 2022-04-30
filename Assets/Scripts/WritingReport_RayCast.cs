using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritingReport_RayCast : MonoBehaviour
{
    float distance = 15f;
    int num = 0;
    public int maxNum = 1; // 2���� ����
    string hittedTag;
    GameObject curParent;

    Vector3 MousePosition;
    Camera cam;

    
    void Start()
    {
        cam = GetComponent<Camera>();

        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
        for (int i = 0; i < 4; i++)
        {
            curParent.transform.GetChild(i).gameObject.SetActive(true);
        }
        Debug.Log("���� text Ȱ��ȭ");
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //   || Input.GetTouch(0).phase == TouchPhase.Began
        {
            MousePosition = Input.mousePosition;    // todo : ��ġ ���� �߰��ؾ���
            MousePosition = cam.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, distance);
            Debug.DrawRay(MousePosition, transform.forward * 500, Color.red, 0.3f);
            if (hit)
            {
                Ray(hit, ref num);
            }
        }
    }


    void Ray(RaycastHit2D hit, ref int num)
    {
        hittedTag = hit.transform.gameObject.tag;
        //  �θ�tag > ��ĭ�ؽ�Ʈ=0 , �����ؽ�Ʈ=1
        //  ���� text Ȱ��ȭ
        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
        for (int i = 0; i < 4; i++)
        {
            curParent.transform.GetChild(i).gameObject.SetActive(true);
        }
        Debug.Log("���� text Ȱ��ȭ");


        //  ��ĭtext ���ÿ� �°� Ȱ��ȭ
        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[0];
        if (hittedTag.Equals("choice1"))
            curParent.transform.GetChild(0).gameObject.SetActive(true);  
        else if (hittedTag.Equals("choice2"))
            curParent.transform.GetChild(0).gameObject.SetActive(true);
        else if (hittedTag.Equals("choice3"))
            curParent.transform.GetChild(0).gameObject.SetActive(true);
        else
            curParent.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("��ĭ text Ȱ��ȭ");


        //  ����text ��Ȱ��ȭ
        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
        for (int i = 0; i < 4; i++)
        {
            curParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        Debug.Log("���� text ��Ȱ��ȭ");
        num++;

        StartCoroutine(WaitForIt());
        //  ������ ���������
        if (num == maxNum)
        {
            Ray(hit, ref num);
            StartCoroutine("Rendering");
        }
        else
        {
            Ray(hit, ref num);
        }
    }


    IEnumerator Rendering()
    {
        yield return new WaitForEndOfFrame();


        byte[] imgBytes;
        string path = @"C:\UnitySpace\Modori\Assets\Image\report.png";

        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();

        imgBytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes(path, imgBytes);
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("2�� ��ٸ���");
        bool check = true;
    }

}
