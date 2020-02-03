using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CnControls;



public class MainScript : MonoBehaviour
{


    public GameObject PanelMenu;           // панель меню

    public GameObject PanelBlack;          // панель затемнение
    public Image _sprite = null;           //  затемнение
    float alpha;                           // Скорость изменения цвета.
    public float a;
    public Text time;                   // показания время, кристалы 
    public Text crist;                   // показания время, кристалы
    public Text level;                  // уровень
    public Text speed;                  // скорость
    public Button ButtLevUp;             //
    public Button ButtLevDow;            //
    public Button ButtSpUp;             //
    public Button ButtSpDow;            //

    float GameTime;                    //
    float timerGameBest;                //
    int BonusBest;                      //

    float seconds;
    float minutes;
    float secondsB;
    float minutesB;

    //public Color lerpedColor = Color.white;



    //public GameObject [] StartTile;                // центр
    public Camera Cam3d;                    // Camera
    public GameObject CamEng;               // камера
    public GameObject Fon;                  // фон
    public GameObject TileBlockStart;       // стартовый блок

    GameObject BS2;


    bool right;                            // поворот на право
    float eng;                             // угол

    float ballMov;

    int[] Gnum = new int[5] { 1, 2, 3, 4, 5};   //  Кристаллы


    void Start()
    {
        alpha = 0.01f;
        ballMov = 0;

       

        GameObject BlockStart = Instantiate(TileBlockStart, new Vector3(0, -2.5f, 0), Quaternion.identity) as GameObject;   // создает экземпляр
        BlockStart.name = "BS";                                                                                             // новое имя
        BS2 = GameObject.Find("BS");                                                                                         // поиск/присвоение
        BS2.gameObject.transform.localScale = new Vector3(GlobalParametrs.GLevel, 3, GlobalParametrs.GLevel);                // действие

        ButtLevUp.onClick.AddListener(() => NewTurnLevUp());
        ButtLevDow.onClick.AddListener(() => NewTurnLevDow());
        ButtSpUp.onClick.AddListener(() => NewTurnSpUp());
        ButtSpDow.onClick.AddListener(() => NewTurnSpDow());



        if (GlobalParametrs.GLevel > 1)            // Cristall
        {
            int index = UnityEngine.Random.Range(0, Gnum.Length);
            GlobalParametrs.GNum = Gnum[index];
        }
    }


    void Update()
    {
    //________________________________________________UI____________________________________________________
        time.text = "Cristals Game: " + GlobalParametrs.GBonus.ToString() + "    Time Game:  " + Mathf.Round(minutes).ToString().PadLeft(2, '0') + " : " + Mathf.Round(seconds - 0.5f).ToString().PadLeft(2, '0');
        crist.text = "Cristals Best:   " + BonusBest.ToString() + "    Time Best:     " + Mathf.Round(minutesB).ToString().PadLeft(2, '0') + " : " + Mathf.Round(secondsB - 0.5f).ToString().PadLeft(2, '0');
        level.text = GlobalParametrs.GLevel.ToString();
        speed.text = GlobalParametrs.GSpeed.ToString();

        seconds = (GameTime % 60);
        minutes = Mathf.Round((GameTime - 30) / 60) % 60;
        secondsB = (timerGameBest % 60);
        minutesB = Mathf.Round((timerGameBest - 30) / 60) % 60;

        if (BonusBest < GlobalParametrs.GBonus)
        {
            BonusBest = GlobalParametrs.GBonus;
        }
        if (timerGameBest < GameTime)
        {
            timerGameBest = GameTime;
        }

        var color = _sprite.color;


        color.a = a;
        color.a = Mathf.Clamp(color.a, 0, 1);
        _sprite.color = color;










        if (CnInputManager.GetButtonDown("Jump"))
        {
            if (GlobalParametrs.GMove == 1)
            {
                if (right == false)
                {
                    right = true;
                }
                else if (right == true)
                {
                    right = false;
                }

            }


            if (GlobalParametrs.GMove == 2 && a >= 0.4f)
            {
                GlobalParametrs.GMove = 3;
            }
        }




        if (CnInputManager.GetButtonUp("Jump") && GlobalParametrs.GMove == 0)
        {
            GlobalParametrs.GMove = 1;
        }


        if (GlobalParametrs.GMove == 1)
        {
            GameTime += Time.deltaTime; 
        }


        if (GlobalParametrs.GMove > 0)
        {
            if (right)
            {
                eng = 0.1f * GlobalParametrs.GSpeed;
                this.transform.Translate(Vector3.right * Time.deltaTime * GlobalParametrs.GSpeed * 50);   // движение на право

            }
            else
            {
                eng = -0.1f * GlobalParametrs.GSpeed;
                this.transform.Translate(Vector3.forward * Time.deltaTime * GlobalParametrs.GSpeed * 50);   // движение прямо
            }
        }






        



        if (GlobalParametrs.GMove == 2)                                         // выезд за пределы поля
        {

          

            CamEng.transform.SetParent(GameObject.Find("BOX").transform, true); // помещение в каталог "BOX"
            Fon.transform.SetParent(GameObject.Find("BOX").transform, true);    // помещение в каталог "BOX"

            ballMov -= 0.05f * GlobalParametrs.GSpeed;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + ballMov, this.transform.position.z); 

            if (this.transform.position.y < -300) { 
                PanelBlack.SetActive(true);
                if (a < 0.4)
                {
                    a += alpha;
                }
                else
                {
                    PanelMenu.SetActive(true);
                }
            }
        }


        if (GlobalParametrs.GMove == 3 || GlobalParametrs.GMove == 4)                                         // RESTART
        {
            GlobalParametrs.GTile = 0;                 // Cristall
            if (GlobalParametrs.GLevel > 1)            // Cristall
            {
                int index = UnityEngine.Random.Range(0, Gnum.Length);
                GlobalParametrs.GNum = Gnum[index];
            }
            else
            {
                GlobalParametrs.GNum = 1;
            }
            CamEng.transform.SetParent(GameObject.Find("Ball").transform, true); // помещение в каталог "Ball"
            Fon.transform.SetParent(GameObject.Find("Ball").transform, true);    // помещение в каталог "Ball"
            PanelMenu.SetActive(false);
            if (a < 1)
            {
                Destroy(BS2);
                GlobalParametrs.GMove = 4;
                a += alpha*2;   //  уход в черный
            }
            else
            {
                a = 1;
                GameObject BlockStart = Instantiate(TileBlockStart, new Vector3(0, -2.5f, 0), Quaternion.identity) as GameObject;   // создает экземпляр
                BlockStart.name = "BS";                                                                                             // новое имя
                BS2 = GameObject.Find("BS");                                                                                         // поиск/присвоение
                BS2.gameObject.transform.localScale = new Vector3(GlobalParametrs.GLevel, 3, GlobalParametrs.GLevel);                // действие
                GlobalParametrs.GMove = -1;
            }
        }





        if (GlobalParametrs.GMove == -1)
        {
            eng = 0;
            ballMov = 0;
            right = false;
            this.transform.position = new Vector3(0, 0, 0);
            CamEng.transform.position = new Vector3(20, 80.5f, -125);
            CamEng.transform.rotation = Quaternion.Euler(33, 3, 0);
           Fon.transform.position = new Vector3(186.5f, -109.5f, 635);
            if (a > 0)                                    // прозрачность
            {
                a -= alpha*2;
            }
            else
            {
                GlobalParametrs.GBonus = 0;
                GameTime = 0;
                a = 0;
                PanelBlack.SetActive(false);
                GlobalParametrs.GMove = 0;                // START
            }


        }







        if (CamEng.gameObject.transform.eulerAngles.y >= 26f && right)
        {
            eng = 0;
        }

        if (CamEng.gameObject.transform.eulerAngles.y < 0.5f && !right)
        {
            eng = 0;
        }





        CamEng.transform.rotation = Quaternion.Euler(CamEng.gameObject.transform.eulerAngles.x, CamEng.gameObject.transform.eulerAngles.y + eng, CamEng.gameObject.transform.eulerAngles.z);  // поворот

        if (GlobalParametrs.GLevel == 1)
        {
            Cam3d.fieldOfView = 40;
        }
        if (GlobalParametrs.GLevel == 2)
        {
            Cam3d.fieldOfView = 48;
        }
        if (GlobalParametrs.GLevel == 3)
        {
            Cam3d.fieldOfView = 56;
        }



        /*
                                                              ------------------ НАЖАТИЯ --------------------
        */

        //if (Input.touchCount >= 1) {                     // Вариант 1 -нажатие на дисплее смарфона 



    }



    //________________________________________________________________________________кнопка ""______________________________________________________________________
    void NewTurnLevUp()
    {
        if (GlobalParametrs.GLevel < 3)
        {
            GlobalParametrs.GLevel++;
        }
    }
    //________________________________________________________________________________кнопка ""______________________________________________________________________
    void NewTurnLevDow()
    {
        if (GlobalParametrs.GLevel > 1)
        {
            GlobalParametrs.GLevel--;
        }
    }
    //________________________________________________________________________________кнопка ""______________________________________________________________________
    void NewTurnSpUp()
    {
        if (GlobalParametrs.GSpeed < 3)
        {
            GlobalParametrs.GSpeed++;
        }
    }
    //________________________________________________________________________________кнопка ""______________________________________________________________________
    void NewTurnSpDow()
    {
        if (GlobalParametrs.GSpeed > 1)
        {
            GlobalParametrs.GSpeed--;
        }
    }



    //________________________________________________________________________________ТРИГГЕРЫ______________________________________________________________________
    void OnTriggerExit(Collider col)            // шар за полем

    {
        if (col.gameObject.tag == "Tile")
        {
            GlobalParametrs.GMove = 2;

        }

    }

    void OnTriggerEnter(Collider col)            // шар за полем

    {
        if (col.gameObject.tag == "Tile")
        {
            GlobalParametrs.GMove = 1;

        }

    }

    void OnTriggerStay(Collider col)            // шар за полем

    {
        if (col.gameObject.tag == "Tile")
        {
            GlobalParametrs.GMove = 1;

        }

    }
}
