using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// клас для об'єктів ігрового поля, для впорядкування
public class Cube: MonoBehaviour
{
    BoxCollider col;
    public Manager manager;
    public int number;
    public int numberCell;



    // Start is called before the first frame update
    void Start()
    {
        //manager = new Manager();
        col = GetComponent<BoxCollider>();
    }

    // обробка події при натисканні на ігровий елемент головоломки.
    private void OnMouseDown()
    { 
        // визначення вілкого місця(в якому напрямку перемістити клітинку)
        if (!manager.isWin)
        {
            col.enabled = false;
            RaycastHit hit;

            if (!Physics.Linecast(transform.position, transform.position + transform.right, out hit))
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position + -transform.right, out hit))
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position + transform.forward, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            }
            else if (!Physics.Linecast(transform.position, transform.position + -transform.forward, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            }
            col.enabled = true;
        }
    }


    // при потраплянні на тригери перевірка умови виграшу.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger")
        {
            numberCell = other.transform.GetComponent<NumberCell>().numberCell;
            manager.win();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
