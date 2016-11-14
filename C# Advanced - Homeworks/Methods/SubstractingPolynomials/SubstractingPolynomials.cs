using System;
using System.Linq;

class SubstractingPolynomials
{
    private static int[] CalculatePolynomials(int[] firstPolynomial, int[] secondPolynomial, string operation)
    {
        int[] resultPolynomial = new int[firstPolynomial.Length];

        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            if (operation == "add")
            {
                resultPolynomial[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            else if (operation == "substract")
            {
                resultPolynomial[i] = firstPolynomial[i] - secondPolynomial[i];

            }
            else if (operation == "multiply")
            {
                resultPolynomial[i] = firstPolynomial[i] * secondPolynomial[i];

            }
        }


        return resultPolynomial;
    }
    static void Main()
    {
        int polynomialsSizes = int.Parse(Console.ReadLine());
        int[] firstPolynom = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int[] secondPolynom = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();


        int[] sumPolynomials = CalculatePolynomials(firstPolynom, secondPolynom,"add");
        int[] substractedPolynomials = CalculatePolynomials(firstPolynom, secondPolynom, "substract");
        int[] multipliedPolynomials = CalculatePolynomials(firstPolynom, secondPolynom, "multiply");

        Console.WriteLine(string.Join(" ", sumPolynomials));
        Console.WriteLine(string.Join(" ", substractedPolynomials));
        Console.WriteLine(string.Join(" ", multipliedPolynomials));


    }
}

