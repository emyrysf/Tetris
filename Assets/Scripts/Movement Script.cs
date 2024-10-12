using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    float prev;
    float fall = 0.6f;
    static int height = 20;
    static int width = 10;

    public static Transform[,] grid = new Transform [width, height];


    static public bool isGameOver = false;
    void Update()
    {
        if (MovementScript.grid[4, 18] != null)
        {
            isGameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
            {
             
                transform.position += new Vector3(1, 0, 0);
                if (!canMove())
                    transform.position -= new Vector3(1, 0, 0);
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
            
                transform.position += new Vector3(-1, 0, 0);
            if (!canMove())
                transform.position -= new Vector3(-1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (fall > 0.2f)
                    fall -= 0.15f;
            }

            if (Time.time - prev > fall)
            {
            
                transform.position += new Vector3(0, -1, 0);
                prev = Time.time;

            if (!canMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                Remember();
                RemoveLines();
                this.enabled = false;
                if(!isGameOver)
                    FindObjectOfType<Spawner>().Spawn();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1), 90);
            if (!canMove())
                transform.Rotate(new Vector3(0, 0, 1), -90);
        }
    }

    bool canMove()
    {   foreach (Transform child in transform)
        {
            int x = Mathf.FloorToInt(child.transform.position.x);
            int y = Mathf.FloorToInt(child.transform.position.y);
            if (x < 0 || y < 0 || x >= width)
            {
                return false;
            }

            if (grid[x, y]!= null) return false;
        }
        return true;
    }

    
    void Remember()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.FloorToInt(child.transform.position.x);
            int y = Mathf.FloorToInt(child.transform.position.y);

            grid[x,y] = child;
        }
    }

    void RemoveLines()
    {
        for(int i= height - 1; i >= 0; i--)
        {
            if (isLine(i))
            {
                Delete(i);
                Down(i);
                i--;
            }
        }
    }

    bool isLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            if (grid[j,i]==null)
            {
                return false;
            }
        }
        return true;
    }

    void Delete(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j,i].gameObject);
            grid[j,i] = null;

        }
        
    }
       
    void Down(int line)
    {
        for(int i=line;i< height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i > 0)
                {
                    grid[j, i - 1] = grid[j, i];
                    if (grid[j, i - 1] != null)
                        grid[j, i - 1].transform.position -= new Vector3(0, 1, 0);
                }
                 grid[j, i] = null;
                
            }
        }
    }

    
    

    
}
