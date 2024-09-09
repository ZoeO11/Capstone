using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//notes: In this case an "element" is a part of our character (hair, outfit, eyebrow) Shape refers to the shape of the element.
//The swatch, color, or style, will be called by element specific functions (ex:  ChangeHairColor())
//each element is an instance of the CharElement class. These instances are created in the unity editor rather than in code

public class CharCreate : MonoBehaviour
{
    //create list of all charachter elements and create current element
    public List<CharElement> charElements = new List<CharElement>();
    public CharElement curEl; 

   //variables for all elements
    public Sprite[] currentSprites; //sprite sheet elements
    // elements in shape selector
    public SpriteRenderer nextRender; 
    public SpriteRenderer lastRender;
    public SpriteRenderer pRender;
    //variables to track shape
    public int nextShapeTrack = 0;
    public int lastShapeTrack = 0;
    public int pShapeTrack = 0;
    //variables to track index
    public int lastIndex = 0;
    public int pIndex = 0;
    public int nextIndex = 1;
    //hair specific variables
    public Sprite[] bangStyles;
    public SpriteRenderer bangRenderer;
    public int LastHairColor = 0;
    public int PHairColor = 0;

    void Start()
    {
        curEl = charElements[0]; //sets curEl to the first element in the list on start
        ElementSelect(); //calls select element

    }
 
    public void ElementSelect() //will eventually be called by element selection buttons(will need to take input)
    {
        currentSprites = Resources.LoadAll<Sprite>(curEl.PNG);
        ReRender();

        lastIndex = curEl.numShapes - 1;
        pIndex = 0;
        nextIndex = 1;
        nextShapeTrack = 1;
        lastShapeTrack = curEl.numShapes - 1;

    }

    public void ReRender() //renders element previews (called when shape or style changes)
    {
        nextRender.sprite = currentSprites[nextIndex];

        lastRender.sprite = currentSprites[lastIndex];

        pRender.sprite = currentSprites[pIndex];
    }

    
    public void ElementMinus() //called when right arrow is pressed
    {
        //shift index and shape
        lastIndex = pIndex;
        lastShapeTrack = pShapeTrack;
        pIndex = nextIndex;
        pShapeTrack = nextShapeTrack;
        nextShapeTrack++;
        //check if next element is out of range
        if (nextShapeTrack == (curEl.numShapes))
        {
            nextShapeTrack--;
            nextIndex -= nextShapeTrack;
            nextShapeTrack = 0;
        }
        else
        {
            nextIndex++;
        }
        ReRender(); //render new shapes
    }
    public void ElementPlus() //called when left arrow is pressed
    {
        //shift index and shape
        nextIndex = pIndex;
        nextShapeTrack = pShapeTrack;
        pIndex = lastIndex;
        pShapeTrack = lastShapeTrack;
        //check if next element is out of range
        if (lastShapeTrack == 0)
        {
            lastShapeTrack = (curEl.numShapes - 1);
            lastIndex += lastShapeTrack;
        }
        else
        {
            lastIndex--;
            lastShapeTrack--;
        }
        ReRender(); //render new shapes
    }
    public void SetStyle() //called when select button is pressed and applies potential shape + style
    {
        curEl.render.sprite = currentSprites[pIndex];
        if (curEl.element == "Hair") // hair and bangs must be rendered seperately, this renders bangs based on hair
        {
            bangStyles = Resources.LoadAll<Sprite>("CharacterCreator/BangV2");
            bangRenderer.sprite = bangStyles[pIndex];
        }
    }
   
    public void ChangeHairColor() // hair specific function, linked to color buttons.
    {
        lastIndex = PHairColor * curEl.numShapes + lastShapeTrack;
        nextIndex = PHairColor * curEl.numShapes + nextShapeTrack;
        pIndex = PHairColor * curEl.numShapes + pShapeTrack;
        ReRender();
    }


}


