using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //마우스 올렸을 때
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
