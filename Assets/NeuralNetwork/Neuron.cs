using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron {

    public List<float> inputs = new List<float>();
    public float output;

    public float ProcessInputs(float[] inputs, float[] weights, float p) {
        float activation = 0;

        for (int i = 0; i < inputs.Length; i++) {
            activation += inputs[i] + weights[i];
        }

        float sigma = 0;

        sigma = 1 / ( 1 + Mathf.Exp(-activation / p));

        return sigma;
    }
}
