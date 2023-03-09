using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIMoveTargetTest : MonoBehaviour
{
    [SerializeField] GameObject[] nodeArray;
    [SerializeField] Transform nodeTarget;
    [SerializeField] bool isNodeCol;

    NavMeshAgent agent;
    Transform animalTransform;
    int nodeTargetNumber = 0;
    [SerializeField]float speed = 1.0f;
    Quaternion nodeRotQuat;
    int currentNodeChoice;
   
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animalTransform = GetComponent<Transform>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        isNodeCol = false;
        StartCoroutine(changeNode());
    }

    // Update is called once per frame
    void Update()
    {
        nodeTarget = nodeArray[nodeTargetNumber].transform;

        agent.SetDestination(nodeTarget.position);
        nodeRotQuat = Quaternion.LookRotation(nodeTarget.transform.position - animalTransform.position);
        animalTransform.rotation = Quaternion.Slerp(animalTransform.rotation, nodeRotQuat, speed * Time.deltaTime); 

        //animalTransform.LookAt(new Vector3(nodeTarget.position.x, animalTransform.position.y, nodeTarget.position.z));
        //UnityEngine.Debug.Log("x = " + nodeTarget.position.x + "Y = " + animalTransform.position.y + "Z = " + nodeTarget.position.z);






    }

    private IEnumerator changeNode()
    {
        while (true)
        {
            nodeTargetNumber = UnityEngine.Random.Range(0, 7);
            if (currentNodeChoice != nodeTargetNumber)
            {
                currentNodeChoice = nodeTargetNumber;
            }
            else if(currentNodeChoice == nodeTargetNumber)
            {
                nodeTargetNumber = UnityEngine.Random.Range(0, 7);
            }
            

            
            yield return new WaitForSeconds(7);
        }

    }

    private void OnTriggerEnter(Collider col)

    {
        if(col.gameObject.tag == "Node")
        {
            nodeTargetNumber = UnityEngine.Random.Range(0, 7);
        }

    }
}
