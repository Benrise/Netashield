using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public Button newGameButton;
    void Awake(){

        if (PlayerPrefs.GetInt("isTutorialCompleted") == 1)
        {
            continueButton.interactable = true; // кнопка продолжения активна

        }
        else
        {
            continueButton.interactable = false; // кнопка продолжения неактивна
        }
    }

    public void NewGame()
    {
            PlayerPrefs.SetInt("isTutorialCompleted", 0);
    }

}
