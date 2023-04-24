using UnityEngine;

public class SFX : MonoBehaviour
{

    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void HoverSound(){
        myFx.PlayOneShot(hoverFx);
    }

    public void ClickSound(){
        myFx.PlayOneShot(hoverFx);
    }
    
}
