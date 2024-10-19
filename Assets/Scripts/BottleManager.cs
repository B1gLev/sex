using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System;

public class BottleSelectionManager : MonoBehaviour
{
    [SerializeField] private Image[] bottleImages;        // Üvegek képei
    [SerializeField] private Sprite[] bottleSprites;      // Új képek, amelyekkel cserélhetjük az üvegeket
    [SerializeField] private Button[] selectButtons;      // Kiválasztó gombok
    [SerializeField] private Button nextSceneButton;      // Következõ scene-re vivõ gomb
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private TextMeshProUGUI[] textMeshPros;

    private bool[] isSelected;          // Kiválasztott üvegek követése
    private Sprite[] originalSprites;   // Eredeti képek tárolása

    void Start()
    {
        isSelected = new bool[bottleImages.Length];
        originalSprites = new Sprite[bottleImages.Length];

        // Eredeti képek elmentése
        for (int i = 0; i < bottleImages.Length; i++)
        {
            originalSprites[i] = bottleImages[i].sprite;
        }

        nextSceneButton.gameObject.SetActive(false);

        // Minden gombhoz hozzárendeljük a kiválasztási logikát
        for (int i = 0; i < selectButtons.Length; i++)
        {
            int index = i;
            selectButtons[i].onClick.AddListener(() => SelectBottle(index));
        }
    }

    // Üveg kiválasztása
    void SelectBottle(int index)
    {
        isSelected[index] = !isSelected[index]; // Toggle kiválasztás
        bottleImages[index].sprite = isSelected[index] ? bottleSprites[index] : originalSprites[index];  // Kép cseréje
        Bottle bottle = gameObjects[index].GetComponent<Bottle>();
        if (isSelected[index])
        {
            textMeshPros[index].text = $"{bottle.Name} ({bottle.Volume}cm3) {bottle.RefundValue}Ft/db";
        } else
        {
            textMeshPros[index].text = "";
        }
        // Ellenõrizni, hogy van-e már kiválasztott üveg
        CheckForSelection();
    }

    // Ellenõrzi, hogy van-e már kiválasztott üveg
    void CheckForSelection()
    {
        foreach (bool selected in isSelected)
        {
            if (selected)
            {
                nextSceneButton.gameObject.SetActive(true);
                return;
            }
        }
        nextSceneButton.gameObject.SetActive(false);
    }

    // Következõ scene betöltése
    public void OnNextSceneButtonClicked()
    {
        var counter = 0;
        for (int i = 0; i < isSelected.Length; i++)
        {
            Bottle bottle = gameObjects[i].GetComponent<Bottle>();
            if (isSelected[i])
            {
                PlayerPrefs.SetString($"{i}", $"{bottle.Name};{bottle.Volume};{bottle.RefundValue}");
                counter++;
            }
        }
        PlayerPrefs.SetInt("Bottles", counter);

        SceneManager.LoadScene("DoneScene"); // Válts a számítási jelenetre
    }
}
