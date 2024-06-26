using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Collections;




public class Upgrade : MonoBehaviour
{
    private Button teleportButton;
    
    public Text counterText; // TMP Text element to display the counter
    public Text upgradeText; // TMP Text element to display the upgrade cost
    public Button upgradeButton1; // Button to purchase upgrades


    private int clickCount = 0; // Counter variable
    private int clickIncrement = 1; // Initial click increment
    private int upgradeCost = 10; // Initial upgrade cost
    private int totalClicks = 0; // Variable to track total clicks for upgrade purposes
    // Start is called before the first frame update
    void Start()
    {
        teleportButton = GetComponentInChildren<Button>();
        upgradeButton1.onClick.AddListener(PurchaseUpgrade1);
        

        // Update the UI texts
        UpdateCounterText();
        UpdateUpgradeText();

        teleportButton.onClick.AddListener(OnTeleportButtonClick);
        void OnTeleportButtonClick()
        {
            IncrementCounter();

        }

        void IncrementCounter()
        {
            clickCount += clickIncrement;
            totalClicks += clickIncrement; // Track total clicks for upgrade purposes
            UpdateCounterText();
        }

        void PurchaseUpgrade1()
        {
            if (totalClicks >= upgradeCost)
            {
                // Double the click increment without deducting from the click count
                clickIncrement *= 2;
                upgradeCost *= 2; // Increase the cost exponentially for the next upgrade

                UpdateUpgradeText();
            }
        }


        void UpdateCounterText()
        {
            counterText.text = "" + clickCount;
        }

        void UpdateUpgradeText()
        {
            upgradeText.text = "" + upgradeCost;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
