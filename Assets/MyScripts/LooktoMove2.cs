using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooktoMove2 : MonoBehaviour {

    public GameObject ground;
    public GameObject cylinder;
    // Use this for initialization
   
	
	// Update is called once per frame
	void Update ()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);

        for(int i =0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if(hitObject == ground)
            {             
                cylinder.GetComponent<Transform>().position = hit.point;
                Debug.Log("Hit (x,y,z):" + hit.point.ToString("F2"));
            }
        }

	}
}
