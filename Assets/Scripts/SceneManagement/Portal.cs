using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.AI;
namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        enum DestinationIentifier
        {
            A,B,C,D,E
        }


        [SerializeField] int secneToLade = -1;
        [SerializeField] Transform spawnPoint;
        [SerializeField] DestinationIentifier destination;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Transition());
            }


        }

        private IEnumerator Transition()
        {
            if (secneToLade < 0)
            {
                Debug.LogError("Scene to loat not set");
                yield break;
            }

            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync(secneToLade);

            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);

            Destroy(gameObject);

        }

        void UpdatePlayer(Portal otherPortal)
        {
            GameObject player =  GameObject.FindWithTag("Player");
            player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);
            player.transform.rotation = otherPortal.spawnPoint.rotation;

        }

        Portal GetOtherPortal()
        {
           foreach(Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this) continue;
                if (portal.destination != destination) continue;

                return portal;
            }
            return null;
        }
    }
}