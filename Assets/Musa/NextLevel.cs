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

        if (collision.CompareTag(playerTag))
        {
            SoundEffectManager.PlaySoundEffect("PlayerVictory");
            Debug.Log("STEP 1: Sound played. Starting Coroutine...");

            StartCoroutine(DelaySceneLoadRoutine());
        }
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
        Debug.Log($"STEP 4: Attempting to load scene index: {sceneBuildIndex}");

        // Wrapped in try/catch to reveal if PlayerSaver is crashing the script
        try
        {
            PlayerSaver.SaveLevel(sceneBuildIndex);
            Debug.Log("STEP 5: PlayerSaver executed successfully.");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"CRASH in PlayerSaver: {e.Message}");
        }

        SceneManager.LoadScene(sceneBuildIndex);
    }
}
