using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {
    public GameObject originalObject;
    public GameObject destroyedObject;
    
    [Range(-1000f, 0f)]
    public float minExplosionForce = 10f;

    [Range(0f, 1000f)]
    public float maxExplosionForce = 100f;

    [Range(0f, 100f)]
    public float explosionRadius = 5f;

    [Range(0f, 100f)]
    public float explosionModifier = 3f;

    GameObject currentObject;

    void Start() {
        Create(originalObject);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Destroy();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
    }

    void Create(GameObject obj) {
        currentObject = GameObject.Instantiate(obj);
        currentObject.transform.position = transform.position;
        currentObject.transform.parent = transform;
    }

    void Destroy() {
        Destroy(currentObject);

        Create(destroyedObject);

        foreach (Transform transform in currentObject.transform) {
            Rigidbody rb = transform.GetComponent<Rigidbody>();

            if (rb != null) rb.AddExplosionForce(Random.Range(minExplosionForce, maxExplosionForce), transform.position, explosionRadius, explosionModifier);
        }
    }

    void Reset() {
        Destroy(currentObject);
        Create(originalObject);
    }
}