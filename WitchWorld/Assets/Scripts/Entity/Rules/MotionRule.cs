using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MotionRule : Rule {


    public float Speed = 1;

    [Range(-180, 180)]
    public float Head;

    [Range(-180, 180)]
    public float Neck;

    [Range(-180, 180)]
    public float UpperBody;

    [Range(-180, 180)]
    public float LowerBody;

    [Range(-180, 180)]
    public float UpperArmR;

    [Range(-180, 180)]
    public float UpperArmL;

    [Range(-180, 180)]
    public float LowerArmR;

    [Range(-180, 180)]
    public float LowerArmL;

    [Range(-180, 180)]
    public float HandR;

    [Range(-180, 180)]
    public float HandL;

    [Range(-180, 180)]
    public float UpperLegR;

    [Range(-180, 180)]
    public float UpperLegL;

    [Range(-180, 180)]
    public float LowerLegR;

    [Range(-180, 180)]
    public float LowerLegL;

    [Range(-180, 180)]
    public float FootR;

    [Range(-180, 180)]
    public float FootL;



    public override void Run(Entity entity)
    {

        bool RemainingMoves = false;
        float max = Max(entity);
        // Debug.Log("Max " + max);

        if (max > 0)
        {
            foreach (Part part in System.Enum.GetValues(typeof(Part)))
            {

                float target = Normal(GetAngle(part));
                float c = AngleDifference(entity.Body.Skeleton[part].transform.localRotation.z, target);

                if (c > 0)
                {
                   

                    if (entity.transform.localScale.x < 0)
                    {
                        target = -target;
                        if (target < 0)
                        {
                            target += 360;

                        }
                    }


                    entity.Body.Skeleton[part].transform.localRotation = Quaternion.RotateTowards(entity.Body.Skeleton[part].transform.localRotation, Quaternion.Euler(0f, 0f, target), Speed + (c/max));

                    if (!FinishedRoation(entity.Body.Skeleton[part].transform.localRotation.eulerAngles.z, target))
                    {
                        RemainingMoves = true;
                    }
                }


            }
        }
        else
        {

        }

       


        if (!RemainingMoves)
        {
            entity.NextRule();
        }

    }

    float Max(Entity entity)
    {
        float r = 0f;

        foreach (Part part in System.Enum.GetValues(typeof(Part)))
        {

            float target = Normal(GetAngle(part));


            float c = AngleDifference(entity.Body.Skeleton[part].transform.localRotation.eulerAngles.z, target);

            if (c > r)
            {
                r = c;
            }


        }


        return r;
    }

    bool FinishedRoation(float actual, float target)
    {
        if (0.5f > Mathf.Abs(actual - target)) return true;

        if (359.5f < Mathf.Abs(actual - target)) return true;

        //if (10f > Mathf.Abs(actual - target)) return true;

        //if (350f < Mathf.Abs(actual - target)) return true;

        return false;

    }


    float GetAngle(Part part)
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

        return 0;
    }

    float AngleDifference(float a, float b)
    {
        float x = System.Math.Abs(a - b);
        if (x > 180)
        {
            x -= 180;
        }
        return x;

    }

    float Normal(float f)
    {
        if (f < 0f)
        {
            return f + 360f;
        }

        return f;
    }

}
