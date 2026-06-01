using UnityEngine;

public class PaascodeExit : MonoBehaviour
{
    [Header ("Exit Settings")]
    public string correctCode = "1342";
    public string nextSceneName = "Level 2";

    [Header ("References")]
    public PasscodeUI passcodeUI;

    private bool isQuillInRange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isQuillInRange && Input.GetKeyDown(KeyCode.Return))
            passcodeUI.Open(this);
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PPlayer"))
        {
            isQuillInRange = true;
            Debug.Log("Quill entered exit range.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PPlayer"))
        {
            isQuillInRange = false;
            Debug.Log("Quill left exit range.");
        }

    }

        public bool Validate(string inputCode)
        {
            if (inputCode == correctCode)
            {
                Debug.Log("Correct code entered! Loading next scene...");
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
                return true;
            }
            else
            {
                Debug.Log("Incorrect code. Try again.");
                return false;
            }
        }
    
}
