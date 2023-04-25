using UnityEngine;
using UnityEngine.UI;

public class ShowGUIAnimation : MonoBehaviour
{
    public Animator showUIanimation;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(ShowAnimation);
    }

    void ShowAnimation()
    {
        showUIanimation.Play("showCanvas");
    }
}

