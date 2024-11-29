using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.5f;

    private void Awake() // Fixed method name casing
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // Update the texture offset for the parallax effect
        meshRenderer.material.mainTextureOffset = new Vector2(animationSpeed * Time.time, 0);
    }
}
