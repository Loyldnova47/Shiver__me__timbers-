using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSound1 : MonoBehaviour
{
    public AudioSource buttonSound;
    public AudioSource buttonSound2;
    

    private IEnumerator WaitAndLoadScene(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        /*while (LocalizationManager.instance != null && !LocalizationManager.instance.GetIsReady())
        {
            yield return new WaitForEndOfFrame();
        }*/
        SceneManager.LoadScene("MainMenu");
    }

    public void PlaySound()
    {
        buttonSound.Play();
    }

    public void PlaySound2()
    {
        buttonSound2.Play();
    }
    
    
}
