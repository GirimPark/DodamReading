using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnOffWind : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] On = new GameObject[0];
    public GameObject[] Off = new GameObject[0];
    public GameObject[] destroy = new GameObject[0];

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnOffWind 실행중");

        for(int i = 0; i < On.Length; i++)
        {
            On[i].SetActive(true);
        }
        for (int i = 0; i < Off.Length; i++)
        {
            Off[i].SetActive(false);
        }
        for (int i = 0; i < destroy.Length; i++)
        {
            Destroy(destroy[i]);
        }
        
        
    }
}
