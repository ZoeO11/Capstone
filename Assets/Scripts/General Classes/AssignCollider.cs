using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssignCollider : MonoBehaviour
{
    public NPC myNPC;
    public TMP_Text currentText;


    private void Start()
    {
        myNPC.myCollider = gameObject.GetComponent<Collider2D>();
        myNPC.myText = currentText;
    }
}
