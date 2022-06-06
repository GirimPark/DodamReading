using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EffectAudio : MonoBehaviour, IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{

    public AudioClip audio;
 //   public AudioClip audio2;
    private AudioSource effect;


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("클릭");
        //   effect.Play();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("다운");
        effect.clip = audio;
        effect.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (gameObject.tag == "Drag")
        {
            effect.Stop();
        }
        if(gameObject.tag == "potion")
        {
   //         effect.clip = audio2;
     //       effect.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        effect = gameObject.AddComponent<AudioSource>();
        effect.loop = false;
        effect.clip = audio;

    }

    // Update is called once per frame
    void Update()
    {
        
        //string sceneName= SceneManager.GetActiveScene().name;
        //string game = "game";
        //bool b = sceneName.Contains(game);
        if(gameObject.tag == "Drag")
        {
            effect.loop = true;
        }
        else
        {
            effect.loop = false;
        }
        
    }
}
