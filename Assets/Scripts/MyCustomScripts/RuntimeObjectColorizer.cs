using UnityEngine;
using System.Collections.Generic;

public class RuntimeObjectColorizer : MonoBehaviour
{
    private HashSet<GameObject> seen = new HashSet<GameObject>();

    private Color[] baseColors = new Color[]
    {
        Color.red,
        new Color(1f, 0.5f, 0f),        // Orange
        new Color(1f, 0.84f, 0f),       // Gold
        Color.blue,
        new Color(0f, 0f, 0.5f),        // Navy
        Color.green,
        Color.black,
        Color.white,
        Color.yellow,
        new Color(0.5f, 0f, 0.5f)       // Purple
    };

    public float hueShift = 0.05f;
    public float saturationShift = 0.2f;
    public float valueShift = 0.2f;

    void Update()
    {
        foreach (GameObject obj in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            if (seen.Contains(obj)) continue;
            if (!obj.activeInHierarchy) continue;

            if (!IsTargetName(obj.name)) continue;

            Renderer rend = obj.GetComponent<Renderer>();
            if (rend != null && rend.sharedMaterial != null)
            {
                // Clone the material to avoid global changes
                rend.material = new Material(rend.sharedMaterial);

                Color baseColor = baseColors[Random.Range(0, baseColors.Length)];
                Color.RGBToHSV(baseColor, out float h, out float s, out float v);

                h = Mathf.Repeat(h + Random.Range(-hueShift, hueShift), 1f);
                s = Mathf.Clamp01(s + Random.Range(-saturationShift, saturationShift));
                v = Mathf.Clamp01(v + Random.Range(-valueShift, valueShift));

                rend.material.color = Color.HSVToRGB(h, s, v);

                Debug.Log($"Colored: {obj.name}");
                seen.Add(obj);
            }
        }
    }

    // ✅ Matches any object with name starting with "obj_"
    bool IsTargetName(string name)
    {
        return name.StartsWith("obj_");
    }
}
