using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome {

    public int geneCount = 4;

    public List<Gene> genes = new List<Gene>();

    int max = 3;

	public void Init(int count) {

        geneCount = count;

        genes.Clear();
        genes = null;
        genes = new List<Gene>();
        
        for(int i = 0; i < geneCount; i++) {
            genes.Add(new Gene());
            genes[i].action = (LanderActions)Random.Range(0, 3);
            genes[i].time = Random.Range(1, max);
            genes[i].rotAmount = Random.Range(0.1f, 0.5f);
            genes[i].thrust = Random.Range(0.1f, 3);
        }
    }

    public void InitBreed() {
        genes.Clear();
        genes = null;
        genes = new List<Gene>();
    }

    public void AddGene(Gene g) {
        Gene newG = new Gene();
        newG.action = g.action;
        newG.time = g.time;
        genes.Add(newG);
    }
}
