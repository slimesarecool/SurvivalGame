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

    [Range(0f, 20f)]
    public float fragScaleFactor = 4f;

    GameObject currentObject;

    void Start() {
        Create(originalObject);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            DestroyObject();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
    }

    void Create(GameObject obj) {
        Destroy(currentObject);
        currentObject = GameObject.Instantiate(obj);
        currentObject.transform.position = transform.position;
        currentObject.transform.parent = transform;
    }

    void DestroyObject() {
        Create(destroyedObject);

        foreach (Transform t in currentObject.transform) {
            Rigidbody rb = t.GetComponent<Rigidbody>();

            if (rb != null) rb.AddExplosionForce(Random.Range(minExplosionForce, maxExplosionForce), transform.position, explosionRadius, explosionModifier);

            StartCoroutine(Shrink(t));
        }
    }

    void Reset() {
        Create(originalObject);
    }

    IEnumerator Shrink(Transform t) {
        yield return new WaitForSeconds(10f);
        
        if (t == null) yield break;

        Vector3 newScale = t.localScale;
        Color col = t.gameObject.GetComponent<MeshRenderer>().material.color;

        while (col.a >= 0 && newScale.x >= 0) {
            newScale -= new Vector3(fragScaleFactor, fragScaleFactor, fragScaleFactor);
            col.a -= 0.04f;
            t.localScale = newScale;
            t.gameObject.GetComponent<MeshRenderer>().material.color = col;

            yield return new WaitForSeconds(0.01f);
        }

        Destroy(t.gameObject);
    }
}