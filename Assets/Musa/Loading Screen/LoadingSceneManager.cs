using UnityEngine;

public class LoadingSceneManager : MonoBehaviour
{
    private void Start()
    {
        Loader.LoaderCallback(); // Call the Loader callback to start loading the next scene when the loading screen is active
    }
}
