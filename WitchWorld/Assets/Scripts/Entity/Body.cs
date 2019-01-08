using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Body : MonoBehaviour
{

    public Sprite Head;
    public Sprite Neck;
    public Sprite UpperBody;
    public Sprite LowerBody;
    public Sprite UpperArmR;
    public Sprite UpperArmL;
    public Sprite LowerArmR;
    public Sprite LowerArmL;
    public Sprite HandR;
    public Sprite HandL;
    public Sprite UpperLegR;
    public Sprite UpperLegL;
    public Sprite LowerLegR;
    public Sprite LowerLegL;
    public Sprite FootR;
    public Sprite FootL;

    public Sprite Empty;

    public Dictionary<Part, GameObject> Skeleton;

    public Color SkinTone = new Color(0.9f, 0.7f, 0.7f);

    public Dictionary<EquipmentType, Equipment> EquipmentItems;

    void Start()
    {

        CreateBody();
        SetPositions();

        EquipmentItems = new Dictionary<EquipmentType, Equipment>();
    }



    void CreateBody()
    {

        Skeleton = new Dictionary<Part, GameObject>();

        foreach (Part part in System.Enum.GetValues(typeof(Part)))
        {
            GameObject bodyPart = new GameObject(part.ToString());
            SpriteRenderer spriteRenderer = bodyPart.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GetSprite(part);
            float tone = part.Order() * 0.001f;
            bodyPart.GetComponent<SpriteRenderer>().color = new Color(tone + SkinTone.r, tone + SkinTone.g, tone + SkinTone.b);
            bodyPart.GetComponent<SpriteRenderer>().sortingOrder = part.Order();
            Skeleton.Add(part, bodyPart);
        }
    }

    void SetPositions()
    {
        foreach (Part part in System.Enum.GetValues(typeof(Part)))
        {
            var bodyPart = Skeleton[part];
            
            if (part == Part.LowerBody)
            {
                bodyPart.transform.parent = transform;
                bodyPart.transform.localPosition = part.Position();
            }
            else
            {
                bodyPart.transform.parent = Skeleton[part.Parent()].transform;
                bodyPart.transform.localPosition = part.Position();
            }
        }
    }



    public void AddEquipment(Equipment equipment)
    {
        var bodyPart = Skeleton[equipment.TargetBodyPart];
        equipment.transform.parent = bodyPart.transform;
        equipment.transform.localPosition = equipment.OffSet;
        equipment.transform.localScale = bodyPart.transform.localScale;

        if (this.transform.localScale.x < 0)
        {
            equipment.transform.rotation = Quaternion.Euler(0f, 0f, bodyPart.transform.rotation.eulerAngles.z + (360 - equipment.Rotation));
        }
        else
        {
            equipment.transform.rotation = Quaternion.Euler(0f, 0f, bodyPart.transform.rotation.eulerAngles.z + equipment.Rotation);
        }

       
        equipment.GetComponent<SpriteRenderer>().sortingOrder = bodyPart.GetComponent<SpriteRenderer>().sortingOrder + equipment.RelativeSorting;

        if (equipment.EquipmentType != EquipmentType.None)
        {
            EquipmentItems[equipment.EquipmentType] = equipment;
            SetEquipItem(equipment.EquipmentType);
        }

    }




    public void SetEquipItem(EquipmentType equipmentType)
    {
        foreach (var eq in EquipmentItems)
        {
            if (equipmentType == eq.Key)
            {
                eq.Value.gameObject.SetActive(true);
                
            }
            else
            {
                eq.Value.gameObject.SetActive(false);
            }
        }
    }


    Sprite GetSprite(Part part)
    {
        switch (part)
        {
            case Part.Head:
                return Head;
            case Part.Neck:
                return Neck;
            case Part.UpperBody:
                return UpperBody;
            case Part.LowerBody:
                return LowerBody;
            case Part.UpperArmR:
                return UpperArmR;
            case Part.UpperArmL:
                return UpperArmL;
            case Part.LowerArmR:
                return LowerArmR;
            case Part.LowerArmL:
                return LowerArmL;
            case Part.HandR:
                return HandR;
            case Part.HandL:
                return HandL;
            case Part.UpperLegR:
                return UpperLegR;
            case Part.UpperLegL:
                return UpperLegL;
            case Part.LowerLegR:
                return LowerLegR;
            case Part.LowerLegL:
                return LowerLegL;
            case Part.FootR:
                return FootR;
            case Part.FootL:
                return FootL;


        }

        return Empty;
    }



}
