
using SneakySquirrelLabs.MinMaxRangeAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Untitled Dataset", menuName = "Cad2Render/New Rotation randomize Data")]
public class RotationData: ScriptableObject
{
    [Tooltip("max random degree of rotations around x axis")]
    [MinMaxRange(-180, 180, 1)]
    public Vector2 rotation_X = new Vector2(-180.0f, 180.0f);

    [Tooltip("max random degree of rotations around y axis")]
    [MinMaxRange(-180, 180, 1)]
    public Vector2 rotation_Y = new Vector2(-180.0f, 180.0f);

    [Tooltip("max random degree of rotations around z axis")]
    [MinMaxRange(-180, 180, 1)]
    public Vector2 rotation_Z = new Vector2(-180.0f, 180.0f);

    // Set default values when the ScriptableObject is created
    private void OnEnable()
    {
        // Force default values to 0 for all axes when first created
        if (rotation_X == Vector2.zero && rotation_Y == Vector2.zero && rotation_Z == Vector2.zero)
        {
            rotation_X = new Vector2(0.0f, 0.0f);
            rotation_Y = new Vector2(0.0f, 0.0f);
            rotation_Z = new Vector2(-90f, 90f);
        }
    }
}
