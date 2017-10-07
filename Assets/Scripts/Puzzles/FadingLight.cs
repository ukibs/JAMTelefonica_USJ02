using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingLight : MonoBehaviour {

    //Public
    public Texture fadeTexture;
    public float fadeSpeed = 0.01f;

    //Private
    private bool fading = true;
    private int drawDepth = -100;
    private Color fadeColor;
    private float alpha = 0.0f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        alpha += fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        fadeColor = GUI.color;
        fadeColor.a = alpha;
    }

    void OnGUI()
    {
        GUI.color = fadeColor;
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    //
    public void Power()
    {
        alpha -= fadeSpeed * 5.0f * Time.deltaTime;
    }
}
