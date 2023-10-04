using System.Collections.Generic;
using UnityEngine;

public class Cache
{
    // TEMPORARY, CHANGE WITH OTHER VALUE TYPE
    private static readonly Dictionary<Collider2D, HMonoBehaviour> Entities = new();
    
    public static HMonoBehaviour GetEntity(Collider2D collider)
    {
        if (!Entities.ContainsKey(collider)) Entities.Add(collider, collider.GetComponent<HMonoBehaviour>());
        return Entities[collider];
    }
}
