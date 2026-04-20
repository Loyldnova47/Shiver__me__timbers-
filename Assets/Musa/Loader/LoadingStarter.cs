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

    // this script was developed with the asistance from Code Monkey :  https://www.youtube.com/watch?v=3I5d2rUJ0pE&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=7
}
