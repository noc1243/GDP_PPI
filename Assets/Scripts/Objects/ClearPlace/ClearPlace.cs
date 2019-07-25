using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlace : MonoBehaviour
{
    [SerializeField] GameObject canvasClearGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player")) {
            canvasClearGame.active = true;
        }
    }
}
