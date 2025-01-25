using UnityEngine;
using TMPro;

public class CreditsScroller : MonoBehaviour
{
    public string creditsText = "Game Development Team:\n\n"
                              + "Programming: Hakashi, Ripozy & Qad\n"
                              + "Art: Hakashi Katake, Ripozy & Tesstrie\n"
                              + "Music: Henery\n\n"
                              + "Special Thanks:\n\n"
                              + "Thank you for playing!";

    public TextMeshProUGUI uiText; // Assign your Text component
    public float scrollSpeed = 50f; // Speed of scrolling
    public float startDelay = 2f;  // Delay before starting the scroll
    public float endPosition = 1000f; // Position at which scrolling stops

    public GameObject buttonsContainer; // Parent GameObject holding the buttons

    private RectTransform rectTransform;

    void Start()
    {
        // Ensure the Text component is assigned
        if (uiText == null)
        {
            Debug.LogError("No Text component assigned! Please assign a UI Text.");
            enabled = false;
            return;
        }

        // Ensure the Buttons container is assigned
        if (buttonsContainer == null)
        {
            Debug.LogError("No Buttons container assigned! Please assign it.");
            enabled = false;
            return;
        }

        // Hide the buttons at the start
        buttonsContainer.SetActive(false);

        // Set the credits text
        uiText.text = creditsText;

        // Get the RectTransform of the Text
        rectTransform = uiText.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("CreditsScroller requires a RectTransform component on the Text!");
            enabled = false;
            return;
        }

        // Start scrolling after a delay
        Invoke(nameof(StartScrolling), startDelay);
    }

    void StartScrolling()
    {
        // Begin the scrolling movement
        StartCoroutine(ScrollCredits());
    }

    System.Collections.IEnumerator ScrollCredits()
    {
        while (rectTransform.anchoredPosition.y < endPosition)
        {
            // Move the RectTransform upward
            rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            yield return null;
        }

        Debug.Log("Credits finished scrolling.");

        // Show the buttons when scrolling ends
        ShowButtons();
    }

    void ShowButtons()
    {
        buttonsContainer.SetActive(true);
    }
}


