using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PasscodeUI : MonoBehaviour
{
    public InputField codeInputField;
    public Text feedbackText;
    public GameObject panel;
    public movement playerController; // Reference to the player's movement script

    private PaascodeExit currentExit; // Reference to the current exit being interacted with

    public void Open(PaascodeExit exit)
    {
        currentExit = exit;
        panel.SetActive(true);
        codeInputField.text = "";
        feedbackText.text = "";
        Time.timeScale = 0f; // Pause the game
        playerController.enabled = false; // Disable player movement
    }

    public void Onsubmit()
    {
        if (currentExit.Validate(codeInputField.text))
    {
        feedbackText.text = "You're Good to Go!";
        StartCoroutine(LoadNextScene()); // Close the UI after a short delay
    }
    else
    {
        feedbackText.text = "Dang! Wrong Code! Try Again!";
        StartCoroutine(ShakePanel(0.5f, 0.1f)); // Shake the panel to indicate an error
    }
}

    public void OnCancel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        playerController.enabled = true; // Enable player movement
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(1f); // Wait for 1 second in real time
        panel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        playerController.enabled = true; // Enable player movement
    }

    IEnumerator ShakePanel(float duration, float magnitude)
    {
        Vector3 originalPos = panel.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            panel.transform.localPosition = originalPos + new Vector3(x, y, 0);
            elapsed += Time.unscaledDeltaTime; // Use unscaled time to ignore time scale
            yield return null;
        }

        panel.transform.localPosition = originalPos; // Reset to original position
    }

}
