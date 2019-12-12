using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigbody;    // "Fyzika" těla hráče
    public float movementSpeed;     // jeho rychlost pohybu
    private Vector2 finalMovement;          // celkový vypočítaný vektor pohybu
    private float playerAngle;
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
        mousePos.x -= rigbody.position.x;                           // vycentruje pozici na hráče na ose x
        mousePos.y -= rigbody.position.y;                           // vycentruje pozici na hráče na ose y
        playerAngle = (Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg) - 90;       // vrátí úhel hráče ku myši, -90 je pro dorovnání úhlu


        // Vector2 finalMovement = new Vector2(movementHorizontal, movementVertical);
    }

    void FixedUpdate()
    {
        rigbody.MovePosition(rigbody.position + finalMovement.normalized * movementSpeed * Time.fixedDeltaTime);       // posune tělo na danou pozici, fixedDeltaTime pro konstantní rychlost pohybu, normalized umožní stejnou rychlost pohybu diagonálně jako vertikálně/horizontálně
        rigbody.SetRotation(playerAngle);               // nastaví rotaci hráče podle vypočítaného úhlu
    }
}
