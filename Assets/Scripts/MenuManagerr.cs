using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject painelMenu;
    public GameObject painelConfiguracao;
    public GameObject painelSobre;

    // Botão Jogar
    public void Jogar()
    {
        SceneManager.LoadScene("NomeDaCenaDoJogo");
    }

    // Configurações
    public void AbrirConfiguracao()
    {
        painelMenu.SetActive(false);
        painelConfiguracao.SetActive(true);
    }

    public void FecharConfiguracao()
    {
        painelConfiguracao.SetActive(false);
        painelMenu.SetActive(true);
    }

    // Sobre
    public void AbrirSobre()
    {
        painelMenu.SetActive(false);
        painelSobre.SetActive(true);
    }

    public void FecharSobre()
    {
        painelSobre.SetActive(false);
        painelMenu.SetActive(true);
    }
}