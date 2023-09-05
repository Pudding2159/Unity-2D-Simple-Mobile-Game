using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicResolution : MonoBehaviour
{
    public Text screenText;

    private Vector2 MainRes;
    public float CurScale = 1;
    public float MinScale = 0.5f;
    public float ScaleStep = 0.05f;

    public int MinFPS = 40;
    public int MaxFPS = 55;
    private float MinFPSS;
    private float MaxFPSS;
    public float Delay;
    private float DelayTime;
    // Use this for initialization
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        MainRes = new Vector2(Screen.width, Screen.height);
        DelayTime = Delay;
        MinFPSS = 1f / (float)MinFPS;
        MaxFPSS = 1f / (float)MaxFPS;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > DelayTime)
        {
            if (Time.deltaTime > MinFPSS)
            {
                if (CurScale > MinScale)
                {
                    CurScale -= ScaleStep;
                    Screen.SetResolution((int)(MainRes.x * CurScale), (int)(MainRes.y * CurScale), true);
                    DelayTime = Time.time + Delay;
                }
            }
            else
            if (CurScale < 1 && Time.deltaTime < MaxFPSS)
            {
                CurScale += ScaleStep;
                Screen.SetResolution((int)(MainRes.x * CurScale), (int)(MainRes.y * CurScale), true);
                DelayTime = Time.time + Delay;
            }
            DelayTime = Time.time + 0.5f;
        }

        screenText.text = "X " + Screen.width + " / Y " + Screen.height + " / scale " + CurScale +" / "+ Time.deltaTime;
    }
}