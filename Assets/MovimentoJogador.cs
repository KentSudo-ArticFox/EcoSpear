using UnityEngine;

public class MovimentacaoPlayer : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 8f; // pulo mais alto
    public float gravidade = -9.81f; // gravidade simulada

    [Header("Configurações de Mouse")]
    public float sensibilidadeMouse = 2f;

    [Header("Referências")]
    public Transform cameraJogador; // arraste a câmera aqui

    private CharacterController controller;
    private float rotacaoX = 0f;
    private Vector3 velocidadeVertical;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // --- Rotação com o mouse ---
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        cameraJogador.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // --- Movimento com WASD ---
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direcao = transform.right * x + transform.forward * z;
        controller.Move(direcao * velocidade * Time.deltaTime);

        // --- Pulo e gravidade ---
        if (controller.isGrounded)
        {
            velocidadeVertical.y = -1f; // mantém no chão

            if (Input.GetButtonDown("Jump"))
            {
                velocidadeVertical.y = forcaPulo; // pulo alto
            }
        }
        else
        {
            velocidadeVertical.y += gravidade * Time.deltaTime;
        }

        controller.Move(velocidadeVertical * Time.deltaTime);
    }
}