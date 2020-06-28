using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
   
    public Vector3 offset;
    [Range(1,50)]
    public float radius;

    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere ( this.transform.position + offset , radius );
    }
}
