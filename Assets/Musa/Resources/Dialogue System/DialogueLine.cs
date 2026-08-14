using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        [SerializeField] private float delay = 0.05f;
        [SerializeField] private float delayBetweenLines = 1f;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image ImageHolder;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            if (ImageHolder != null)
            {
                ImageHolder.sprite = characterSprite;
                ImageHolder.preserveAspect = true;
            }
        }

        private void Start()
        {
            if (textHolder == null)
                textHolder = GetComponent<Text>();

            textHolder.text = "";

            if (ImageHolder != null)
            {
                ImageHolder.sprite = characterSprite;
                ImageHolder.preserveAspect = true;
            }

            if (!string.IsNullOrEmpty(input))
                StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
        }
    }
}