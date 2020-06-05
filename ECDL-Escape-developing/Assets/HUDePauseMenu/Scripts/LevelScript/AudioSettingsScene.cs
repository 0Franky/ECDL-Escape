using UnityEngine;

public class AudioSettingsScene : MonoBehaviour
{
    private static readonly string BackgruondPref = "BackgruondPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource[] backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    // Start is called before the first frame update
    void Awake()
    {
        ContinueSettigs();
    }


    private void ContinueSettigs()
    {

        backgroundFloat = PlayerPrefs.GetFloat(BackgruondPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);


        for (int j = 0; j < backgroundAudio.Length; j++)
        {
            backgroundAudio[j].volume = backgroundFloat;
        }

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }

    }

}
