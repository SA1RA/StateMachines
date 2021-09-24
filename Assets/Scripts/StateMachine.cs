using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State { 
        idle,
        walking,
        swimming,
        climbing
    }

    public State currentState = State.idle;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    } 

    // Update is called once per frame
    void Update()
    {
        switch(currentState) {
            case State.idle: Idle(); break;
            case State.walking: Walking(); break;
            case State.swimming: Swimming(); break;
            case State.climbing: Climbing(); break;
            default: break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "WaterTrigger")
        {
            currentState = State.swimming;
            Debug.Log(currentState);
        }
        else if (other.name == "MountainTrigger") {
            currentState = State.climbing;
            Debug.Log(currentState);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentState = State.walking;
        Debug.Log(currentState);
    }

    void Swimming() {
        //Debug.Log("I am swimming");
    }

    void Climbing() {
        //Debug.Log("I am climbing");
    }

    void Idle() {
        if (lastPosition != transform.position) {
            currentState = State.walking;
            Debug.Log(currentState);
        }
        lastPosition = transform.position;
    }

    void Walking() {
        if (lastPosition == transform.position)
        {
            currentState = State.idle;
            Debug.Log(currentState);
        }
        lastPosition = transform.position;
    }

}
