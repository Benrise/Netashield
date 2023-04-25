using UnityEngine;
using UnityEngine.Audio;

public class Dialog2 : MonoBehaviour
{

    public GameObject dialogeMessage2;
    public GameObject background;

    public AudioMixerGroup masterAudio;
    [SerializeField] private float _currentMasterVolume;
    public GameObject trigger2;
    public float timeScale = 0f;

     void Start(){
        masterAudio.audioMixer.GetFloat("MasterVolume", out _currentMasterVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            masterAudio.audioMixer.SetFloat("MasterVolume", -10f);
            background.SetActive(true);
            dialogeMessage2.SetActive(true);
            Time.timeScale = timeScale;
        }
    }

    public void CloseDialog2(){
        masterAudio.audioMixer.SetFloat("MasterVolume", _currentMasterVolume);
        Destroy(trigger2);
        background.SetActive(false);
        Destroy(dialogeMessage2);
        Time.timeScale = 1f;
    }
    
}
