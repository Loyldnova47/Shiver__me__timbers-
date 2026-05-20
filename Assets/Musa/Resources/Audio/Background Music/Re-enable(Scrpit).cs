using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;
public class Re_enable : MonoBehaviour
{

    [SerializeField] GameObject _soundMMManagerParent;
    [SerializeField] GameObject _soundMMManagerChild;
    private Scene scene;

    public SoundMMManager soundManager;

    List <UnityEngine.Object> GetSceneObjectsNonGeneric()
    {
        List <UnityEngine.Object> objectsInScene = new List<UnityEngine.Object>();
        foreach (SoundMMManager go in SoundMMManager.FindObjectsByType<SoundMMManager>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            SoundMMManager cGO = go as SoundMMManager;
            if (cGO != null && !EditorUtility.IsPersistent(cGO.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
            {
                objectsInScene.Add(go);
            }
        }
        return objectsInScene; 
    }

    void Update()
    {
        if (soundManager == null || !soundManager.gameObject.activeInHierarchy) 
        {
           // Debug.Log("SoundMMManger is inactive");
        }

        // Check if this is the next scene (replace "NextSceneName")
        if (scene.name == "Main Menu")
        {
            if (soundManager != null)
            {
                Debug.Log(_soundMMManagerParent.activeSelf);
                // Start the sound
                soundManager.gameObject.SetActive(true);
                Debug.Log(_soundMMManagerParent.activeSelf);
            }
        }
    }

}