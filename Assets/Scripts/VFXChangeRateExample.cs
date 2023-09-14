using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXChangeRateExample : MonoBehaviour {
    [SerializeField] private VisualEffect visualEffect;
    [SerializeField] private float spawnRateA = 16f;
    [SerializeField] private float spawnRateB = 128f;
    [SerializeField] private float rateChangeDelay = 3f;
    
    private bool useRateA = false;
    
    private void Start() {
        StartCoroutine(timerCoroutine());
    }

    // Flip between using rate A and B every time the timer finishes. Then, restart the timer.
    private IEnumerator timerCoroutine() {
        yield return new WaitForSeconds(rateChangeDelay);
        useRateA = !useRateA;

        float rateToSet;
        if (useRateA) {
            rateToSet = spawnRateB; 
        } else {
            rateToSet = spawnRateA;
        }

        visualEffect.SetFloat("Spawn Rate", rateToSet);
        StartCoroutine(timerCoroutine());
    }
}
