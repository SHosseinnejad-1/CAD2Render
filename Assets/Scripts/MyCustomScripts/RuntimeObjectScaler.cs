using UnityEngine;
using System.Collections.Generic;

public class RuntimeObjectScaler : MonoBehaviour
{
    private HashSet<GameObject> scaled = new HashSet<GameObject>();

    [Header("Scale Limits")]
    public float minScale = 0.3f;
    public float maxScale = 1.2f;

    void Update()
    {
        foreach (GameObject obj in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            if (scaled.Contains(obj)) continue;
            if (!obj.activeInHierarchy) continue;
            if (!IsTargetName(obj.name)) continue;

            // Apply uniform random scale within the range
            float scaleFactor = Random.Range(minScale, maxScale);
            obj.transform.localScale = Vector3.one * scaleFactor;

            Debug.Log($"Scaled {obj.name} to {scaleFactor:F2}");
            scaled.Add(obj);
        }
    }

    bool IsTargetName(string name)
    {
        return name.StartsWith("obj_");
    }
}
