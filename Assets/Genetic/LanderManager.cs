using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderManager : MonoBehaviour {

    List<Lander> landers = new List<Lander>();
    public Vector3 initialPos = new Vector3(0, 3, 0);
    GeneticAlgorithm myGA;

    public GameObject landerPrefab;

	// Use this for initialization
	void Start () {

        for(int i = 0; i < 20; i++) {
            GameObject newLander = Instantiate(landerPrefab, initialPos, Quaternion.identity);
            landers.Add(newLander.GetComponent<Lander>());
        }

        myGA = GetComponent<GeneticAlgorithm>();

        for (int i = 0; i < landers.Count; i++) {
            landers[i].transform.position = initialPos;
            landers[i].myAgent = myGA.population[i];
        }

        myGA.done = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (myGA.done) {
            ResetLanders();
        }
    }

    void ResetLanders() {

        for (int i = 0; i < 20; i++) {
            Destroy(landers[i].gameObject);
        }

        landers.Clear();
        landers = null;
        landers = new List<Lander>();

        for (int i = 0; i < 20; i++) {
            GameObject newLander = Instantiate(landerPrefab, initialPos, Quaternion.identity);
            landers.Add(newLander.GetComponent<Lander>());
        }

        //for (int i = 0; i < landers.Count; i++) {
        //    landers[i].transform.position = initialPos;
        //    landers[i].ReplaceAgent(myGA.population[i]);
        //}

        for (int i = 0; i < landers.Count; i++) {
            landers[i].transform.position = initialPos;
            landers[i].myAgent = myGA.population[i];
        }

        myGA.done = false;
    }
}
