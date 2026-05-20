using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    // Make sure to set this number in the Inspector (0, 1, 2, etc.)
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has the tag "Player" OR "Quill"
        if (collision.CompareTag("PPlayer") || collision.CompareTag("Quill"))
        {
            Debug.Log("Level Complete! Loading scene index: " + sceneBuildIndex);
            
            // This line alone handles the scene change
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
