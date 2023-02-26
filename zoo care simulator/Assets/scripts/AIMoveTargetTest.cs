using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIMoveTargetTest : MonoBehaviour
{
    [SerializeField] GameObject[] nodeArray;
    [SerializeField] Transform nodeTarget;

    NavMeshAgent agent;
    Transform animalTransform;
    int nodeTargetNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animalTransform = GetComponent<Transform>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        StartCoroutine(changeNode());
    }

    // Update is called once per frame
    void Update()
    {
        nodeTarget = nodeArray[nodeTargetNumber].transform;
        agent.SetDestination(nodeTarget.position);
        //animalTransform.LookAt(nodeTarget);







    }

    IEnumerator changeNode()
    {
        while(true)
        {
            nodeTargetNumber = Random.Range(0, 7);
            yield return new WaitForSeconds(7);
        }

    }
}
