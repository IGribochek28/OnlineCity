using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Found : MonoBehaviour
{
    public GameObject Ghost1, Ghost2, Ghost3, Ghost4, Ghost5, Ghost6, Ghost7;
    public GameObject sGhost1, sGhost2, sGhost3, sGhost4, sGhost5, sGhost6, sGhost7;

    public GameObject Portal;

    public GameObject FindGem, FindPortal;
    private int SS = 0;

    void Start()
    {
        SS = 0;
        Ghost1.SetActive(false); Ghost2.SetActive(false); Ghost3.SetActive(false); Ghost4.SetActive(false);
        Ghost5.SetActive(false); Ghost6.SetActive(false); Ghost7.SetActive(false);
        FindGem.SetActive(true); FindPortal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SS > 1)
        {
            Ghost1.SetActive(true);
        }
        if (SS > 2) 
        { 
            Ghost2.SetActive(true); Ghost3.SetActive(true);
        }
        if (SS > 4)
        {
            Ghost4.SetActive(true);
        }
        if (SS > 5)
        {
            Ghost5.SetActive(true); Ghost6.SetActive(true);
        }
        if (SS > 7)
        {
            Ghost7.SetActive(true);
        }
        if(SS == 8)
        {
            Portal.SetActive(true);
            FindGem.SetActive(false); FindPortal.SetActive(true);
            sGhost1.SetActive(false); sGhost2.SetActive(false); sGhost3.SetActive(false); sGhost4.SetActive(false); sGhost5.SetActive(false); sGhost6.SetActive(false); sGhost7.SetActive(false);
            Ghost1.SetActive(false); Ghost2.SetActive(false); Ghost3.SetActive(false); Ghost4.SetActive(false); Ghost5.SetActive(false); Ghost6.SetActive(false); Ghost7.SetActive(false);
        }
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(3);
        }

        if (col.gameObject.CompareTag("SoulStone"))
        {
            Destroy(col.gameObject);
            SS++;
        }
        
        if (col.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene(3);

        }
    }
}
