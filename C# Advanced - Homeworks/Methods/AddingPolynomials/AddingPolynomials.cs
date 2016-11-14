using System;
using System.Linq;

class AddingPolynomials
{
    private static int[] AddPolynomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int[] resultPolynomial = new int[firstPolynomial.Length];

        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            resultPolynomial[i] = firstPolynomial[i] + secondPolynomial[i];
        }


        return resultPolynomial;
    }
    static void Main()
    {
        int polyNomialsSizes = int.Parse(Console.ReadLine());
        int[] firstPolynom = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int[] secondPolynom = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();


        int[] resultPolynomila = AddPolynomials(firstPolynom, secondPolynom);

        Console.WriteLine(string.Join(" ",resultPolynomila));
    }
}

