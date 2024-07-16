using DG.Tweening;
using UnityEngine;

namespace Scenes.Level4.Scripts.PlayerMovement
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform toFollow;
        public float distToUse;
        public LayerMask itemLayer;
        [HideInInspector] public GameObject objectAhead;

        // Update is called once per frame
        void Update()
        {
            transform.DOMove(toFollow.position, 0.1f);
            //transform.position = toFollow.position;
            objectAhead = Scan();
        }

        private GameObject Scan()
        {
            Vector3 posPlayer = transform.position;

            if (Vector3.Distance(transform.position, posPlayer) < distToUse)
            {
                Ray rayFordward = new Ray(posPlayer, transform.TransformDirection(Vector3.forward));

                RaycastHit hit;
                if (Physics.Raycast(rayFordward, out hit, distToUse, itemLayer))
                {
                    return hit.transform.gameObject;
                }
            }

            return null;
        }
    }
}
   