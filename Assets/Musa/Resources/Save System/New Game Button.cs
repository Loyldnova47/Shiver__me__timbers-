using UnityEngine;

public class NewGameButton : MonoBehaviour
{
   public void NewGame()
   {
        SaveManager.DeleteSave();

        SaveManager.SaveLevel(1); // First level
   }
}
