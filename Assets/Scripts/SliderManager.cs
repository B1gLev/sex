using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderManager : MonoBehaviour
{
    public Slider volumeSlider;  // T�ska t�rfogat�nak be�ll�t�sa
    public Slider moneySlider;   // Sz�ks�ges p�nz be�ll�t�sa
    public Button nextButton;    // K�vetkez� gomb

    void Start()
    {
        nextButton.gameObject.SetActive(false);

        // Slider �rt�kek v�ltoz�s�nak figyel�se
        volumeSlider.onValueChanged.AddListener(delegate { UpdateButtonVisibility(); });
        moneySlider.onValueChanged.AddListener(delegate { UpdateButtonVisibility(); });
    }

    // Friss�ti a gomb l�that�s�g�t
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

    // Ha a gombot megnyomj�k, bet�ltj�k a k�vetkez� jelenetet
    public void OnNextButtonClicked()
    {
        // K�vetkez� jelenet bet�lt�se (pl. "GameScene" n�ven)
        PlayerPrefs.SetInt("BagVolume", (int)volumeSlider.value); // T�ska t�rfogata ment�se
        PlayerPrefs.SetInt("DesiredMoney", (int)moneySlider.value); // K�v�nt p�nz�sszeg ment�se
        Debug.Log("T�ska t�rfogata: " + (int)volumeSlider.value);
        Debug.Log("K�v�nt p�nz�sszeg: " + (int)moneySlider.value);
        SceneManager.LoadScene("GameScene");
    }
}
