using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TowerUpgradeUI : MonoBehaviour
{
    public Tower tower;
    public Button upgradeButton;
    public Button sellButton;
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI valueTxt;
    public TextMeshProUGUI dmgTxt;
    public TextMeshProUGUI rangeTxt;
    public TextMeshProUGUI towernameTxt;

    private bool justOpened = true;

    void Awake()
    {
        upgradeButton.onClick.AddListener(TryUpgrade);
        sellButton.onClick.AddListener(TrySell);
    }

    private void TryUpgrade()
    {
        if (CashManager.instance.coins < tower.upgradeStages[tower.upgradeStage].price) return;

        tower.Upgrade();

        Destroy(gameObject);
    }

    private void TrySell()
    {
        tower.Sell();

        Destroy(gameObject);
    }

    void Update()
    {
        if (justOpened)
        {
            justOpened = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;
            
            Destroy(gameObject);
            
            
        }
        /*if(tower.upgradeStage >= tower.upgradeStages.Length)
        {
            Destroy(gameObject);
        }*/
    }
}
