using UnityEngine;

public class Peixeswin : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidadeFormard = 3.0f;
    public float velocidadeVertical = 1.5f;

    [Header("Correção de Rotação (Ajuste aqui se o peixe deitar)")]
    [Tooltip("Se o peixe nascer tombado de lado, mude esse valor (ex: 90 ou -90) para desentortar")]
    public float compensarInclinacaoZ = 0f;
    public float compensarInclinacaoX = 0f;

    private float tempo;

    void Update()
    {
        // 1. FAZ O PEIXE SUBIR E DESCER SUAVE (Estilo nado real)
        tempo += Time.deltaTime;
        float movimentoVertical = Mathf.Sin(tempo * 2.0f) * velocidadeVertical;

        // 2. CONSTROI O DESLOCAMENTO (Para frente e para cima/baixo)
        Vector3 direcaoDeslocamento = new Vector3(0, movimentoVertical, velocidadeFormard) * Time.deltaTime;
        transform.Translate(direcaoDeslocamento, Space.Self);

        // 3. TRAVA E CORRIGE A DEFORMIDADE (Mantém ele em pé na marra)
        Vector3 rotacaoAtual = transform.localEulerAngles;

        // Substitui os eixos tortos pelos valores de compensação para estabilizar o peixe
        transform.localRotation = Quaternion.Euler(compensarInclinacaoX, rotacaoAtual.y, compensarInclinacaoZ);
    }
}