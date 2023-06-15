using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointer : MonoBehaviour
{
    [SerializeField] private GameObject objective; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = objective.transform.position - transform.position;
    }
}
