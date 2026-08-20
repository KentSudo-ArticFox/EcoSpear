using UnityEngine;

public class TartarugaNadando : MonoBehaviour
{
    public float velocidade = 1.2f;
    public float velocidadeVirar = 10f;

    private float tempo;

    void Start()
    {
        tempo = Random.Range(0f, 100f);
    }

    void Update()
    {
        tempo += Time.deltaTime;

       
        transform.Translate(
            Vector3.back * velocidade * Time.deltaTime,
            Space.Self
        );

        float curva = Mathf.Sin(tempo * 0.3f) * velocidadeVirar;

        transform.Rotate(
            Vector3.up,
            curva * Time.deltaTime,
            Space.Self
        );
    }
}