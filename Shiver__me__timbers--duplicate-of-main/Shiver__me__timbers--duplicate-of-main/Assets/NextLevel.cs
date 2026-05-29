using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    // Make sure to set this number in the Inspector (0, 1, 2, etc.)
    public int sceneBuildIndex;
    // This script should be attached to a trigger collider that represents the level exit. When the player character (Quill) enters this trigger, the specified scene will be loaded, effectively moving the player to the next level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has the tag "Player" OR "Quill"
        if (collision.CompareTag("PPlayer") || collision.CompareTag("Quill"))
        {
            // Log a message to the console for debugging purposes, indicating that the level is complete and which scene index is being loaded
            Debug.Log("Level Complete! Loading scene index: " + sceneBuildIndex);
            
            // This line alone handles the scene change
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
