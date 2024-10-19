using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class CalculationManager : MonoBehaviour
{
    public TMP_Text resultText;         // Szöveg a számítási eredményekhez
    public Button backButton;       // Vissza gomb
    public int desiredMoney;      // A kívánt pénzösszeg
    public int maxVolume;
    private Dictionary<string, (int volume, int value)> bottles;

    void Start()
    {
        // Adatok betöltése PlayerPrefs-ből
        desiredMoney = PlayerPrefs.GetInt("DesiredMoney");
        maxVolume = PlayerPrefs.GetInt("BagVolume");
        bottles = new Dictionary<string, (int volume, int value)>();

        // Kiválasztott üvegek térfogatainak betöltése
        int bottleCount = PlayerPrefs.GetInt("Bottles");
        for (int i = 0; i < bottleCount; i++)
        {
            var data = PlayerPrefs.GetString(i.ToString()).Split(";");
            bottles.Add(data[0], (int.Parse(data[1]), int.Parse(data[2])));
        }

        // Számítás elvégzéss
        CalculateBottlesNeeded();
        // Gomb esemény hozzáadása
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    void CalculateBottlesNeeded()
    {
        var sortedBottles = bottles.OrderByDescending(b => (double)b.Value.value / b.Value.volume).ToList();
        int totalBottlesNeeded = 0;
        var money = 0;

        while (money <= desiredMoney)
        {
            if (money >= desiredMoney) break;
            totalBottlesNeeded++;
            sortedBottles.Where(x => x.Value.volume <= maxVolume).ToList().ForEach(x =>
            {
                if (money >= desiredMoney) return;
                money += x.Value.value;
            });
        }

        // Kiírás a szövegbe
        resultText.text = $"A kívánt összeg eléréséhez {totalBottlesNeeded} palack szükséges.\n";








    }

    void OnBackButtonClicked()
    {
        SceneManager.LoadScene("GameScene"); // Visszatér a korábbi jelenethez
    }
}