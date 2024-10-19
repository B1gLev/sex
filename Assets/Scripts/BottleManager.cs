using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System;

public class BottleSelectionManager : MonoBehaviour
{
    [SerializeField] private Image[] bottleImages;        // �vegek k�pei
    [SerializeField] private Sprite[] bottleSprites;      // �j k�pek, amelyekkel cser�lhetj�k az �vegeket
    [SerializeField] private Button[] selectButtons;      // Kiv�laszt� gombok
    [SerializeField] private Button nextSceneButton;      // K�vetkez� scene-re viv� gomb
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private TextMeshProUGUI[] textMeshPros;

    private bool[] isSelected;          // Kiv�lasztott �vegek k�vet�se
    private Sprite[] originalSprites;   // Eredeti k�pek t�rol�sa

    void Start()
    {
        isSelected = new bool[bottleImages.Length];
        originalSprites = new Sprite[bottleImages.Length];

        // Eredeti k�pek elment�se
        for (int i = 0; i < bottleImages.Length; i++)
        {
            originalSprites[i] = bottleImages[i].sprite;
        }

        nextSceneButton.gameObject.SetActive(false);

        // Minden gombhoz hozz�rendelj�k a kiv�laszt�si logik�t
        for (int i = 0; i < selectButtons.Length; i++)
        {
            int index = i;
            selectButtons[i].onClick.AddListener(() => SelectBottle(index));
        }
    }

    // �veg kiv�laszt�sa
    void SelectBottle(int index)
    {
        isSelected[index] = !isSelected[index]; // Toggle kiv�laszt�s
        bottleImages[index].sprite = isSelected[index] ? bottleSprites[index] : originalSprites[index];  // K�p cser�je
        Bottle bottle = gameObjects[index].GetComponent<Bottle>();
        if (isSelected[index])
        {
            textMeshPros[index].text = $"{bottle.Name} ({bottle.Volume}cm3) {bottle.RefundValue}Ft/db";
        } else
        {
            textMeshPros[index].text = "";
        }
        // Ellen�rizni, hogy van-e m�r kiv�lasztott �veg
        CheckForSelection();
    }

    // Ellen�rzi, hogy van-e m�r kiv�lasztott �veg
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

    // K�vetkez� scene bet�lt�se
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

        SceneManager.LoadScene("DoneScene"); // V�lts a sz�m�t�si jelenetre
    }
}
