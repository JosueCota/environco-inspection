using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        private bool playSound = true;
        public bool finished
        {
            get; private set;
        }

        protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder, Color textColor, float delay, AudioClip sound)
        {
            textHolder.color = textColor;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];

                if (playSound == true)
                {
                    SoundManager.instance.PlaySound(sound);
                }

                yield return new WaitForSeconds(delay);
                if (Input.GetMouseButton(0))
                {
                    delay -= 1;
                    playSound = false;
                }
            }

            yield return new WaitUntil(() => Input.GetMouseButton(0));
            finished = true;
        }
    }

}
