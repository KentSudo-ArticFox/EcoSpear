using UnityEngine;

public class GolfinhoNadando : MonoBehaviour
{
    public float velocidade = 2f;
    public float velocidadeGiro = 25f;

    private float direcao;
    private float tempoTroca;

    void Start()
    {
        EscolherNovaDirecao();
    }

    void Update()
    {
        // Anda para a direção contrária
        transform.Translate(Vector3.back * velocidade * Time.deltaTime, Space.Self);

        // Faz curvas suaves
        transform.Rotate(0f, direcao * velocidadeGiro * Time.deltaTime, 0f);

        tempoTroca -= Time.deltaTime;

        if (tempoTroca <= 0f)
        {
            EscolherNovaDirecao();
        }
    }

    void EscolherNovaDirecao()
    {
        direcao = Random.Range(-1f, 1f);
        tempoTroca = Random.Range(2f, 5f);
    }
}