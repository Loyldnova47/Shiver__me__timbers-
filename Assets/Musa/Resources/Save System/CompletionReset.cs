using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionReset : MonoBehaviour
{
    [SerializeField] private float delayBeforeReset = 3f; 

    private void Start()
    {
        StartCoroutine(ResetRoutine());
    }

    private System.Collections.IEnumerator ResetRoutine()
    {
        yield return new WaitForSeconds(delayBeforeReset);

        Debug.Log("Game completed. Resetting save data...");

        SaveManager.DeleteSave();

        SceneManager.LoadScene(0); // Main Menu
         
    }
}
