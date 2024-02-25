using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance  // can be accessed from any other class inside project
    {
        get; private set; // good practice for larger projects / teams 
        // get: defines a getter method for the property, allowing other classes to read the value of the property
        // private set: defines a private setter method for the property, restricting access to setting the value of the property to only within the class itself
        // property that can be read from outside the class but can only be set within the class
    }

    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

}