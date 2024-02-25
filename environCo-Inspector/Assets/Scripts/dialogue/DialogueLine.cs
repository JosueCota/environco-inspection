using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;

        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;

        [Header("Time Parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private void Awake() // start and awake both called during the initlization of a script, however:
                             // awake is called when the script instance is being located, called before any start methods-- useful for initializing variables or setting up references that other scripts may need
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            textHolder.text = ""; //always empty when game is launched


            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true; // make sure imageholder always preserves its image
        }

        private void Start() // called right before the first frame update -- typically used for intialization that involves interaction with other object in the scene, suitable for set up that relies on other objects being initialized 
        {
            // initialize in the start function 
            StartCoroutine(WriteText(input, textHolder, textColor, delay, sound)); //needs all parameters fufilled to work

        }
    }
}