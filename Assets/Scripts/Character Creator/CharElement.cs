using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharElement
{
    public int numShapes; //total number of shapes
    public int numSwatches; //number fo swatches (ex: number of hair colors)
    public int curIndex; //currently not used. Will be used to write to json file eventually
    public string element; //name of the element
    public string PNG; //where the sprite sheet is stored
    public SpriteRenderer render; //the sprite renderer for the element 

    public CharElement(int numShapes, int numSwatches,int curIndex, string element, string PNG, SpriteRenderer render) //setter function
    {
        this.numShapes = numShapes;
        this.numSwatches = numSwatches;
        this.curIndex = curIndex;
        this.element = element;
        this.PNG = PNG;
        this.render = render;
    }

}



