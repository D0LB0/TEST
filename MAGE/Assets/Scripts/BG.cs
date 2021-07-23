using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    float lenght, startPos;
    public Transform cam;
    public float paralaxEffect;



    void Start()
    {
        startPos = cam.transform.position.x; //присваеваем стартовою позицию позиции камеры
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }


    void FixedUpdate()
    {
        float dist = cam.transform.position.x * paralaxEffect;
        float temp = cam.transform.position.x * (1 - paralaxEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if (temp > startPos + lenght) startPos += lenght;
        if (temp < startPos - lenght) startPos -= lenght;
    }
}
