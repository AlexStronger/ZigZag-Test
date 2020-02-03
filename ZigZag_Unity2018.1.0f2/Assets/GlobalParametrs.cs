using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParametrs : MonoBehaviour {  // ГЛОБАЛЬНЫЕ ПЕРЕМЕННЫЕ

	
    public static byte GLevel;                  // уровень сложности 3уровня 1-сложный
    public static int GMove;                 // шар: 0-на старте, 1-старт, 2-за полем, 3-заново, -1-переход
    public static byte GSpeed;                 // скорость
    public static float GTime;                  // время в игре
    public static int GBonus;                   // количество собр кристалов
    public static byte GTile;                   // Тайлы
    public static int GNum;                    // № тайла с кристалом
    public static int GLenght;                  // количество блоков в сцене
    public static float GEng;                   // поворот камеры




    void Awake() {
       GLevel = 3;   // стартовый уровень
       GTile = 0;
       GSpeed = 1;
       GEng = 0;
       GNum = 1;
       

    }
	
	
	void Update () {




        if (Input.GetKey(KeyCode.Escape))                  // выход нажатием "назад" на смартфоне
        {
            Application.Quit();
        }
    }
}
