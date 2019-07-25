using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    [SerializeField] private float vidaRecuperada = 20.0f;

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
            health.recuperaHP (vidaRecuperada);
            gameObject.active = false;
        }
    }
}
