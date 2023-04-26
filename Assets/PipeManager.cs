using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeManager : MonoBehaviour
{
    //public GameObject[] pipes; // массив объектов выигрышных труб
    public GameObject[] pipe_off; // массив объектов труб

    public GameObject finalWindow;

    void Update(){
            if (PlayerPrefs.HasKey("gameComplete")){
                finalWindow.SetActive(true);

            }
        }

    public void Reset(){
        PlayerPrefs.DeleteKey("gameComplete");
    }
    void Start()
    {


       /*pipes = GameObject.FindGameObjectsWithTag("Pipe"); // находим все выигрышные трубы на сцене

        foreach (GameObject pipe in pipes)
        {
            // добавляем скрипт на каждую трубу на сцене
            pipe.AddComponent<PipeRotation>();
        }*/

        pipe_off = GameObject.FindGameObjectsWithTag("Pipe_off"); // находим все трубы на сцене

        foreach (GameObject pipe in pipe_off)
        {
            // добавляем скрипт на каждую трубу на сцене
            pipe.AddComponent<Rotation>();
        }
    }
}
