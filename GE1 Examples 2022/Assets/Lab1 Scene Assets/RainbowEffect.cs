using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowEffect : MonoBehaviour
{
    public Material mat;
    public Color32[] colours;
    private int colour;

    void Awake()
    {
        colour = 0;
        mat = GetComponent<MeshRenderer>().material;
        colours = new Color32[7]
        {
            new Color32(255, 0, 0, 255),
            new Color32(255, 165, 0, 255),
            new Color32(255, 255, 0, 255),
            new Color32(0, 255, 0, 255),
            new Color32(0, 0, 255, 255),
            new Color32(75, 0, 130, 255),
            new Color32(238, 130, 238, 255),
        };
        StartCoroutine(colourCycle());
    }

    public IEnumerator colourCycle()
    {
        while (true)
        {
            for (float i = 0f; i < 1f; i += 0.003f)
            {
                mat.color = Color.Lerp(colours[colour % 7], colours[(colour + 1) % 7], i);
                yield return null;
            }

            colour++;
        }
    }
}
