using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigbody;    // "Fyzika" těla hráče
    public static float movementSpeed = 5;     // jeho rychlost pohybu (zde je developer hodnota, reálná hodnota je u play v main menu)
    private Vector2 finalMovement;          // celkový vypočítaný vektor pohybu
    private float playerAngle;              // proměnná pro úhel pohledu hráče
    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();          // dynamicky najde na komponentě (hráči) rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        finalMovement.x = Input.GetAxisRaw("Horizontal");           // získá vstup z klávesnice a převede jej na pohyb na ose x
        finalMovement.y = Input.GetAxisRaw("Vertical");             // získá vstup z klávesnice a převede jej na pohyb na ose y
        Vector3 mousePos = Input.mousePosition;                     // vezme pozici myši
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);        // transformuje pozici myši na souřadnice ve hře
        mousePos.x -= rigbody.position.x;                           // odečte pozici hráče od pozice myši pro udání správného vektoru
        mousePos.y -= rigbody.position.y;                           // odečte pozici hráče od pozice myši pro udání správného vektoru
        playerAngle = (Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg) - 90;       // vrátí úhel hráče ku myši, -90 je pro dorovnání úhlu


        // Vector2 finalMovement = new Vector2(movementHorizontal, movementVertical);
    }

    void FixedUpdate()
    {
        rigbody.MovePosition(rigbody.position + finalMovement.normalized * movementSpeed * Time.fixedDeltaTime);       // posune tělo na danou pozici, fixedDeltaTime pro konstantní rychlost pohybu, normalized umožní stejnou rychlost pohybu diagonálně jako vertikálně/horizontálně
        rigbody.SetRotation(playerAngle);               // nastaví rotaci hráče podle vypočítaného úhlu
    }
}
