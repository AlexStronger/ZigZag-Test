using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public GameObject Cub1;               // составная кристала
    public GameObject Cub2;               // составная кристала
    Renderer rend;
    public Material MatRed;
    public Material MatBlack;
    float lerp;

    bool take;
    float scale;
    float rotate;

    void Start () {

        rotate = -0.25f;
        lerp = 0.1f;
        

    }


    void Update () {


        if (Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Ball").transform.position) < 8f)   // если близко к
        {
            take = true;
        }






            if (take)
        {
            rotate = 1;
            scale += 0.004f;
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x+scale, this.gameObject.transform.localScale.y + scale, this.gameObject.transform.localScale.z + scale);
            this.transform.Translate(Vector3.up * Time.deltaTime * 6);


            if (lerp <= 1)
            {
                lerp = lerp + 0.015f;
            }
            else
            {
                lerp = 1;
                GlobalParametrs.GBonus ++;
                Destroy(this.gameObject);
            }

            rend = Cub1.GetComponent<Renderer>();

            rend.material.Lerp(MatRed, MatBlack, lerp);

            rend = Cub2.GetComponent<Renderer>();

            rend.material.Lerp(MatRed, MatBlack, lerp);

        }




        if (GlobalParametrs.GMove == 4)   // RESTART из "ainScript"
        {
           
            Destroy(this.gameObject);
        }




        this.transform.Rotate(0, rotate, 0);
    }
}
