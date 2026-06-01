using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    [SerializeField] private GameObject quillPrefab;
    public Animator animator;
    public int sceneBuildIndex;
    public string playerTag = "PPlayer";

    [Header("Delay Settings")]
    [SerializeField] private float sceneLoadDelay = 2.0f;

    private void Start()
    {
        /*  if (quillPrefab != null)
          {
              Instantiate(quillPrefab, transform.position, Quaternion.identity);
          }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(playerTag)) return;

        SoundEffectManager.PlaySoundEffect("PlayerVictory");

        StartCoroutine(DelaySceneLoadRoutine());
    }


    private IEnumerator DelaySceneLoadRoutine()
    {
        Debug.Log("STEP 2: Coroutine successfully started.");

        if (TryGetComponent<Collider2D>(out Collider2D myCollider))
        {
            myCollider.enabled = false;
        }

        // Using Realtime to bypass potential Time.timeScale issues
        yield return new WaitForSecondsRealtime(sceneLoadDelay);

        Debug.Log("STEP 3: Delay finished. Calling TriggerSceneLoad...");
        TriggerSceneLoad();
    }

    private void TriggerSceneLoad()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        Debug.Log($"Current Scene: {currentScene}");
        Debug.Log($"Next Scene: {nextScene}");

        // Check if next scene exists in Build Settings
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Last level reached! Returning to menu.");
            SaveManager.SaveLevel(1); // optional reset point
            SceneManager.LoadScene(0);
            return;
        }

        SaveManager.SaveLevel(nextScene);
        SceneManager.LoadScene(nextScene);
    }
}
