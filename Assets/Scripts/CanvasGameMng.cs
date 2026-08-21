using UnityEngine;
using TMPro;

public class CanvasEnergy : MonoBehaviour
{
    [Header("Tempo")]
    public float tempoTotal = 600f; // 10 minutos
    private float tempoRestante;

    [Header("Lixos")]
    public int lixosPegos = 0;
    public int totalDeLixos = 30;

    [Header("Textos da UI")]
    public TextMeshProUGUI textoTempo;
    public TextMeshProUGUI textoLixos;

    [Header("Painéis")]
    public GameObject painelVitoria;
    public GameObject painelDerrota;

    private bool jogoTerminou = false;

    void Start()
    {
        tempoRestante = tempoTotal;

        painelVitoria.SetActive(false);
        painelDerrota.SetActive(false);

        AtualizarUI();
    }

    void Update()
    {
        if (jogoTerminou)
            return;

        // Diminui o tempo
        tempoRestante -= Time.deltaTime;

        // Impede que fique negativo
        if (tempoRestante < 0)
            tempoRestante = 0;

        AtualizarUI();

        // Se o tempo acabar
        if (tempoRestante <= 0)
        {
            Derrota();
        }
    }

    public void PegouLixo()
    {
        if (jogoTerminou)
            return;

        lixosPegos++;

        AtualizarUI();

        // Se pegou os 30 lixos
        if (lixosPegos >= totalDeLixos)
        {
            Vitoria();
        }
    }

    void AtualizarUI()
    {
        // Mostra os lixos
        textoLixos.text = "Lixos: " + lixosPegos + "/" + totalDeLixos;

        // Converte segundos para minutos
        int minutos = Mathf.FloorToInt(tempoRestante / 60);
        int segundos = Mathf.FloorToInt(tempoRestante % 60);

        textoTempo.text = string.Format("Tempo: {0:00}:{1:00}", minutos, segundos);
    }

    void Vitoria()
    {
        jogoTerminou = true;

        painelVitoria.SetActive(true);

        Time.timeScale = 0f;
    }

    void Derrota()
    {
        jogoTerminou = true;

        painelDerrota.SetActive(true);

        Time.timeScale = 0f;
    }
}