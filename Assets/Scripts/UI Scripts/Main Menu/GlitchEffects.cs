using UnityEngine;
using System.Collections;

public class GlitchEffects : MonoBehaviour {
    public UnityStandardAssets.ImageEffects.NoiseAndGrain horizontalNoiseComponent;
    float nextUpdateTime = 0;

    


    public float minPause = 2f;
    public float maxPause = 15f;

    public float minGlitchDuration = 0.4f;
    public float maxGlitchDuration = 1.5f;

    bool hasGlitch = false;



	// Use this for initialization
	void Start () {
        //initial noise pause 
        nextUpdateTime = Time.time + Random.Range(minPause, maxPause);
    }

	void Update () {
        if(Time.time + Time.deltaTime > nextUpdateTime)
        {
            //Update noise
            if (hasGlitch)
            {
                //Reset noise
                horizontalNoiseComponent.intensityMultiplier = .5f;
            }
            else
            {
                //Update noise
                float newAmount = Random.Range(1, 10);
                horizontalNoiseComponent.intensityMultiplier = newAmount;

            }
            
            //Update hasNoice var
            hasGlitch = !hasGlitch;



            //Update time
            if (hasGlitch)
            {
                //according to Duration vars
                nextUpdateTime = Time.time + Random.Range(minGlitchDuration, maxGlitchDuration);
            }
            else
            {
                //according to Pause vars
                nextUpdateTime = Time.time + Random.Range(minPause, maxPause);
            }


            
        }
	}
}
