using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed;
        public Camera cam;
        private Vector3 mousePos;
        private Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
               Ray ray = cam.ScreenPointToRay(Input.mousePosition);
               RaycastHit hit;
               if(Physics.Raycast(ray, out hit))
               {
                   Debug.Log(hit);
                   rb.position = Vector3.MoveTowards(rb.transform.position, mousePos, (speed * Time.deltaTime));
               }
               
                
            }



        }
    }
}

    


