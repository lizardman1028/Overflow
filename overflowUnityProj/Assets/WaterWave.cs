using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWave : MonoBehaviour
{
    public float waveAmplitude = 0.1f;
    public float waveSpeed = 1f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * waveSpeed) * waveAmplitude;
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }
}
