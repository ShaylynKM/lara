using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float fadeSpeed = 0.5f;

    private SpriteRenderer[] spriteRenderers;

    void Start()
    {
        // Disable all sprite renderers initially
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in spriteRenderers)
        {
            renderer.enabled = false;
        }
    }

    public IEnumerator FadeInObjects()
    {
        // Enable all sprite renderers when fade-in starts
        foreach (var renderer in spriteRenderers)
        {
            renderer.enabled = true;
        }

        Color[] startColors = new Color[spriteRenderers.Length];

        // Record starting colors
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            startColors[i] = spriteRenderers[i].color;
            spriteRenderers[i].color = new Color(startColors[i].r, startColors[i].g, startColors[i].b, 0f);
        }

        float timer = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime * fadeSpeed;
            float alpha = Mathf.Lerp(0f, 1f, timer);

            // Apply fade to all children
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                Color newColor = new Color(startColors[i].r, startColors[i].g, startColors[i].b, alpha);
                spriteRenderers[i].color = newColor;
            }

            yield return null;
        }
    }
}