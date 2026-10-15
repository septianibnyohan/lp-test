// See https://aka.ms/new-console-template for more information
Console.Write("Soal 4 Input : ");


// Soal 4

String input = Console.ReadLine();

// Creating a dictionary
Dictionary<char, int> charCount = new Dictionary<char, int>();

for (int i = 0; i < input.Length; i++)
{
    input = input.Replace(" ", "");

    if (charCount.ContainsKey(input[i]))
    {
        charCount[input[i]]++;
    }
    else
    {
        charCount.Add(input[i], 1);
    }
}

// Displaying dictionary
Console.WriteLine("Output :");
foreach (var ele in charCount)
{
    Console.WriteLine($"{ele.Key} - {ele.Value}");
}

Console.Write("Soal 5 Input : ");
String input5 = Console.ReadLine();

int nElement = Convert.ToInt32(input5);



List<String> output = new List<String>();
for (int i = 1; i <= nElement;i++)
{
    if (i != 5 && ( i % 5 == 0 ) )
    {
        output.Add("IDIC");
    }
    else if (i != 6 && (i % 6 == 0))
    {
        output.Add("LPS");
    }
    else
    {
        output.Add(i.ToString());
    }
}

Console.WriteLine("Output :");
Console.WriteLine(String.Join(" ", output.ToArray()));