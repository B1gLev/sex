using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderManager : MonoBehaviour
{
    public Slider volumeSlider;  // Táska térfogatának beállítása
    public Slider moneySlider;   // Szükséges pénz beállítása
    public Button nextButton;    // Következõ gomb

    void Start()
    {
        nextButton.gameObject.SetActive(false);

        // Slider értékek változásának figyelése
        volumeSlider.onValueChanged.AddListener(delegate { UpdateButtonVisibility(); });
        moneySlider.onValueChanged.AddListener(delegate { UpdateButtonVisibility(); });
    }

    // Frissíti a gomb láthatóságát
    void UpdateButtonVisibility()
    {
        if (volumeSlider.value > 0 && moneySlider.value > 0)
        {
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            nextButton.gameObject.SetActive(false);
        }
    }

    // Ha a gombot megnyomják, betöltjük a következõ jelenetet
    public void OnNextButtonClicked()
    {
        // Következõ jelenet betöltése (pl. "GameScene" néven)
        PlayerPrefs.SetInt("BagVolume", (int)volumeSlider.value); // Táska térfogata mentése
        PlayerPrefs.SetInt("DesiredMoney", (int)moneySlider.value); // Kívánt pénzösszeg mentése
        Debug.Log("Táska térfogata: " + (int)volumeSlider.value);
        Debug.Log("Kívánt pénzösszeg: " + (int)moneySlider.value);
        SceneManager.LoadScene("GameScene");
    }
}
