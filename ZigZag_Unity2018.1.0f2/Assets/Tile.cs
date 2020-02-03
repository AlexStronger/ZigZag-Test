using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public float test;   // ///////////////////////
    public float test2;   // ///////////////////////

    public GameObject TileP;       // префаб Тайла
    public GameObject CubCn;       // цетр тайла
    public GameObject [] blok;      // сегменты тайла (спецэффект)

    public GameObject Cristal;      // префаб кристалла
    
    public float Ptimer;           // начало ликвидации тайла (спецэффект)
 
    public float speed;                   //  (спецэффект)

    bool creat;
    bool destr;                           // команда на уничтожение тайла

    public int angl;                           // угол угол следующего блока
    int[] num = new int[2] { 0, 90 };   //  допустимые углы тайла

    int[] Gnum = new int[5] { 1, 2, 3, 4, 5 };   //  Кристаллы



    void Start () {

        creat = true;
        if (Ptimer == 0)
        {
            this.gameObject.transform.localScale = new Vector3(GlobalParametrs.GLevel, 3, GlobalParametrs.GLevel);
        }

        int index = UnityEngine.Random.Range(0, num.Length);
        angl = num[index];

        //______________________________________________________________АЛГОРИТМ ПОЯВЛЕНИЯ КРИСТАЛЛОВ________________________________________________________________
        if (Ptimer == 0)
        {
            
           


            if (GlobalParametrs.GTile < 5)
            {
                GlobalParametrs.GTile++;

                test = GlobalParametrs.GNum;
                test = GlobalParametrs.GTile;

                if (GlobalParametrs.GTile == GlobalParametrs.GNum)
                {
                    GameObject Cristall = Instantiate(Cristal, new Vector3(CubCn.transform.position.x, this.transform.position.y + 7.5f, CubCn.transform.position.z), Quaternion.Euler(0, angl, 0)) as GameObject;

                   if (GlobalParametrs.GNum == 5 && GlobalParametrs.GLevel == 1)
                    {
                            GlobalParametrs.GTile = 0;
                            GlobalParametrs.GNum = 1;
                    }

                   
                        if (GlobalParametrs.GLevel > 1)
                    {
                        GlobalParametrs.GNum = 0;
                    }
                    


                  
                    else
                    {
                        

                    }
                    
                }  
            }
            else
            {
                GlobalParametrs.GTile = 1;
                if (GlobalParametrs.GTile == GlobalParametrs.GNum)
                {
                    GameObject Cristall = Instantiate(Cristal, new Vector3(CubCn.transform.position.x, this.transform.position.y + 7.5f, CubCn.transform.position.z), Quaternion.Euler(0, angl, 0)) as GameObject;
                }
                }




            if (GlobalParametrs.GLevel == 1)                              // Cristall
            {
               

                    if (GlobalParametrs.GTile == 5)
                {
                    GlobalParametrs.GNum++;
                }

            }
            else
            {


                if (GlobalParametrs.GNum == 0 && GlobalParametrs.GTile == 5)
                {
                    int index2 = UnityEngine.Random.Range(0, Gnum.Length);
                    GlobalParametrs.GNum = Gnum[index2];
                }

            }










        }





    }

    
    void Update () {

        if (GlobalParametrs.GMove == 4)   // RESTART из "ainScript"
        {
            GlobalParametrs.GLenght = 0;
            Destroy(this.gameObject);
        }
        else
        {
            if (GlobalParametrs.GLenght < 43 && creat && !destr && Ptimer <= 0)     // генерация карты
            {
                GameObject Tile = Instantiate(TileP, new Vector3(CubCn.transform.position.x, this.transform.position.y, CubCn.transform.position.z), Quaternion.Euler(0, angl, 0)) as GameObject;
                GlobalParametrs.GLenght++;
                creat = false;
            }
        }






        if (GlobalParametrs.GMove == 1)           // удаление стартовых тайлов
        {
            if (Ptimer > 0)
            {
                Ptimer -= Time.deltaTime;
                destr = true;
                Ptimer = 0;
            }
            else
            {
                Ptimer = 0;
            }
        
        }
       


        if (destr && Ptimer <= 0) {
            speed -= 0.055f* GlobalParametrs.GSpeed;

            if (blok[0].gameObject.transform.eulerAngles.x < 285 && blok[0].gameObject.transform.eulerAngles.x > 250 || blok[0].gameObject.transform.eulerAngles.z < 285 && blok[0].gameObject.transform.eulerAngles.z > 250)
        {
            blok[0].SetActive(false);
        }
        
        if (blok[1].gameObject.transform.eulerAngles.x < 285 && blok[1].gameObject.transform.eulerAngles.x > 250 || blok[1].gameObject.transform.eulerAngles.z < 285 && blok[1].gameObject.transform.eulerAngles.z > 250)
        {
            blok[1].SetActive(false);
        }
        
        if (blok[2].gameObject.transform.eulerAngles.x < 285 && blok[2].gameObject.transform.eulerAngles.x > 250 || blok[2].gameObject.transform.eulerAngles.z < 285 && blok[2].gameObject.transform.eulerAngles.z > 250)
        {
            blok[2].SetActive(false);
        }

        if (blok[3].gameObject.transform.eulerAngles.x < 285 && blok[3].gameObject.transform.eulerAngles.x > 250 || blok[3].gameObject.transform.eulerAngles.z < 285 && blok[3].gameObject.transform.eulerAngles.z > 250)
        {
            blok[3].SetActive(false);
        }

        if (blok[4].gameObject.transform.eulerAngles.x < 285 && blok[4].gameObject.transform.eulerAngles.x > 250 || blok[4].gameObject.transform.eulerAngles.z < 285 && blok[4].gameObject.transform.eulerAngles.z > 250)
        {
            blok[4].SetActive(false);
        }

        if (blok[5].gameObject.transform.eulerAngles.x < 285 && blok[5].gameObject.transform.eulerAngles.x > 250 || blok[5].gameObject.transform.eulerAngles.z < 285 && blok[5].gameObject.transform.eulerAngles.z > 250)
        {
            blok[5].SetActive(false);
        }

        if (blok[6].gameObject.transform.eulerAngles.x < 285 && blok[6].gameObject.transform.eulerAngles.x > 250 || blok[6].gameObject.transform.eulerAngles.z < 285 && blok[6].gameObject.transform.eulerAngles.z > 250)
        {
            blok[6].SetActive(false);
        }

        if (blok[7].gameObject.transform.eulerAngles.x < 285 && blok[7].gameObject.transform.eulerAngles.x > 250 || blok[7].gameObject.transform.eulerAngles.z < 285 && blok[7].gameObject.transform.eulerAngles.z > 250)
        {
            blok[7].SetActive(false);
        }

        if (blok[8].gameObject.transform.eulerAngles.x < 285 && blok[8].gameObject.transform.eulerAngles.x > 250 || blok[8].gameObject.transform.eulerAngles.z < 285 && blok[8].gameObject.transform.eulerAngles.z > 250)
        {
            GlobalParametrs.GLenght--;
            Destroy(this.gameObject);
        }

       

        if (this.gameObject.transform.eulerAngles.y == 0)
        {
            blok[0].transform.Rotate(speed, 0, 0);
           
            if (speed < -0.5f)//1
            {
                blok[1].transform.Rotate(speed + 0.5f, 0, 0);
                blok[3].transform.Rotate(speed + 0.5f, 0, 0);//
            }
            if (speed < -1)
            {
                blok[2].transform.Rotate(speed+1, 0, 0);
            }
            if (speed < -1f)//2
            {
                blok[4].transform.Rotate(speed + 1, 0, 0);
                blok[6].transform.Rotate(speed + 1f, 0, 0);//
            }
            if (speed < -1.5f)
            {
                blok[5].transform.Rotate(speed + 1.5f, 0, 0);
            }
            if (speed < -1.5f)
            {
                blok[7].transform.Rotate(speed + 1.5f, 0, 0);
            }
            if (speed < -2f)
            {
                blok[8].transform.Rotate(speed + 2f, 0, 0);
            }
           
        }
            if (this.gameObject.transform.eulerAngles.y == 90) // 90 градусов
            {

                blok[2].transform.Rotate(0, 0, speed);

                if (speed < -0.5f)//1
                {
                    blok[5].transform.Rotate(0, 0, speed + 0.5f);
                    blok[1].transform.Rotate(0, 0, speed + 0.5f);//
                }
                if (speed < -1)
                {
                    blok[8].transform.Rotate(0, 0, speed + 1);
                }
                if (speed < -1f)//2
                {
                    blok[4].transform.Rotate(0, 0, speed + 1);
                    blok[0].transform.Rotate(0, 0, speed + 1);//
                }
                if (speed < -1.5f)
                {
                    blok[7].transform.Rotate(0, 0, speed + 1.5f);
                }
                if (speed < -1.5f)
                {
                    blok[3].transform.Rotate(0, 0, speed + 1.5f);
                }
                if (speed < -2f)
                {
                    blok[6].transform.Rotate(0, 0, speed + 2f);
                }
            }

        }





    }







    void OnTriggerStay(Collider col)            // шар над тайлом
    
        {
            if (col.gameObject.tag == "Player")
            {
            destr = true;

            }
        }
}
