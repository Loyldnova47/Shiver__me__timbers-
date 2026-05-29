using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void Toggle()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
