using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexUnit : HMonoBehaviour
{
    [SerializeField] private Vector2Int index;
    [SerializeField] private OnHexUnitObject onHexUnitObject;
    public Vector2Int Index
    {
        get => index;
        set => index = value;
    }

    public void OnInit()
    {
        
    }
    
    public void AttachObject(OnHexUnitObject onHexUnitObjectI)
    {
        onHexUnitObject = onHexUnitObjectI;
        onHexUnitObject.Tf.SetParent(Tf);
        onHexUnitObject.Tf.localPosition = Vector3.zero;
    }
}
