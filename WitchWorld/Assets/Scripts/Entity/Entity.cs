using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    Sequence CurrentSequence;
    int index;

    public Sequence ExampleSequence;

    public Sequence WalkSequence;
    // public Sequence Idol;

    public bool IsTravelling = true;


    public Body Body { get; set; }

    private void Start()
    {
        Body = GetComponent<Body>();
        SetSequence(ExampleSequence);
    }

    public void SetSequence(Sequence sequence)
    {
        CurrentSequence = sequence;
        index = 0;
    }


	void Update () {


        if (IsTravelling)
        {
            Travel();
            return;
        }



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

    public void Travel()
    {
        if (index >= WalkSequence.Rules.Length)
        {
            index = 0;
        }

        WalkSequence.Rules[index].Run(this);
    }

    public void NextRule()
    {
        index++;
    }

}
