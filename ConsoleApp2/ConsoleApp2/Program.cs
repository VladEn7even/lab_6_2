using System;

public class MathOperations
{
    // Перевантажений метод додавання для чисел
    public static T Add<T>(T a, T b)
    {
        dynamic x = a;
        dynamic y = b;
        return x + y;
    }

    // Перевантажений метод додавання для масивів
    public static T[] Add<T>(T[] arr1, T[] arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            throw new ArgumentException("Arrays must have the same length");
        }

        var result = new T[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = Add(arr1[i], arr2[i]);
        }

        return result;
    }

    // Перевантажений метод додавання для матриць
    public static T[,] Add<T>(T[,] matrix1, T[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
        {
            throw new ArgumentException("Matrices must have the same dimensions");
        }

        var result = new T[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = Add(matrix1[i, j], matrix2[i, j]);
            }
        }

        return result;
    }

    // Перевантажений метод додавання для тензорів (припустимо, що тензор - це тривимірний масив)
    public static T[,,] Add<T>(T[,,] tensor1, T[,,] tensor2)
    {
        int dim1 = tensor1.GetLength(0);
        int dim2 = tensor1.GetLength(1);
        int dim3 = tensor1.GetLength(2);

        if (dim1 != tensor2.GetLength(0) || dim2 != tensor2.GetLength(1) || dim3 != tensor2.GetLength(2))
        {
            throw new ArgumentException("Tensors must have the same dimensions");
        }

        var result = new T[dim1, dim2, dim3];
        for (int i = 0; i < dim1; i++)
        {
            for (int j = 0; j < dim2; j++)
            {
                for (int k = 0; k < dim3; k++)
                {
                    result[i, j, k] = Add(tensor1[i, j, k], tensor2[i, j, k]);
                }
            }
        }

        return result;
    }

    // Аналогічно можна реалізувати інші перевантажені методи для віднімання, множення, тощо.
}

class Program
{
    static void Main()
    {
        // Приклад використання
        int a = 5, b = 10;
        Console.WriteLine($"Addition of {a} and {b}: {MathOperations.Add(a, b)}");

        double[] arr1 = { 1.5, 2.5, 3.5 };
        double[] arr2 = { 0.5, 1.5, 2.5 };
        Console.WriteLine($"Array Addition: [{string.Join(", ", MathOperations.Add(arr1, arr2))}]");

        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        Console.WriteLine("Matrix Addition:");
        PrintMatrix(MathOperations.Add(matrix1, matrix2));

        // Аналогічно для тензорів і інших операцій
    }

    static void PrintMatrix<T>(T[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
