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

    public Toggle isFullScreenToggle;
    public Toggle isMobileControlToggle;

    [SerializeField] private bool isMuted = false;
    [SerializeField] private bool isMobileControl = false;

     [SerializeField] private bool isFullScreen = true;


     public void SetFullscreen(){
        isFullScreen = !isFullScreen;
        PlayerPrefs.SetInt("isJoyStick", isFullScreen ? 1 : 0);
        Screen.fullScreen = isFullScreen;
        Debug.Log(isFullScreen);
        Debug.Log(isFullScreenToggle);
    }


    public void SetMobileControl(){
        isMobileControl = !isMobileControl;
        PlayerPrefs.SetInt("isJoyStick", isMobileControl ? 1 : 0);
        Debug.Log(isMobileControlToggle.isOn);
    }
    void Awake()
    {
        LoadSettings();

        musicSlider.onValueChanged.AddListener(UpdateMusicVolumeText);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);

        sfxSlider.onValueChanged.AddListener(UpdateSfxVolumeText);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 1);

    }

    private void Update(){
    }

    public void UpdateMusicVolumeText(float value)
    {
        MusicVolumeValue.text = Mathf.RoundToInt(value * 100f).ToString() + "%";
    }
    public void UpdateSfxVolumeText(float value)
    {
        SfxVolumeValue.text = Mathf.RoundToInt(value * 100f).ToString() + "%";
    }


   

    public void LoadSettings(){
        if (PlayerPrefs.HasKey("FullscreenPreference")){
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
            isFullScreenToggle.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        }
        else
            Screen.fullScreen = true;

        if (PlayerPrefs.HasKey("isJoyStick"))
            isMobileControlToggle.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("isJoyStick"));

        
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
        mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-45, 0, volume*1.2f));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void ChangeSfxVolume(float volume)
    {
        mixer.audioMixer.SetFloat("SfxVolume", Mathf.Lerp(-45, 0, volume*1.2f));
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }


}
