using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
     public void Chuyenmap2()
    {
        SceneManager.LoadScene("Map2");
    }
    public void Chuyenmap3()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Chuyenmap1()
    {
        SceneManager.LoadScene("Snow Terrain");
    }
    public void starttt()
    {
        SceneManager.LoadScene("Map");
    }
}
