using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class WritingReport_RayCast : MonoBehaviour
{
    GameObject done;
    float distance;
    int num;
    int maxNum; // 4문장 기준
    string hittedTag;
    bool stext; //  선택text 활성화 여부
    bool already;   //  선택text 활성화 한 번만 하도록
    GameObject curParent;
    RaycastHit2D hit;
    string path;

    int loadNum;

    Vector3 position;
    Camera cam;

    private void Awake()
    {
        stext = false;
        already = false;

        distance = 15f;
        num = 0;
        maxNum = 3;

        loadNum = 0;

        done = GameObject.Find("완료");
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        //curParent = GameObject.Find("유도텍스트" + (num + 1).ToString());

        //curParent.transform.GetChild(0).gameObject.SetActive(true);
        //Debug.Log("유도텍스트" + (num + 1) + " 활성화");

        //curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
        //for (int i = 0; i < 4; i++)
        //{
        //    curParent.transform.GetChild(i).gameObject.SetActive(true);
        //    Debug.Log("선택텍스트" + (num + 1) + "-" + (i + 1) + " 활성화");
        //}
    }

    //  부모tag > 유도텍스트=0, 빈칸텍스트=1, 선택텍스트=2
    void Update()
    {
        //  유도text, 선택text 활성화
        if (!stext && !already && num < maxNum)
        {
            curParent = GameObject.Find("유도텍스트" + (num + 1).ToString());
            
            curParent.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("유도텍스트" + (num + 1) + " 활성화");

            curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
            for (int i = 0; i < 4; i++)
            {
                curParent.transform.GetChild(i).gameObject.SetActive(true);
                Debug.Log("선택텍스트" + (num+1)+"-"+(i + 1) + " 활성화");
            }
            stext = true;
            already = true;
        }

        //  클릭시 ray() 실행
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("클릭");
            if (Input.mousePosition != null) position = Input.mousePosition;
            position = cam.ScreenToWorldPoint(position);

            hit = Physics2D.Raycast(position, transform.forward, distance);

            Debug.DrawRay(position, transform.forward * 500, Color.red, 0.3f);

            if (hit && hit.collider.gameObject.tag == "Finish")
            {
                StartCoroutine(Rendering());
                //StartCoroutine(LoadMyAsyncScene());
            }
            else if (hit && hit.collider.gameObject.tag != "Untagged")
            {
                Ray(ref hit, ref num);
                already = false;
            }
        }

        //  터치시 ray() 실행
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Input.GetTouch(0).position != null) position = Input.GetTouch(0).position;
            position = cam.ScreenToWorldPoint(position);

            hit = Physics2D.Raycast(position, transform.forward, distance);

            Debug.DrawRay(position, transform.forward * 500, Color.red, 0.3f);

            if (hit && hit.collider.gameObject.tag == "Finish")
            {
                StartCoroutine(Rendering());
                //StartCoroutine(LoadMyAsyncScene());
            }
            else if (hit && hit.collider.gameObject.tag != "Untagged")
            {
                Ray(ref hit, ref num);
                already = false;
            }
        }
    }


    void Ray(ref RaycastHit2D hit, ref int num)
    {
        Debug.Log("Ray 실행");

        hittedTag = hit.collider.gameObject.tag;

        //  빈칸text 선택에 맞게 활성화
        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[0];
        if (hittedTag == "choice1")
        {
            curParent.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("빈칸텍스트" + (num + 1) + "-1 활성화");
        }
            
        else if (hittedTag == "choice2")
        {
            curParent.transform.GetChild(1).gameObject.SetActive(true);
            Debug.Log("빈칸텍스트" + (num + 1) + "-2 활성화");
        }
        else if (hittedTag == "choice3")
        {
            curParent.transform.GetChild(2).gameObject.SetActive(true);
            Debug.Log("빈칸텍스트" + (num + 1) + "-3 활성화");
        }

        else
        {
            curParent.transform.GetChild(3).gameObject.SetActive(true);
            Debug.Log("빈칸텍스트" + (num + 1) + "-4 활성화");
        }
            

        hittedTag = "";

        //  선택text 비활성화
        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
        for (int i = 0; i < 4; i++)
        {
            curParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        stext = false;
        num++;

        if (num == maxNum)
        {
            curParent = GameObject.Find("유도텍스트" + (num + 1).ToString());
            curParent.transform.GetChild(0).gameObject.SetActive(true);
            curParent.transform.GetChild(1).gameObject.SetActive(true);

            done.GetComponent<SpriteRenderer>().enabled = true;
            done.GetComponent<BoxCollider2D>().enabled = true;
            num++;
        }
        else
        {
            curParent = GameObject.FindGameObjectsWithTag(num.ToString())[0];
            for (int i = 0; i < 4; i++)
            {
                curParent.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    
    IEnumerator Rendering() //  화면 캡쳐
    {
        yield return new WaitForEndOfFrame();


        byte[] imgBytes;
        path = @"./Assets/Resources/Reports/" + System.DateTime.Now.ToString("yyMMdd HHmmss") + ".png";
        
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();

        imgBytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes(path, imgBytes);


        loadNum = PlayerPrefs.GetInt("loadNum") + 1;
        PlayerPrefs.SetInt("loadNum", loadNum);

        Debug.Log("loadNum:" + loadNum);
        PlayerPrefs.SetString("path" + (loadNum - 1), path);

        SceneManager.LoadScene("BookReportScene");
    }

    /*IEnumerator LoadMyAsyncScene()
    {
        yield return new WaitForSeconds(1.0f);

        loadNum = PlayerPrefs.GetInt("loadNum") + 1;
        PlayerPrefs.SetInt("loadNum", loadNum);

        Debug.Log("loadNum:" + loadNum);
        PlayerPrefs.SetString("path"+(loadNum-1), path);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BookReportScene");
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
    }*/
}
