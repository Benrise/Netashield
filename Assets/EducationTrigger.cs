using UnityEngine;

public class EducationTrigger : MonoBehaviour
{
    public GameObject tutorialUI;
    public GameObject gameUI;

    void Start(){
        // gameUI.GetComponent<Animator>().Play("CanvasAppearance");

    }
    public void HideTutorial()
    {
        // Код, который должен выполниться при нажатии на кнопку "Завершить обучение"
        // Отключаем UI обучения
        tutorialUI.SetActive(false);

        // Включаем UI игры
        gameUI.SetActive(true);
    }
}
