using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecondSceneManager : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public TMP_Text s1Value;
    public TMP_Text s2Value;
    public TMP_Text maxTextValue;

    private bool isUpdating = false;

    private void Start()
    {
        float maxValueFromFirstScene = GameManager.Instance.initialSliderValue;

        slider1.minValue = 0;
        slider1.maxValue = maxValueFromFirstScene;
        slider1.value = 0;

        slider2.minValue = 0;
        slider2.maxValue = maxValueFromFirstScene;
        slider2.value = 0;

        slider1.onValueChanged.AddListener(UpdateSliders);
        slider2.onValueChanged.AddListener(UpdateSliders);

        UpdateSliders(slider1.value);
    }

    private void UpdateSliders(float value)
    {
        if (isUpdating) return;

        isUpdating = true;

        slider2.maxValue = GameManager.Instance.initialSliderValue - slider1.value;
        slider1.maxValue = GameManager.Instance.initialSliderValue - slider2.value;

        slider1.maxValue = Mathf.Max(slider1.maxValue, 0);
        slider2.maxValue = Mathf.Max(slider2.maxValue, 0);

        // Update TMP text values
        UpdateSliderText();

        isUpdating = false;
    }

    private void UpdateSliderText()
    {
        s1Value.text = $"Slider 1: {slider1.value}";
        s2Value.text = $"Slider 2: {slider2.value}";
    }
}
