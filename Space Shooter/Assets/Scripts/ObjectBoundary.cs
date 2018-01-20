using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectBoundary
{
    public float xMin, xMax, zMin, zMax;

    public bool OutOfBounds(Vector3 position)
    {
        return (position.x > xMax || position.x < xMin || position.z > zMax || position.z < zMin);
    }

    public Vector3 Clamp(Vector3 position)
    {
        return new Vector3
            (
                Mathf.Clamp(position.x, xMin, xMax),
                position.y,
                Mathf.Clamp(position.z, zMin, zMax)
            );

    }
}
