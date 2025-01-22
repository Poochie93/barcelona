using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con la UI de Unity

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;  // Referencia al Slider que controlará el volumen

    void Start()
    {
        // Asegúrate de que el Slider tenga el valor actual del volumen
        volumeSlider.value = AudioListener.volume;

        // Escucha cambios en el valor del Slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // Este método se llama cuando el valor del Slider cambia
    void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;  // Modifica el volumen global del AudioListener
    }

    // Si deseas guardar el volumen en PlayerPrefs para persistir entre escenas:
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        PlayerPrefs.Save();
    }

    // Si deseas cargar el volumen guardado:
    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = savedVolume;
            volumeSlider.value = savedVolume;  // También actualiza el Slider
        }
    }
}