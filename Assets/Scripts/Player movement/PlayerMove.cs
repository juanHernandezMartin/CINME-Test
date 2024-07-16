using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Level4.Scripts.PlayerMovement
{
    public class PlayerMove : MonoBehaviour
    {
        public float speed, sprintSpeed;
        public float distToGroundToJump, jumpForce, customGravity;
        public LayerMask groundLayer;

        private Rigidbody rb;
        private AudioSource audi;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            audi = GetComponent<AudioSource>();
            audi.Play();
            rb.freezeRotation = true;
        }

        private void Update()
        {
            Sound();
            Jump();
            Move();
            rb.AddForce(Vector3.down * customGravity * Time.deltaTime);
        }


        private void Move()
        {
            float aceleration = speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                aceleration = sprintSpeed;
            }

            float v = -Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            Vector2 normaliced = new Vector2(h, v).normalized;

            h = normaliced.x;
            v = normaliced.y;

            //Vector3 despV = transform.forward * aceleration * v * Time.deltaTime;
            //Vector3 despH = transform.right * aceleration * h * Time.deltaTime;

            rb.velocity = (transform.forward * aceleration * -v) + (transform.up * rb.velocity.y);
            rb.velocity += transform.right * aceleration * h;
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && CanJump())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }

        private bool CanJump()
        {
            Vector3 offSet = Vector3.zero;
            offSet.y = -0.5f;
            Ray rayDown = new Ray(transform.position + offSet, Vector3.down);
            Debug.DrawRay(transform.position + offSet, Vector3.down, Color.red);
            if (Physics.Raycast(rayDown, distToGroundToJump, groundLayer))
            {
                return true;
            }

            return false;
        }

        private void Sound()
        {
            if (rb.velocity.magnitude > 0.1f)
            {
                audi.UnPause();
            }
            else
            {
                audi.Pause();
            }

            if (!CanJump())
            {
                audi.Pause();
            }
        }



    }
}