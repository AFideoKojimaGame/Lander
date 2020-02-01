using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LanderActions {
    TurnLeft,
    TurnRight,
    Thrust
}

public class Lander : MonoBehaviour {

    public Agent myAgent = null;
    int geneCount = 6;

    Vector2 direction = Vector2.zero;

    int index = -1;
    float actionTime = 10;
    float actionCounter = 0;

    float moveSpeed = 2;

    GameObject target;

    LanderActions myAction;

    Rigidbody myRB;

    float distance;

    bool reached = false;

    float currentThrust;
    float currentRot;

    public Material normalMat, eliteMat;

    MeshRenderer myMR;

    Vector3 rotation = Vector3.zero;
    Vector2 movementVector = Vector2.zero;

	// Use this for initialization
	void Start () {
        actionCounter = actionTime + 1;
        target = GameObject.FindGameObjectWithTag("Victory");
        myRB = GetComponent<Rigidbody>();
        myMR = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!myAgent.elite) {
            myMR.material = normalMat;
        }else {
            myMR.material = eliteMat;
        }

        if (transform.position.x <= -15)
            transform.position = new Vector3(-15, transform.position.y, 0);
        if (transform.position.x >= 15)
            transform.position = new Vector3(15, transform.position.y, 0);
        if (transform.position.y >= 10)
            transform.position = new Vector3(transform.position.x, 10, 0);
        if(transform.position.y <= -2.5f)
            transform.position = new Vector3(transform.position.x, -2.5f, 0);

        distance = Vector3.Distance(transform.position, target.transform.position);


        if (reached) {
            myRB.Sleep();
            distance /= 100;
        }else {
            if (myAgent != null) {           
                if(actionCounter < actionTime) {
                    actionCounter += Time.deltaTime;
                    PerformAction();
                }else if(index >= 0) {
                    index++;
                    if (index < geneCount) {
                        actionTime = myAgent.myC.genes[index].time;
                        myAction = myAgent.myC.genes[index].action;
                        currentThrust = myAgent.myC.genes[index].thrust;
                        currentRot = myAgent.myC.genes[index].rotAmount;
                        actionCounter = 0;
                    }
                }else
                    index++;
            }
        }

        myAgent.SetFitness(20 - distance);
	}

    public void PerformAction() {
        
        switch (myAction) {
            case LanderActions.TurnLeft:
                    //myRB.AddTorque(transform.forward);
                    //myRB.freezeRotation = false;
                    //rotation = transform.forward;
                    //transform.Rotate(rotation * moveSpeed);
                    //myRB.AddForce(transform.up * moveSpeed, ForceMode.Acceleration);
                rotation.z = -2;
                movementVector.y = 0;
                break;

            case LanderActions.TurnRight:
                    //myRB.AddTorque(transform.forward * -1);
                    //myRB.freezeRotation = false;
                    //rotation = -transform.forward;
                    //transform.Rotate(rotation * moveSpeed);
                    //myRB.AddForce(transform.up * moveSpeed, ForceMode.Acceleration);
                rotation.z = 2;
                movementVector.y = 0;
                break;

            case LanderActions.Thrust:
                    //myRB.freezeRotation = true;
                    //myRB.AddForce(transform.up * moveSpeed, ForceMode.Acceleration);
                movementVector.y = 1;
                break;
        }
        transform.Rotate(rotation);
        transform.Translate(movementVector * Time.deltaTime * 3);

        if (rotation.z > 0)
            rotation.z -= Time.deltaTime;

        if (rotation.z < 0)
            rotation.z += Time.deltaTime;
    }

    void OnTriggerEnter(Collider col) {
        //myRB.Sleep();

        if (col.gameObject.tag == "Victory") {
            reached = true;
        }
    }

    void OnCollisionStay(Collision col) {
        //myRB.Sleep();
    }

    public void ReplaceAgent(Agent a) {
        myMR.material = normalMat;
        //myRB.ResetCenterOfMass();
        //myRB.ResetInertiaTensor();
        //transform.rotation = Quaternion.identity;
        //myRB.Sleep();
        //myRB.rotation = Quaternion.identity;
        //myRB.velocity = Vector3.zero;
        //myRB.Sleep();
        transform.rotation = Quaternion.identity;
        rotation = Vector3.zero;
        movementVector = Vector3.zero;
        //myRB.velocity = Vector3.zero;
        //myRB.WakeUp();
        reached = false;
        index = -1;
        actionCounter = actionTime + 1;
    }
}
