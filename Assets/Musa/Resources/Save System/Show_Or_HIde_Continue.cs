using UnityEngine;
using UnityEngine.UI;

public class Show_Or_HIde_Continue : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Start()
    {
        continueButton.interactable = SaveManager.SaveExists();
    }
}
