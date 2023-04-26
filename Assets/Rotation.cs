using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Добавляем возможные состояния трубы
    enum PipeState
    {
        Up,
        Right,
        Down,
        Left
    }

    // Текущее состояние трубы
    PipeState currentState = PipeState.Up;

    // Обработчик нажатия на трубу
    void OnMouseDown()
    {
        // Поворачиваем трубу на 90 градусов
        transform.Rotate(0, 0, 90);

        // Обновляем текущее состояние трубы
        switch (currentState)
        {
            case PipeState.Up:
                currentState = PipeState.Right;
                break;
            case PipeState.Right:
                currentState = PipeState.Down;
                break;
            case PipeState.Down:
                currentState = PipeState.Left;
                break;
            case PipeState.Left:
                currentState = PipeState.Up;
                break;
        }
        // Выводим текущее состояние трубы в консоль
        Debug.Log($"Current state of {gameObject.name}: {currentState}");

    }

}