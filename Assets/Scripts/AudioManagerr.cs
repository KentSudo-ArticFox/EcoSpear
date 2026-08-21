using UnityEngine;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    public Slider sliderVolume;
    public AudioSource musica;

    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            float volume = PlayerPrefs.GetFloat("Volume");
            sliderVolume.value = volume;
            musica.volume = volume;
        }
        else
        {
            sliderVolume.value = 1f;
            musica.volume = 1f;
        }

        sliderVolume.onValueChanged.AddListener(MudarVolume);
    }

    public void MudarVolume(float volume)
    {
        musica.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}