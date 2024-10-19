using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public Slider maxValueSlider;
    public TMP_Text sliderValueText;
    private void Start()
    {
        maxValueSlider.onValueChanged.AddListener(UpdateSliderText);
        UpdateSliderText(maxValueSlider.value);
    }
    public void SwitchToSecondScene()
    {
        GameManager.Instance.initialSliderValue = maxValueSlider.value;
        SceneManager.LoadScene("mainSelection");
    }
    private void UpdateSliderText(float value)
    {
        sliderValueText.text = $"{maxValueSlider.value}";
    }
}









