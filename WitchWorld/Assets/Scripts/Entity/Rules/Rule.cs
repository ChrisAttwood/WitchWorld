using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Rule : ScriptableObject {

	public virtual void Run(Entity entity)
    {
        entity.NextRule();
    }
}
