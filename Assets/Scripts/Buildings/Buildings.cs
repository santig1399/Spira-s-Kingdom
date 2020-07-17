using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    public int foodAmmount;
    public int maxPopulation;
    private int currentPopulation;
    public float startBuildingTime;
    [SerializeField]
    private float buildingTime;
    [SerializeField]
    private bool isReady = true;

    private SpriteRenderer sr;
    public Color buildingColor;
    public Color normalColor;

    public bool IsReady { get => isReady; set => isReady = value; }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        buildingTime = startBuildingTime;
    }

   
    void Update()
    {
        if (!IsReady) {
            Build();
        }
    }

    private void Build() {
        if (buildingTime > 0)
        {
            buildingTime -= Time.deltaTime;
            sr.color = buildingColor;
        }
        else if (buildingTime <= 0)
        {
            sr.color = normalColor;
        }
    }
}
