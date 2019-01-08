using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DebugRule : Rule {

    public string Text;

    public override void Run(Entity entity)
    {
        Debug.Log(Text);
        entity.NextRule();
    }
}
