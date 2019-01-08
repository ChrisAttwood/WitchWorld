using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    Sequence CurrentSequence;
    int index;

    public Sequence ExampleSequence;


    private void Start()
    {
        SetSequence(ExampleSequence);
    }

    public void SetSequence(Sequence sequence)
    {
        CurrentSequence = sequence;
        index = 0;
    }


	void Update () {

        if (CurrentSequence == null) return;

        if(index>= CurrentSequence.Rules.Length)
        {
            CurrentSequence = null;
        }
        else
        {
            CurrentSequence.Rules[index].Run(this);
        }


	}

    public void NextRule()
    {
        index++;
    }

}
