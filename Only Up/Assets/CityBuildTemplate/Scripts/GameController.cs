using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameController : MonoBehaviour
{
    int floorMask;
    float camRayLenght = 500f;

    GameObject tempConstruct;
    bool boundarysAdded;
    bool block;
    [HideInInspector]
    public int buildSelected;
    GameObject mouseIndicator;
    public GameObject[] AllBuildings;
    [Space(10)]
    public Material[] boundaryColors;
    public int rotationGrade;
    [Space(10)]
    public GameObject constructStatus;
    bool deleteOn;
    public TextMeshProUGUI deleteButtonTxt;

    void Start()
    {
        floorMask = LayerMask.GetMask("Floor");

        mouseIndicator = Instantiate(AllBuildings[0]) as GameObject;
    }

    void Update()
    {
        DefineOnUI();
        ChangeButtonDeleteText();

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
        {
            mouseIndicator.transform.position = new Vector3(Mathf.RoundToInt(floorHit.point.x),
                Mathf.RoundToInt(floorHit.point.y),
                Mathf.RoundToInt(floorHit.point.z));
        }

        ConstructBuild();
        ChangeColorBoundarys();
        Unselect();
        DeleteBuild();
    }

    void InstanceBoundarysIndicator(Collider collider)
    {
        GameObject a = Instantiate(constructStatus) as GameObject;
        tempConstruct = a;
        a.transform.SetParent(mouseIndicator.transform);
        a.transform.localPosition = new Vector3(0f, 0f, 0f) + 
            AllBuildings[buildSelected].GetComponent<BuildingBase>().indicatorCorrection;
        a.transform.localScale = collider.bounds.size;
    }

    void SelectNewBuilding(int i)
    {
        Destroy(this.mouseIndicator);
        buildSelected = i;
        mouseIndicator = Instantiate(AllBuildings[i]) as GameObject;
        block = true;
    }

    public void SelectBuild(int buildNum)
    {
        deleteOn = false;
        boundarysAdded = false;
        buildSelected = buildNum;
        SelectNewBuilding(buildSelected);
    }

    public void TurnOnDeleteMode()
    {
        deleteOn = !deleteOn;
    }

    private void ChangeButtonDeleteText()
    {
        if (deleteOn)
        {
            deleteButtonTxt.text = "DeleteOn";
        }
        else
        {
            deleteButtonTxt.text = "DeleteOff";
        }
    }

    private void ChangeColorBoundarys()
    {
        if (mouseIndicator.GetComponent<BuildingBase>() != null && tempConstruct != null)
        {
            block = mouseIndicator.GetComponent<BuildingBase>().block;

            if (block && tempConstruct != null)
            {
                tempConstruct.GetComponent<Renderer>().material = boundaryColors[0];
            }
            else
            {
                tempConstruct.GetComponent<Renderer>().material = boundaryColors[1];
            }
        }
    }

    private void ConstructBuild()
    {
        if (buildSelected != 0)
        {
            Collider boundarys = mouseIndicator.GetComponent<Collider>();
            boundarys.isTrigger = true;

            if (!boundarysAdded)
            {
                InstanceBoundarysIndicator(boundarys);
                boundarysAdded = true;
            }

            if (Input.GetMouseButtonDown(0) && !DefineOnUI())
            {
                if (!block)
                {
                    boundarys.isTrigger = false;
                    Instantiate(AllBuildings[buildSelected], mouseIndicator.transform.position, mouseIndicator.transform.rotation);

                    mouseIndicator.transform.rotation = Quaternion.identity;
                    SelectNewBuilding(0);
                }

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                mouseIndicator.transform.Rotate(new Vector3(0f, rotationGrade, 0f));
            }

        }
    }

    private void Unselect()
    {
        if (Input.GetMouseButtonDown(1))
        {
            deleteOn = false;
            mouseIndicator.transform.rotation = Quaternion.identity;
            SelectNewBuilding(0);
        }
    }

    private void DeleteBuild()
    {
        if (deleteOn && buildSelected == 0)
        {
            if (Input.GetMouseButtonDown(0) && !DefineOnUI())
            {
                if (mouseIndicator.GetComponent<LookingIn>() != null &&
                    mouseIndicator.GetComponent<LookingIn>().looking != null)
                {
                    Destroy(mouseIndicator.GetComponent<LookingIn>().looking.gameObject);
                }
            }
        }
    }

    private bool DefineOnUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
