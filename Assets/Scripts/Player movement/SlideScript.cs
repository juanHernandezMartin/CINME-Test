using UnityEngine;

namespace Scenes.Level4.Scripts.PlayerMovement
{
    public class SlideScript : MonoBehaviour
    {
        public float slideSpeed;
        public float slideTime;
        public float scaleSlide;

        private float originalScale;
        private float slideTimer;
        private bool isSliding;
        private Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            originalScale = transform.localScale.y;
            isSliding = false;
            slideTimer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isSliding && Input.GetKeyDown(KeyCode.LeftControl))
            {
                isSliding = true;
                Vector3 newScale = transform.localScale;
                newScale.y = scaleSlide;
                transform.localScale = newScale;
            }

            if (isSliding)
            {
                slideTimer += Time.deltaTime;
                Vector3 dirSlide = transform.TransformDirection(Vector3.forward);
                rb.AddForce(dirSlide * slideSpeed * Time.deltaTime);

                if (slideTimer > slideTime)
                {
                    isSliding = false;
                    slideTimer = 0;
                    Vector3 newScale = transform.localScale;
                    newScale.y = originalScale;
                    transform.localScale = newScale;
                }
            }
        }
    }
}