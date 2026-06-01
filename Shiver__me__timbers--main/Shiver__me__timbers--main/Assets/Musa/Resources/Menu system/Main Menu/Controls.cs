using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public void ChangeScene(string Controls)
    {
        SceneManager.LoadScene("Controls");
    }

}
