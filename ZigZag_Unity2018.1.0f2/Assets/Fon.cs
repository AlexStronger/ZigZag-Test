using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Fon : MonoBehaviour {

   float deltaTime;



    void Start () {
       deltaTime = 0f;

    }


 


        void Update ()
    {

        this.deltaTime += (Time.deltaTime - this.deltaTime) * 0.1f;        // подсчет fps
           float fps = 1.0f / this.deltaTime;
        if (fps > 15f)                                                     // если меньше 15, анимация отключается
        {
            this.transform.Rotate(0, 0, -1f*Time.deltaTime);
        }


    }
}
