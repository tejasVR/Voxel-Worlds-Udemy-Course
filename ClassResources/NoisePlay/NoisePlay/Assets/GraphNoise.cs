﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GraphNoise : MonoBehaviour
{

    float t = 0;
    float inc = 0.01f;

    float Map(float min, float max, float omin, float omax, float value)
    {
        return Mathf.Lerp(min, max, Mathf.InverseLerp(omin, omax, value));
    }

    void Update()
    {
        t += inc;
        float n = fBM(t, 6, 0.9f);
        Grapher.Log(n, "Perlin1", Color.red);
    }

    float fBM(float t, int octaves, float persistence)
    {
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;
        for (int i = 0; i < octaves; i++)
        {
            total += Mathf.PerlinNoise(t * frequency, 1) * amplitude;
            maxValue += amplitude;
            amplitude *= persistence;
            frequency *= 2;
        }

        return total / maxValue;
    }
}
