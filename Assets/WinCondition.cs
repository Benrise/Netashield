using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinCondition : MonoBehaviour
{
    public GameObject[] pipes; // массив всех элементов труб на сцене
    private Quaternion[] pipeRotations; // массив их исходных углов поворота

    private void Start()
    {
        // заполняем массив исходных углов поворота вручную
        pipeRotations = new Quaternion[] {
            Quaternion.Euler(0f, 0f, 180f),
            Quaternion.Euler(0f, 0f, 0f),
            Quaternion.Euler(0f, 0f, 0f),
            Quaternion.Euler(0f, 0f, 90f),
            Quaternion.Euler(0f, 0f, 180f),
            Quaternion.Euler(0f, 0f, 0f),
            Quaternion.Euler(0f, 0f, 0f),
            Quaternion.Euler(0f, 0f, 90f),
            Quaternion.Euler(0f, 0f, 90f)
        };
    }

    private void Update()
    {
        bool allPipesMatch = true;

        // проверяем соответствие текущих углов поворота исходным
        for (int i = 0; i < pipes.Length; i++)
        {
            if (pipes[i].transform.rotation != pipeRotations[i])
            {
                allPipesMatch = false;
                break;
            }
        }

        // если все элементы труб находятся в правильном положении, выводим сообщение о выигрыше
        if (allPipesMatch)
        {
            Debug.Log("Вы победили!");
            return;
        }
    }
}

