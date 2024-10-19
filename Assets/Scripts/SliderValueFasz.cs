using UnityEngine;
using TMPro; // TextMeshPro namespace
using UnityEngine.UI; // UI namespace

public class SliderValueDisplayManager : MonoBehaviour
{
    public Slider volumeSlider; // Referencia a Sliderre
    public TMP_Text valueText;  // Referencia a TextMeshPro sz�vegre

    void Start()
    {
        // Kezdeti �rt�k megjelen�t�se
        UpdateValueText(volumeSlider.value);

        // Slider �rt�k�nek v�ltoz�s�nak figyel�se
        volumeSlider.onValueChanged.AddListener(UpdateValueText);
    }

    // A sz�veg friss�t�se a Slider �rt�k�vel
    void UpdateValueText(float value)
    {
        valueText.text = $"{value}"; 
    }
}
