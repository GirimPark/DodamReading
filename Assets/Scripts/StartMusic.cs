using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMusic : MonoBehaviour
{
   // 0:기본 1:인어공주 2:왕자 3:마녀 4:언니
        public AudioClip[] BGMList;
    private AudioSource BGM;


    // Start is called before the first frame update
    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;
        BGM.clip = BGMList[0];
        BGM.Play();
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      if(SceneManager.GetActiveScene().name == "M1_StoryScene")
        {
            BGM.clip = BGMList[1];
            if (!BGM.isPlaying)
            {
             BGM.Play();
            }
          
        }
        else if (SceneManager.GetActiveScene().name == "P1_StoryScene")
        {
            BGM.clip = BGMList[2];
            if (!BGM.isPlaying)
            {
                BGM.Play();
            }
        }
        else if (SceneManager.GetActiveScene().name == "W1_StoryScene")
        {
            BGM.clip = BGMList[3];
            if (!BGM.isPlaying)
            {
                BGM.Play();
            }
        }
        else if (SceneManager.GetActiveScene().name == "S1_StoryScene")
        {
            BGM.clip = BGMList[4];
            if (!BGM.isPlaying)
            {
                BGM.Play();
            }
        }
        else if (SceneManager.GetActiveScene().name == "BookReportScene" || SceneManager.GetActiveScene().name == "MainLibraryScene")
        {
            BGM.clip = BGMList[0];
            if (!BGM.isPlaying)
            {
                BGM.Play();
            }
        }

    }
}
