using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    public float velocitàRotazione;
    public float attritoRotazione; //Più è basso, più c'è attrito. Lascia as 1 [testato]
    public float attenuamentoRotazione;

    private float movimentoInput;
    private Quaternion Quaternion_Ruota_Da;
    private Quaternion Quaternion_Ruota_A;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Mouse X");

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.touches[0];
            h = touch.deltaPosition.x;

            movimentoInput += h * velocitàRotazione * attritoRotazione;
            movimentoInput = Mathf.Clamp(movimentoInput, -43, 43); //costringe il valore della rotazione tra il min e il max
            Quaternion_Ruota_Da = transform.rotation;
            Quaternion_Ruota_A = Quaternion.Euler(0, 0, movimentoInput);

            transform.rotation = Quaternion.Lerp(Quaternion_Ruota_Da, Quaternion_Ruota_A, Time.deltaTime * attenuamentoRotazione);
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            movimentoInput = 0f;
            movimentoInput = Mathf.Clamp(movimentoInput, -43, 43); //costringe il valore della rotazione tra il min e il max
            Quaternion_Ruota_Da = transform.rotation;
            Quaternion_Ruota_A = Quaternion.Euler(0, 0, movimentoInput);

            transform.rotation = Quaternion.Lerp(Quaternion_Ruota_Da, Quaternion_Ruota_A, Time.deltaTime * attenuamentoRotazione);
        }

        /*movimentoInput += h * velocitàRotazione * attritoRotazione;
        movimentoInput = Mathf.Clamp(movimentoInput, -43, 43); //costringe il valore della rotazione tra il min e il max
        Quaternion_Ruota_Da = transform.rotation;
        Quaternion_Ruota_A = Quaternion.Euler(0, 0, movimentoInput);

        transform.rotation = Quaternion.Lerp(Quaternion_Ruota_Da, Quaternion_Ruota_A, Time.deltaTime * attenuamentoRotazione);
        */
    }

}

