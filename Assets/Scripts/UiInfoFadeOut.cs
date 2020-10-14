using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInfoFadeOut : MonoBehaviour
{
    private Text infoText;
    public Color startColor;
    public Color fadeOutColor;
    public float fadeSpeed = 0.1f;


    private void Start()
    {
        infoText = GetComponent<Text>();
        infoText.color = fadeOutColor;
        Events.instance.CollectedInfoChangeEvent += InfoChange;
    }

    private void Update()
    {
        if (infoText.color != fadeOutColor) 
        {
            FadeOut();        
        }
    }

    void FadeOut()
    {
        infoText.color = Color.Lerp(infoText.color, fadeOutColor, fadeSpeed * Time.deltaTime);
    }

    public void InfoChange(object sender, Events.CollectableEventArgs e) 
    {
        infoText.color = startColor;
        infoText.text = e.collectableObjectData.SpecialText;
    }

}
