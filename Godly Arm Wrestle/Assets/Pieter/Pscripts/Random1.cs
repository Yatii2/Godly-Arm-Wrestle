using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class Random1 : MonoBehaviour
{
    public float teleportRadius = 5f;
    public float teleportDelay = 1f;
    [SerializeField] GameObject Button;
    private Button teleportButton;
    [SerializeField] GameObject WinImage;
    [SerializeField] GameObject LoseImage;

    void Start()
    {
        // Find the button component in the hierarchy
        teleportButton = GetComponentInChildren<Button>();

        // Start the coroutine for auto teleport
        StartCoroutine(AutoTeleport());
    }

    void TeleportButton()
    {
        if (!WinImage.activeSelf)
        {
            // Calculate a random position within the teleport radius
            Vector3 randomPosition = GetRandomPosition();

            // Teleport the button to the random position
            RectTransform buttonRectTransform = teleportButton.GetComponent<RectTransform>();
            buttonRectTransform.anchoredPosition = randomPosition;
        } 
        

    }

    

Vector3 GetRandomPosition()
    {
        // Calculate a random position within the teleport radius
        float randomX = Random.Range(-teleportRadius, teleportRadius);
        float randomY = Random.Range(-teleportRadius, teleportRadius);
        Vector3 randomOffset = new Vector3(randomX, randomY, 0f);

        return randomOffset;
    }

    IEnumerator AutoTeleport()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportDelay);

            // Teleport the button automatically
            TeleportButton();
        }
    }

   
}
