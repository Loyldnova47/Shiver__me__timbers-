using NUnit.Framework.Internal.Commands;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 3;
    public int health = 100;

    private void Start()
    {
        // Check if the GameManager exists and holds data
        if (GGameManager.Instance != null && GGameManager.Instance.LoadedData != null)
        {
            ApplyLoadedData(GGameManager.Instance.LoadedData);

            //Clear it so it doesnt accidentally re-apply if you restart the level
            GGameManager.Instance.ClearLoadedData();
        }
    }

    public void SavePLayer ()
    {
        SaveSystem.SavePlayer(this);
    }

    private void ApplyLoadedData(PlayerData data)
    {
        level = data.level;
        health = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        Debug.Log("Player stats successfully loaded from GameManager!");
    }
}
