using System;
using System.Collections.Generic;


/// <summary>
/// Модель матричных форм
/// </summary>
public class MatrixModel<T>
{        
    private int m; 
    private int n;
    private T[,] data;

    public MatrixModel(int m, int n)
    {
        this.m = m;
        this.n = n;
        this.data = new T[m, n];
    }    


    /// <summary>
    /// Обход слева-направо, сверху-вниз
    /// </summary>
    /// <param name="forItem"></param>
    public void ToDo( Action<T,int,int> forItem )
    {
        for (var i = 0; i < this.m; i++)
        {
            for (var j = 0; j < this.n; j++)
            {
                forItem(data[i, j],i,j);
            }
        }
    }
}




/// <summary>
/// Функции работы с матрицами приложения
/// </summary>
public class MatrixService
{

    /// <summary>
    /// Обратная матрица
    /// </summary>
    public MatrixModel<T> Inverse<T>(MatrixModel<T> primary )
    {

        throw new NotImplementedException();
    }

     public string[] Rec(int countOfColumns)
     {
        var list = new List<string>();
        for(int i=1; i<= countOfColumns; i++)
        {
            list.Add("№"+i.ToString());
        }
        return list.ToArray();
     }
}