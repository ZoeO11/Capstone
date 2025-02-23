using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance : MonoBehaviour
{
    public MoveableObject objectData; // Reference to the ScriptableObject

    private void Start()
    {
        if (objectData != null)
        {
            gameObject.name = objectData.objectName; // Name the GameObject in the scene
        }
    }
}
