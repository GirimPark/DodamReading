using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;

    //로딩 프로그래스 바 이미지(유동적으로 움직일)
    [SerializeField]
    private Image progressBar;


    //로딩화면에 들어갈 이미지
    [SerializeField]
    private GameObject blackWind;

    [SerializeField]
    private GameObject schoolWind;

    [SerializeField]
    private GameObject bandWind;

    [SerializeField]
    private GameObject cafeWind;

 [SerializeField]
    private GameObject livingWind;

    [SerializeField]
    private GameObject roomWind;

    [SerializeField]
    private Text text;

    //로딩화면에 랜덤으로 나타날 메시지
    string[] mesg = new string[]{ "Tip. 대화를 통해 단서를 찾을 수 있어요.", "Tip. 주변을 둘러보면 숨겨진 단서가 있을 수 있어요.",
        "에고는 어떤 사람이었을까요?","에고는 자신이 어떤 사람인지 고민이 많았어요." };


    //로딩화면 시작
    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    string nextSceneName;
    public static void LoadScene(string sceneName)
    {


        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");

    }


    //화면에서 받아오는 이름에 따라 로딩화면 변경하기
    IEnumerator LoadScene()
    {
        yield return null;

        switch (nextScene)
        {
            case "PrologueScene":
                blackWind.SetActive(false);
                schoolWind.SetActive(false);
                cafeWind.SetActive(false);
                bandWind.SetActive(false);
                roomWind.SetActive(true);
                livingWind.SetActive(false);
                break;
            case "School1Scene":
                blackWind.SetActive(false);
                schoolWind.SetActive(true);
                cafeWind.SetActive(false);
                bandWind.SetActive(false);
                roomWind.SetActive(false);
                livingWind.SetActive(false);
                break;
            case "BandScene":
                blackWind.SetActive(false);
                schoolWind.SetActive(false);
                cafeWind.SetActive(false);
                bandWind.SetActive(true);
                roomWind.SetActive(false);
                livingWind.SetActive(false);
                break;
            case "CafeScene":
                blackWind.SetActive(false);
                schoolWind.SetActive(false);
                cafeWind.SetActive(true);
                bandWind.SetActive(false);
                roomWind.SetActive(false);
                livingWind.SetActive(false);
                break;
            case "LivingScene":
                blackWind.SetActive(false);
                schoolWind.SetActive(false);
                cafeWind.SetActive(false);
                bandWind.SetActive(false);
                roomWind.SetActive(false);
                livingWind.SetActive(true);
                break;
            case "EgoroomScene":
                blackWind.SetActive(false);
                schoolWind.SetActive(false);
                cafeWind.SetActive(false);
                bandWind.SetActive(false);
                roomWind.SetActive(true);
                livingWind.SetActive(false);
                break;
            case "EndingGame":
                blackWind.SetActive(false);
                schoolWind.SetActive(false);
                cafeWind.SetActive(false);
                bandWind.SetActive(false);
                roomWind.SetActive(true);
                livingWind.SetActive(false);
                break;
            case "EndAni":
                roomWind.SetActive(false);
                blackWind.SetActive(true);
                break;


        }

        text.text = mesg[Random.Range(0, mesg.Length)];

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
        }

    }
}