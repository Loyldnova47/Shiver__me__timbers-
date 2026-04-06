using UnityEngine;

public class LoadingStarter : MonoBehaviour
{
    void Start()
    {
       if (Loader.GetLoadingProgress() < 1f)
       { 
          // Nothing extra needed if Loader. Load was called
       }
    }
}
