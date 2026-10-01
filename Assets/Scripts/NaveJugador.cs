using UnityEngine;
using UnityEngine.InputSystem;

public class NaveJugador : MonoBehaviour
{
    float vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vel = 30f;
    }

    // Update is called once per frame
    void Update()
    {
      MovimientoJugador();
    }

    void ControlLimitesPantalla()
    {
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(
            posicionActual.x,
            ValoresGlobales.limiteIzquierdoX,
            ValoresGlobales.LimiteDerechaX

        );
        posicionActual.y = Mathf.Clamp(
            posicionActual.y,
            ValoresGlobales.LimiteInferior,
            ValoresGlobales.LimiteSuperior
        );
        transform.position = posicionActual;
    }

    void MovimientoJugador()
    {
          //Miramos si jugador hace el movimiento horizontal, decidimos usar las teclas "A" y "D"
        float movimientoHorizontal = Keyboard.current.aKey.isPressed ? -1f : 
        Keyboard.current.dKey.isPressed ? 1f : 0f;

        float movimientioVertical = Keyboard.current.sKey.isPressed ? -1f :
        Keyboard.current.wKey.isPressed ? 1f : 0f;

        //Vector3 tiene tres componentes o números: el "x", el "y" y el "z". El orden es (x,y,z)
        Vector3 vectorDesplazamiento = new Vector3(movimientoHorizontal, movimientioVertical, 0f);

        //Para asegurarnos de que la dirección no afecta la velocidad, normalizamos el vector desplzamiento
        vectorDesplazamiento = vectorDesplazamiento.normalized;

        //Movemos el objeto según: 1) la dirección (vectorDesplazamiento), 2) la velocidad (vel)
        Vector3 nuevoDesplazamiento = new Vector3 ( 
            vel * vectorDesplazamiento.x * Time.deltaTime,
            vel * vectorDesplazamiento.y * Time.deltaTime,
            0f
        );
        transform.position += nuevoDesplazamiento;
    }
}


