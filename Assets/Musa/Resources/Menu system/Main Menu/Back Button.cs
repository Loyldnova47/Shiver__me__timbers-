using UnityEngine;

public class BackButton : MonoBehaviour
{
    public MainMMenuController menu;

    public void GoBack()
    {
        menu.SetState(MenuState.Main);
    }
}
