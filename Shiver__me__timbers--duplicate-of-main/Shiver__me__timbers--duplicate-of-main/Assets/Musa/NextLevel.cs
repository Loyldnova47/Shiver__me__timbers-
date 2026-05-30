using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    [SerializeField] private GameObject quillPrefab;
    public Animator animator;
    public int sceneBuildIndex;
    public string playerTag = "PPlayer";

    private void Start()
    {
        /*  if (quillPrefab != null)
          {
              Instantiate(quillPrefab, transform.position, Quaternion.identity);
          }*/
       
        
    }

    // 2D Physics Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"2D Collision detected with: {collision.gameObject.name}");

        if (!collision.CompareTag(playerTag))
        {
            // If it's a tilemap, enemy, or anything else, STOP here and do nothing 
            return;
        }

        if (collision.tag == "PPlayer")
        {
            TriggerSceneLoad();
            print("im colidig with player");
        }
        else
        {
            Debug.LogWarning($"Tag did not match. Object has tag '{collision.tag}', expected '{playerTag}'");
        }

    }

    private void TriggerSceneLoad()
    {
        Debug.Log($"Success! Loading scene index: {sceneBuildIndex}");
        SceneManager.LoadScene(sceneBuildIndex);
    }
}