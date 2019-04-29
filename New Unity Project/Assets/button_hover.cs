using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_hover : MonoBehaviour
{
    public AudioSource mfFx;
    public AudioClip hover_sd;
    public AudioClip click_sd;

    // Start is called before the first frame update
    public void HoverSound()
    {
        mfFx.PlayOneShot(hover_sd);
    }

    // Update is called once per frame
    public void ClickSound()
    {
        mfFx.PlayOneShot(click_sd);
    }
}
