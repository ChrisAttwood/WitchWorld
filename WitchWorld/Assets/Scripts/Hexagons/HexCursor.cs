using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexCursor : MonoBehaviour {



    public static HexCursor instance;
   

    public Color DefaultColour = Color.white;
    Color CurrentColour = Color.white;
    SpriteRenderer SpriteRenderer;


    private void Awake()
    {
        instance = this;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.color = DefaultColour;
        CurrentColour = DefaultColour;
    }

    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            SpriteRenderer.color = Color.clear;
            return;
        }
        else
        {
            SpriteRenderer.color = CurrentColour;
        }

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = new Vector2(pz.x, pz.y);
        transform.position = HexEngine.instance.RoundToGrid(pos);


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(transform.GetHex().Coordinates);
            transform.GetHex().RegisterClick();
        }

    }

   

}
