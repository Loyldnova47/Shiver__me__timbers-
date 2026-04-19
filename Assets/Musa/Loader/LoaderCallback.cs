using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
   private bool isFirstUpdate = true;
    void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.Load(Loader.Scene.GameScene); // Load the main game scene
        }
    }
    // this script was developed with the asistance from Code Monkey :  https://www.youtube.com/watch?v=3I5d2rUJ0pE&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=7
}
