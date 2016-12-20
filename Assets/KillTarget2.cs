using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTarget2 : MonoBehaviour {

    public GameObject target;
    public GameObject killEffect;
    public ParticleSystem hitEffect;
    public float timeToSelect = 3.0f;
    public int score;

    private ParticleSystem.EmissionModule hitEffectEmission;
    private float countDown;
	// Use this for initialization
	void Start ()
    {
        score = 0;
        countDown = timeToSelect;
        //particle
        hitEffectEmission = hitEffect.emission;
        hitEffectEmission.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
       
        if(Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            if(countDown > 0.0f)
            {
                //hit
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                hitEffectEmission.enabled = true;
            }
            else
            {
                // killed
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                countDown = timeToSelect;
                SetRandomPosition();
        
                DestroyImmediate(killEffect);
            }

        }
        else
        {
            //reset
            countDown = timeToSelect;
            hitEffectEmission.enabled = false;
        }

    }

    void SetRandomPosition()
    {
        float x = Random.Range(-12.0f, 12.0f);
        float z = Random.Range(-12.0f, 12.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }


}
