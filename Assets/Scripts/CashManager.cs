using UnityEngine;
using TMPro;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;

    public int coins;
    public TextMeshProUGUI coinTxt;

    private void Awake()
    {
        instance = this;
        UpdateCoins(0);
    }

    public void UpdateCoins(int changeAmount)
    {
        coins += changeAmount;

        coinTxt.text = coins.ToString();
    }
}
