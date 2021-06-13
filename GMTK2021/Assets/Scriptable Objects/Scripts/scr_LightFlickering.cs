using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LightFlickering : MonoBehaviour
{
    public float Intensity = 0.2f;
    public float Iterations = 3.0f;
    public float Randomness = 1.0f;

    private float time;
    private float startIntensity;
    private Light sceneLight;

    // Start is called before the first frame update
    void Start()
    {
        sceneLight = GetComponent<Light>();
        startIntensity = sceneLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * (1 - Random.Range(-Randomness, Randomness)) * Mathf.PI;
        sceneLight.intensity = startIntensity + Mathf.Sin(time * Iterations) * Intensity;
    }
}
