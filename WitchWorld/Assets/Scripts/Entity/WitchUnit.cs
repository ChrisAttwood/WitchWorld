using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WitchUnit : MonoBehaviour
{
    public Witch witch;
    public HexTile currentHex;

    public List<SpriteRenderer> layers;

    public Vector2 Target;
    List<Vector3Int> Path;
    Vector3Int? Step;



    public void SetupWitchColours()
    {
        FaceData faceData = witch.faceData;
        UpdateLayerSprite("Robe", faceData.clothingColour);
        UpdateLayerSprite("Belt", Color.black);
        UpdateLayerSprite("BeltBuckle", Color.white);
        UpdateLayerSprite("Head", faceData.skinColour);
        UpdateLayerSprite("Hat", faceData.clothingColour);
        UpdateLayerSprite("Hair", faceData.hairColour);
    }


  

        void Update()
        {
            if (Step != null)
            {
                TakeStep();
            }
            else
            {
                if (Path != null && Path.Count > 0)
                {
                    Move();
                }
            }




        }

        public void SetPath(List<Vector3Int> path)
        {
            HexEngine.instance.Spaces[transform.ToGridVector3Int()] = true;
            Debug.Log(path.Count);
            Path = path;
            Path.Reverse();
        }

        void Move()
        {
            Step = Path[Path.Count - 1];
            Path.RemoveAt(Path.Count - 1);
        }

        void TakeStep()
        {
            Vector2 target = HexEngine.instance.GetWorldPosition(Step.Value);
            transform.position = Vector2.MoveTowards(transform.position, target, 1f * Time.deltaTime);

            if (transform.position.x > target.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }

            if (Vector2.Distance(target, transform.position) < 0.01f)
            {

                Step = null;

                if (Path.Count == 0)
                {
                    HexEngine.instance.Spaces[transform.ToGridVector3Int()] = false;
           

                }
            }
        }




    // Commented out section is to load different sprites, see exact same method in FaceDisplay.
    // Had to change this to use a spriterenderer instead though, so it is slightly different.
    private void UpdateLayerSprite(string layerName, Color colour)
    {
        SpriteRenderer spriteRenderer = ReturnMatchingLayerInUI(layerName);
        //image.sprite = spriteList[spriteIndex];
        spriteRenderer.color = colour;
        //spriteRenderer.enabled = false;
        //spriteRenderer.enabled = true;
    }

    private SpriteRenderer ReturnMatchingLayerInUI(string layerName)
    {
        SpriteRenderer spriteToReturn = (from SpriteRenderer spRend in layers
                               where spRend.name == layerName
                               select spRend).Single();
        return spriteToReturn;
    }

    public void RegisterClick()
    {
        UnitMovement.BeginMovement(this);
    }
}
