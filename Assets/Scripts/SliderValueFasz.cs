using UnityEngine;
using TMPro; // TextMeshPro namespace
using UnityEngine.UI; // UI namespace

public class SliderValueDisplayManager : MonoBehaviour
{
    public Slider volumeSlider; // Referencia a Sliderre
    public TMP_Text valueText;  // Referencia a TextMeshPro szövegre

    void Start()
    {
        // Kezdeti érték megjelenítése
        UpdateValueText(volumeSlider.value);

        // Slider értékének változásának figyelése
        volumeSlider.onValueChanged.AddListener(UpdateValueText);
    }

    // A szöveg frissítése a Slider értékével
    void UpdateValueText(float value)
    {
        valueText.text = $"{value}"; 
    }
}
