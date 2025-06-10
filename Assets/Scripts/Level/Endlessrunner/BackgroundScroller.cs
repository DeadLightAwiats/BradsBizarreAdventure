using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = -5f;
    [SerializeField] private Renderer bgRend;

   
    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
    }
    
}
