using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _title;
    [SerializeField]
    private string objName;
    // Start is called before the first frame update
    public void Start()
    {
        _title.gameObject.SetActive(false);
    }
    void OnMouseDown()
    {
        _title.gameObject.SetActive(true);
        _title.text = objName;
    }

}
