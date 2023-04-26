using UnityEngine;

public class PipeRotation : MonoBehaviour
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

    // Исходный спрайт
    public Sprite ishodPipeSprite;

    // Спрайт для замены текущего спрайта, если состояние трубы Right 
    public Sprite rightPipeSprite;


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

        // Проверяем, если текущее состояние трубы равно "Right", то меняем спрайт
        if (currentState == PipeState.Right || (currentState == PipeState.Left && gameObject.tag == "Pipe_prim"))
        {
            GetComponent<SpriteRenderer>().sprite = rightPipeSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = ishodPipeSprite;
        }

        // Вызываем метод проверки состояний труб на поле
        CheckPipeStates();
    }

    // Метод проверки состояний труб на поле
    void CheckPipeStates()
    {
        // Получаем все трубы на сцене
        PipeRotation[] pipes = FindObjectsOfType<PipeRotation>();

        // Проверяем состояния каждой трубы
        foreach (PipeRotation pipe in pipes)
        {
            // Если состояние трубы не совпадает с выигрышным набором состояний, то выходим из метода
            if (pipe.currentState != PipeState.Right && pipe.currentState != PipeState.Left )
            {
                return;
            }
        }

        // Если все трубы имеют правильное состояние, то выводим сообщение о победе
        Debug.Log("You win!");
        PlayerPrefs.SetInt("gameComplete", 1);
        
    }
}
