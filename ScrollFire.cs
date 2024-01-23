using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFire : MonoBehaviour
{
    private float ScrollX = -3;
    void Update()
    {
        float offsetX = Time.time * ScrollX;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, 0);
    }
}
