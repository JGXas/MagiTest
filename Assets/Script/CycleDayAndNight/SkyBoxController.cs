using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SkyBoxController : MonoBehaviour
{
    [SerializeField] private Material blendedSkybox;

    [Header("Values")]
    [SerializeField, Range(0f, 360f)] private float rotation;
    [Range(0f, 1f)] public float blend;

    void Update()
    {
        UpdatemMaterialParameters();
    }

    private void UpdatemMaterialParameters()
    {
        blendedSkybox.SetFloat("_Rotation", rotation);
        blendedSkybox.SetFloat("_Blend", blend);
    }
}