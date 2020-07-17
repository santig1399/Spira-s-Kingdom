using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPlacement : MonoBehaviour
{
    //public GameObject objToPlace;
    //public GameObject objToMove;
    [Header("Snapping")]
    public LayerMask groundMask;
    private Vector3 mousePos;
    public float cellSize;
    public ElementSize elementSize;
    public enum ElementSize
    {
        lowSize,
        mediumSize,
        largeSize 
    }

    [Header("Placement Colors")]
    public Color normalColor;
    public Color invalidColor;
    public Color correctColor;
    private Buildings build;
    //a manager should do this grid handling
    //public MeshRenderer render;
    //public Material matGrid, matDefault;

    private bool isDraggable = true;
    private SpriteRenderer sr;
    private bool isColapsingWith = false;
    private TestManager manager;

    public bool IsDraggable { get => isDraggable; set => isDraggable = value; }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        manager = FindObjectOfType<TestManager>();
        build = GetComponent<Buildings>();
    }


    void Update()
    {
        if (this.IsDraggable) {
            Move();
            if (Input.GetMouseButtonDown(0) && !isColapsingWith)
            {
                this.isDraggable = false;
                //sr.color = normalColor;
                manager.CurrentGo = null;
                build.IsReady = false;
            }
            else if (Input.GetMouseButtonDown(1)) {
                this.transform.Rotate(new Vector3(0, 0, -90));
            }
        }
        
    }

    private void Move()
    {
        mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
        {
            int posX = (int)Mathf.Round(hit.point.x);
            int posY = (int)Mathf.Round(hit.point.y);

            //for 32 px o 1 unity's world unit elements
            switch (elementSize)
            {
                case ElementSize.lowSize:
                    this.transform.position = new Vector3(posX, posY, 0f) + new Vector3(1, 1, 0) * 0.5f;
                    break;
                case ElementSize.mediumSize:
                    this.transform.position = new Vector3(posX , posY, 0f);
                    break;
                case ElementSize.largeSize:
                    this.transform.position = new Vector3(posX, posY , 0f);
                    break;
                default:
                    break;
            }
            

            //this.transform.position = new Vector3(posX, posY, 0f);
            if (isColapsingWith)
            {
               sr.color = invalidColor;
            }
            else
            {
                sr.color = correctColor;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isColapsingWith = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColapsingWith = false;
    }
}
