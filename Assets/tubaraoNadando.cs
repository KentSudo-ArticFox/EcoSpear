using UnityEngine;

public class tubaraoNadando : MonoBehaviour
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
        // Nada para frente (ou para trás, dependendo do modelo)
        transform.Translate(Vector3.back * velocidade * Time.deltaTime, Space.Self);

        // Faz curvas suaves
        transform.Rotate(0f, direcao * velocidadeGiro * Time.deltaTime, 0f);

        // Mantém o tubarão reto (sem inclinar)
        Vector3 rotacao = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotacao.y, 0f);

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