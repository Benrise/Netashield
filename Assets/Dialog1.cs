using UnityEngine;
using UnityEngine.Audio;

public class Dialog1 : MonoBehaviour
{

    public GameObject dialogeMessage1;
    public GameObject background;

    public AudioMixerGroup masterAudio;

    public float _currentMasterVolume;

    public GameObject trigger1;
    public float timeScale = 0f;

    void Start(){
        masterAudio.audioMixer.GetFloat("MasterVolume", out _currentMasterVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Показываем диалоговое окно и замедляем время
            masterAudio.audioMixer.SetFloat("MasterVolume", -10f);
            
            background.SetActive(true);
            dialogeMessage1.SetActive(true);
            Time.timeScale = timeScale;
        }
    }

   public void CloseDialog1(){
        masterAudio.audioMixer.SetFloat("MasterVolume", _currentMasterVolume);
        Destroy(trigger1);
        background.SetActive(false);
        Destroy(dialogeMessage1);
        Time.timeScale = 1f;
    }
    
}
