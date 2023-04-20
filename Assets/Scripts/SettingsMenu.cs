using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixerGroup mixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TextMeshProUGUI MusicVolumeValue;
    public TextMeshProUGUI SfxVolumeValue;

    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;

    [SerializeField] private bool isMuted = false;


    void Start()
    {
        LoadSettings();

        musicSlider.onValueChanged.AddListener(UpdateMusicVolumeText);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);

        sfxSlider.onValueChanged.AddListener(UpdateSfxVolumeText);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 1);

    }

    public void UpdateMusicVolumeText(float value)
    {
        MusicVolumeValue.text = Mathf.RoundToInt(value * 100f).ToString() + "%";
    }
    public void UpdateSfxVolumeText(float value)
    {
        SfxVolumeValue.text = Mathf.RoundToInt(value * 100f).ToString() + "%";
    }


    public void SetFullscreen(bool isFullscreen){

        Screen.fullScreen = isFullscreen;
    }

    public void SaveSettings(){
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings(){
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
    }

    public void ResetMute()
    {
        isMuted = false;
        button.image.sprite = soundOnImage;
        mixer.audioMixer.SetFloat("MasterVolume", 0);
        PlayerPrefs.SetInt("SoundEnabled", isMuted ? 1 : 0);
    }

    public void ToggleSound()
    {
        if (isMuted)
        {
            button.image.sprite = soundOnImage;
            mixer.audioMixer.SetFloat("MasterVolume", 0);
        }
        else
        {
            mixer.audioMixer.SetFloat("MasterVolume", -80);
            button.image.sprite = soundOffImage;
        }
        isMuted = !isMuted;

        PlayerPrefs.SetInt("SoundEnabled", isMuted ? 1 : 0);
    }

    public void ChangeMusicVolume(float volume)
    {
        mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void ChangeSfxVolume(float volume)
    {
        mixer.audioMixer.SetFloat("SfxVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }


}
