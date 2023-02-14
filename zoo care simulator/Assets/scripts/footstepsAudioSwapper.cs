using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class footstepsAudioSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip[] footstepAudioList;
    private FirstPersonController player;
    [Tooltip("changes out the walk sounds for the corrosponding index in the array of audio")]
    public int audioIndex;
    void Start()
    {
        player= gameObject.GetComponent<FirstPersonController>();
    }

    //call this in the floor sensor
    public void changeFootstepSound(int floorIndex)
    {
        player.m_FootstepSounds = footstepAudioList[audioIndex];
    }
    private void Update()
    {
        //debug
        player.m_FootstepSounds = footstepAudioList[audioIndex];
    }
}
