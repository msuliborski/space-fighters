using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleHighlight : MonoBehaviour {

	Renderer rend;
	public Sprite regular;
	public Sprite highlight;

	private SpriteRenderer spriteRenderer; 



	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
    	if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
        spriteRenderer.sprite = regular; // set the sprite to sprite1
	}

	void OnMouseOver()
    {
		spriteRenderer.sprite = highlight;
    }

	void OnMouseExit()
    {
		spriteRenderer.sprite = regular;
    }
}


