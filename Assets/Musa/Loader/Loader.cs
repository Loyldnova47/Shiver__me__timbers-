using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement; 

public static class Loader
{
          public enum Scene
          {
              MainMenu,
              Loading,
              GameScene, 
              // Add other scenes as needed
          }

          private static Action onLoadScene;
          private static AsyncOperation loadingAsyncOperation;

    public static void Load(Scene sceneToLoad)
        {
           //Set the callback to load the desired scene after the loading screen is shown
           onLoadScene = () =>
           {
               var loaderGo = new GameObject("Loader Coroutine Helper");
              
               var loaderMono = loaderGo.AddComponent<LoaderMonoBehaviour>();
              
               loaderMono.StartCoroutine(LoadSceneAsync(sceneToLoad, loaderMono));

               onLoadScene = null;
        };

        // Load the loading screen
        SceneManager.LoadScene(Scene.Loading.ToString());
    }
    public static void LoaderCallback()
    {
            onLoadScene?.Invoke();
    }
    private static IEnumerator LoadSceneAsync(Scene sceneToLoad, LoaderMonoBehaviour loaderMono)
    {
        yield return null;

        loadingAsyncOperation = SceneManager.LoadSceneAsync(sceneToLoad.ToString());

        while (!loadingAsyncOperation.isDone) 
        {
            yield return null;
        }

       UnityEngine.Object.Destroy(loaderMono.gameObject);
    }

    public static float GetLoadingProgress()
    {
        if (loadingAsyncOperation != null)

            return loadingAsyncOperation.progress;
        else return 1f;   
    }

    public static void Load(Scene sceneToLoad, LoadSceneMode mode)
    {
        Load(sceneToLoad);
    }

    // this script was developed with the asistance from Code Monkey :  https://www.youtube.com/watch?v=3I5d2rUJ0pE&list=PLF0hyIu5ZqWIBYvj3QOLcvuNiU0akzal7&index=7
}
