using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool isStart = false;
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                if(!isStart)
                {
                    GetComponent<PlayableDirector>().Play();
                    isStart = true;
                }

            }

        }
    }
}

