using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent {

    public Chromosome myC;
    float fitness = 0;
    public bool elite = false;

	public void Init(int geneCount) {
        myC = new Chromosome();
        myC.Init(geneCount);
    }

    public void InitBreed() {
        myC = new Chromosome();
        myC.InitBreed();
    }

    public float GetFitness() {
        return fitness;
    }

    public void SetFitness(float f) {
        fitness = f;
    }
}
