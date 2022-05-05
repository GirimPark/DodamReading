using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WritingReport_RayCast : MonoBehaviour
{
    float distance = 15f;
    int num = 0;
    public int maxNum = 1; // 2문장 기준
    string hittedTag;
    bool stext = false; //  선택text 활성화 여부
    bool already = false;   //  선택text 활성화 한 번만 하도록
    GameObject curParent;
    RaycastHit2D hit;
    string path;

    Vector3 MousePosition;
    Camera cam;

   public string getPath()
    {
        return path;
    }


    void Start()
    {
        cam = GetComponent<Camera>();

        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
        for (int i = 0; i < 4; i++)
        {
            curParent.transform.GetChild(i).gameObject.SetActive(true);
        }
        stext = true;
        Debug.Log("선택 text 활성화");
    }


    //  부모tag > 유도텍스트=0, 빈칸텍스트=1, 선택텍스트=2
    void Update()
    {
        //  유도text, 선택text 활성화
        if (!stext && !already && num<=maxNum)
        {
            curParent = GameObject.Find("유도텍스트" + (num + 1).ToString());
            curParent.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log(curParent.name+" 활성화");

            curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
            for (int i = 0; i < 4; i++)
            {
                curParent.transform.GetChild(i).gameObject.SetActive(true);
            }
            stext = true;
            already = true;
            Debug.Log("선택 text 활성화");
        }

        //  클릭시 ray() 실행
        if(Input.GetMouseButtonDown(0)) //   || Input.GetTouch(0).phase == TouchPhase.Began
        {
            MousePosition = Input.mousePosition;    // todo : 터치 버전 추가해야함
            MousePosition = cam.ScreenToWorldPoint(MousePosition);

            hit = Physics2D.Raycast(MousePosition, transform.forward, distance);
            
            Debug.DrawRay(MousePosition, transform.forward * 500, Color.red, 0.3f);
            if (hit && num == maxNum)
            {
                Ray(ref hit, ref num);
                StartCoroutine(Rendering());
                StartCoroutine(LoadMyAsyncScene());
            }
            else if(hit && num < maxNum)
            {
                Ray(ref hit, ref num);
                already = false;
            }
        }

    }


    void Ray(ref RaycastHit2D hit, ref int num)
    {
        hittedTag = hit.collider.gameObject.tag;
        

        //  빈칸text 선택에 맞게 활성화
        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[0];
        if (hittedTag.Equals("choice1"))
            curParent.transform.GetChild(0).gameObject.SetActive(true);  
        else if (hittedTag.Equals("choice2"))
            curParent.transform.GetChild(1).gameObject.SetActive(true);
        else if (hittedTag.Equals("choice3"))
            curParent.transform.GetChild(2).gameObject.SetActive(true);
        else
            curParent.transform.GetChild(3).gameObject.SetActive(true);
        Debug.Log("빈칸 text 활성화");
        

        //  선택text 비활성화
        curParent = GameObject.FindGameObjectsWithTag(num.ToString())[1];
        for (int i = 0; i < 4; i++)
        {
            curParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        stext = false;
        Debug.Log("선택 text 비활성화");
        num++;
    }

    
    IEnumerator Rendering() //  화면 캡쳐
    {
        yield return new WaitForEndOfFrame();


        byte[] imgBytes;
        path = @"C:\UnitySpace\Modori\Assets\Resources\Reports\" + System.DateTime.Now.ToString("yyMMdd HHmmss") + ".png";
        
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();

        imgBytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes(path, imgBytes);
    }

    IEnumerator LoadMyAsyncScene()
    {
        yield return new WaitForSeconds(1.0f);


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BookReportScene");
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
    }
}
