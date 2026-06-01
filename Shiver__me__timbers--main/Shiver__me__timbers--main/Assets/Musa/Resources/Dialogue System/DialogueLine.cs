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
        [SerializeField] private float delayBetweenLines;



        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image ImageHolder;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";   

            ImageHolder.sprite = characterSprite;
            ImageHolder.preserveAspect = true;
        }

        private void Start()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
            ImageHolder.sprite = characterSprite;
            ImageHolder.preserveAspect = true;
        }
    }
}
