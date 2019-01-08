using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public EquipmentType EquipmentType;
    public Part TargetBodyPart;
    public Vector2 OffSet;
    public int RelativeSorting;
    public float Rotation;


    public void Equip(Body body)
    {
        body.AddEquipment(this);
    }


   
}
