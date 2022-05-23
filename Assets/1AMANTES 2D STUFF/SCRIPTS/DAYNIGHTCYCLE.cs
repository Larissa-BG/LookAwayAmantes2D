using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAYNIGHTCYCLE : MonoBehaviour
{
    //public
    //condition
    [Range(0.0f, 1.0f)] //adds a slider that limits you to this range of numbers
    public float time;
    public float fullDayLenght;
    public float startTime = 0.4f;
    
    //vectors 3 holding position
    public Vector3 noon;
    
    //Header SUN
    [Header("SUN")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    //Header MOON
    [Header("MOON")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    //Header LIGHTING
    [Header("OTHER LIGHTING")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;

    //private
    private float timeRate;

    void Start()
    {
        timeRate = 1.0f / fullDayLenght;
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        //time stuff 
        time += timeRate * Time.deltaTime;

        if (time >=1.0f)
        {
            time = 0.0f; //resets time if time over the limit (1.0f)
        }

        // light rotation 
        sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f; // during midday its pointing directly downwards, during midnight is going to be pointing upwards
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;// same for the moon

        //light intensity 
        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);
    }

}
