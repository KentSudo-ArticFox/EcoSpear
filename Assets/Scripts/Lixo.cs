using UnityEngine;

public class Lixo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ALGUMA COISA ENCOSTOU NO LIXO: " + other.name);

        if (other.CompareTag("Tridente"))
        {
            Debug.Log("TRIDENTE PEGOU O LIXO!");
            Destroy(gameObject);
        }
    }
}