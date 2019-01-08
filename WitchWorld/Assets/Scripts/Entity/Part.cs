using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Part  {

    UpperLegL,
    LowerLegL,
    FootL,
    UpperArmL,
    LowerArmL,
    HandL,
    LowerBody,
    Neck,
    UpperBody,
    Head,
    UpperLegR,
    LowerLegR,
    FootR,
    UpperArmR,
    LowerArmR,
    HandR,

}

public static class PartExtension
{

    public static int Order(this Part part)
    {
        switch (part)
        {
            case Part.FootL:
                return 30;
            case Part.FootR:
                return 120;
            case Part.HandL:
                return 40;
            //return 60;
            case Part.HandR:
                return 150;
            case Part.Head:
                return 100;
            case Part.LowerArmL:
                return 0;
            case Part.LowerArmR:
                return 140;
            case Part.LowerBody:
                return 70;
            case Part.LowerLegL:
                return 20;
            case Part.LowerLegR:
                return 110;
            case Part.Neck:
                return 80;
            case Part.UpperArmL:
                return 50;
            case Part.UpperArmR:
                return 130;
            case Part.UpperBody:
                return 90;
            case Part.UpperLegL:
                return 10;
            case Part.UpperLegR:
                return 110;
        }

        return 0;
    }

    public static Vector2 Position(this Part part)
    {
        switch (part)
        {
            case Part.FootL:
                return new Vector2(0f, -0.25f);
            case Part.FootR:
                return new Vector2(0f, -0.25f);
            case Part.HandL:
                return new Vector2(0f, -0.15f);
            case Part.HandR:
                return new Vector2(0f, -0.15f);
            case Part.Head:
                return new Vector2(0f, 0.1f);
            case Part.LowerArmL:
                return new Vector2(0f, -0.2f);
            case Part.LowerArmR:
                return new Vector2(0f, -0.2f);
            case Part.LowerBody:
                return new Vector2(0f, 0f);
            case Part.LowerLegL:
                return new Vector2(0f, -0.25f);
            case Part.LowerLegR:
                return new Vector2(0f, -0.25f);
            case Part.Neck:
                return new Vector2(0f, 0.25f);
            case Part.UpperArmL:
                return new Vector2(0.2f, 0.2f);
            case Part.UpperArmR:
                return new Vector2(-0.2f, 0.2f);
            case Part.UpperBody:
                return new Vector2(0f, 0.2f);
            case Part.UpperLegL:
                return new Vector2(0.05f, 0f);
            case Part.UpperLegR:
                return new Vector2(-0.07f, 0f);
        }
        return Vector2.zero;
    }

    public static Part Parent(this Part part)
    {
        switch (part)
        {
            case Part.FootL:
                return Part.LowerLegL;
            case Part.FootR:
                return Part.LowerLegR;
            case Part.HandL:
                return Part.LowerArmL;
            case Part.HandR:
                return Part.LowerArmR;
            case Part.Head:
                return Part.Neck;
            case Part.LowerArmL:
                return Part.UpperArmL;
            case Part.LowerArmR:
                return Part.UpperArmR;
            case Part.LowerLegL:
                return Part.UpperLegL;
            case Part.LowerLegR:
                return Part.UpperLegR;
            case Part.Neck:
                return Part.UpperBody;
            case Part.UpperArmL:
                return Part.UpperBody;
            case Part.UpperArmR:
                return Part.UpperBody;
            case Part.UpperBody:
                return Part.LowerBody;
            case Part.UpperLegL:
                return Part.LowerBody;
            case Part.UpperLegR:
                return Part.LowerBody;
        }
        return Part.LowerBody;
    }

}
