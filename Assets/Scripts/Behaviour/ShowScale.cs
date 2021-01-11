using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScale : MonoBehaviour
{
    public Color color;
    public enum Kind
    {
        eCube,
        eXSphere,
        eYSphere,
        eZSphere
    }

    public Kind kind;

    public void OnDrawGizmos()
    {
        Gizmos.color = color;
        if (kind == Kind.eCube)
            Gizmos.DrawCube(transform.position, transform.localScale);
        else
        {
            float rayon = kind == Kind.eXSphere ? transform.localScale.x : (kind == Kind.eYSphere ? transform.localScale.y : transform.localScale.z);
            Gizmos.DrawSphere(transform.position, rayon);
        }
    }
}
