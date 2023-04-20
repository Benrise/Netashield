
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    
    [SerializeField] private bool isMuted = false;

    public void ToggleSound()
    {
        isMuted = !isMuted;
        if (isMuted){
            Debug.Log("True");
            button.image.sprite = soundOnImage;
        }

        else
        {
            Debug.Log("False");
            button.image.sprite = soundOffImage;
        }
    }


}
