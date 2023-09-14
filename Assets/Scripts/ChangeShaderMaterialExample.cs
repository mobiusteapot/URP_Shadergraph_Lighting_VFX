using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShaderMaterialExample : MonoBehaviour
{
    public float materialBlinkAmount;
    [SerializeField] private Material targetMaterial;


    private void Update() {
        targetMaterial.SetFloat("_ShouldBlink", materialBlinkAmount);
    }
}
