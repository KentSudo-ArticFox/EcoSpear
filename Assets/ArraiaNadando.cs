using UnityEngine;

public class ArraiaNadando : MonoBehaviour
{
   
    public float velocidade = 1.2f;
    public float velocidadeVirar = 20f;
    public float movimentoHorizontal = 0.4f;

    private float tempo;

    void Update()
    {
        tempo += Time.deltaTime;

        transform.Translate(Vector3.back * velocidade * Time.deltaTime);

        float curva = Mathf.Sin(tempo * 0.4f) * velocidadeVirar;
        transform.Rotate(Vector3.up, curva * Time.deltaTime);

        float sobeDesce = Mathf.Sin(tempo * 0.7f) * movimentoHorizontal;
        transform.position += Vector3.up * sobeDesce * Time.deltaTime;
    }
}