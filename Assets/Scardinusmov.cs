using UnityEngine;

public class Scardinusmov : MonoBehaviour

{
    [Header("Movimento")]
    public float velocidade = 2f;
    public float velocidadeGiro = 25f;

    [Header("Direção do modelo")]
    public bool inverterDirecao = true;

    private float direcao;
    private float tempoTroca;

    void Start()
    {
        EscolherNovaDirecao();
    }

    void Update()
    {
        // Define qual é a direção para frente
        Vector3 movimento;

        if (inverterDirecao)
        {
            movimento = Vector3.forward;
        }
        else
        {
            movimento = Vector3.back;
        }

        // Faz o peixe nadar
        transform.Translate(
            movimento * velocidade * Time.deltaTime,
            Space.Self
        );

        // Faz curvas suaves
        transform.Rotate(
            0f,
            direcao * velocidadeGiro * Time.deltaTime,
            0f
        );

        // Contador para trocar a direção da curva
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
