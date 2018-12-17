﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

    public bool picked;
    [SerializeField] private float rotationSpeed;
    public Manager gameManager;

    private void Start()
    {
        gameManager = GetComponent<Manager>();
    }

    public void BePicked(Transform newParent)
    {
        picked = true;
        StartCoroutine(HandlePick(newParent));
    }

    IEnumerator HandlePick(Transform newParent)
    {
        yield return new WaitForSeconds(1.5f);
        transform.parent = newParent;
        transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);

    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 5 * rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);

        if (picked)
        {
            Debug.Log("You have collected some more arrows!");
            gameManager.PlayerArrows += Random.Range(2, 5);
        }
    }
}
