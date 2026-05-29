using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header("Time parameters")]
        [SerializeField] private float delay;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        private void Awake()
        {
            textHolder = GetComponent<Text>();

            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound));
        }
    }
}
