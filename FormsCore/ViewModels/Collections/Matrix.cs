using System;

public class Matrix: ViewItem
{
    public int n { get; set; } //кол-во строк
    public int m { get; set; } //кол-во столбцов
    public object[,] Items { get; set; }


    /// <summary>
    /// Получение транспонированной матрицы
    /// </summary>
    /// <returns></returns>
    public object[,] Transposition()
    {        
        object[,] transitioned = new object[m, n];        
        for (int i=0; i<n; i++)
        {            
            for (int j = 0; j < m; j++)
            {
                transitioned[j,i] = Items[i,j];
            }
        }
        return transitioned;
    }


    public Matrix() {

        Tag="table";

        var r = new Random();
        Items = new object[this.n = 3, this.m = 3];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Items[i, j] = Math.Floor(r.NextDouble() * 100);
            }
        }         
    }
}