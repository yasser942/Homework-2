using System;
using System.IO;



public class colorsor_game
{
    public class Score //parameters of the scores table for each line
    {
        public string key;
        public int value;
    }
    static void sorting() // this method sorts the names and their scores 
    {
        string path = "D:\\HighScoreTable.txt";
        string[] lines = File.ReadAllLines(path);
        Score[] scores = new Score[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            var newLine = line.Split(';');
            scores[i] = new Score { key = newLine[0], value = int.Parse(newLine[1]) };
        }
        scores = sort(scores);
        StreamWriter document = new StreamWriter(path);
        for (int i = 0; i < 10; i++)
        {
            document.Write(scores[i].key + ";" + scores[i].value + "\n");
        }
        document.Close();
    }
    public static Score[] sort(Score[] scores)
    {
        for (int i = 0; i < scores.Length; i++)
        {
            var temp = scores[i];
            for (int j = i + 1; j <= scores.Length - 1; j++)
            {
                if (scores[j].value > temp.value)
                {
                    var biggerValuer = scores[j];
                    scores[i] = biggerValuer;
                    scores[j] = temp;
                    temp = biggerValuer;
                }
            }
        }
        return scores;
    }
    static void Main(string[] args)
    {
        StreamWriter document = File.AppendText("D:\\HighScoreTable.txt");
        bool play = true;
        while (play == true)
        {
            int counter1 = 0;// counter 1 ,2,3 to randomize the array vertically. 
            int counter2 = 1;
            int counter3 = 2;
            int result = 0; // the final points that user has got.
            int line_skip = 0;//to randomize the array vertically
            int points = 0;// gives points in each case of leters and colors
            Random rand = new Random();
            //I have used 36 letters to have the same chance of showing each letter during randomizing the array.
            string[] items = new string[] { "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", };
            string[] letters = new string[9];// this has only the 9 randomized letters to be showen for user.
            int[] colors = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 };// this for colors.
            //randomizing letters
            for (int i = 0; i < items.Length; i++)
            {
                int j = rand.Next(i, items.Length);
                string temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
            //randomizing colors.
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < colors.Length; k++)
                {
                    int c = rand.Next(k, colors.Length);
                    int temp = colors[k];
                    colors[k] = colors[c];
                    colors[c] = temp;
                }
                letters[i] = items[i];
            }
            Console.WriteLine("Welcome to Colors Game ");
            Console.Write("Generated array : ");// showing the generated array after coloring
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (colors[i] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (colors[i] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(letters[i] + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
            for (int w = 0; w < letters.Length; w++)// sorting the letters vertically and giving the suitable points for each case
            {
                if (line_skip == 3)
                {
                    if ((items[counter1] == letters[counter2] & letters[counter1] == letters[counter3]) & (colors[counter1] == colors[counter2] & colors[counter1] == colors[counter3]))
                    {
                        points = 33;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if ((items[counter1] == letters[counter2] & letters[counter1] == letters[counter3]) & ((colors[counter1] != colors[counter2] & colors[counter1] != colors[counter3]) & (colors[counter2] != colors[counter3])))
                    {
                        points = 28;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if ((items[counter1] == letters[counter2] & letters[counter1] == letters[counter3]) & ((colors[counter1] == colors[counter2] & colors[counter1] != colors[counter3]) | (colors[counter1] != colors[counter2] & colors[counter1] == colors[counter3]) | (colors[counter1] != colors[counter2] & colors[counter2] == colors[counter3])))
                    {
                        points = 22;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((items[counter1] != letters[counter2] & letters[counter1] != letters[counter3]) & (letters[counter2] != letters[counter3]) & (colors[counter1] == colors[counter2] & colors[counter1] == colors[counter3])))
                    {
                        points = 18;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((items[counter1] != letters[counter2] & letters[counter1] != letters[counter3]) & (letters[counter2] != letters[counter3])) & ((colors[counter1] != colors[counter2] & colors[counter1] != colors[counter3]) & (colors[counter2] != colors[counter3])))
                    {
                        points = 16;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((items[counter1] != letters[counter2] & letters[counter1] != letters[counter3]) & (letters[counter2] != letters[counter3])) & ((colors[counter1] == colors[counter2] & colors[counter1] != colors[counter3]) | (colors[counter1] != colors[counter2] & colors[counter1] == colors[counter3]) | (colors[counter1] != colors[counter2] & colors[counter2] == colors[counter3])))
                    {
                        points = 14;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((items[counter1] != letters[counter2] & letters[counter1] != letters[counter3]) & (letters[counter2] != letters[counter3])) & (colors[counter1] == colors[counter2] & colors[counter1] == colors[counter3]))
                    {
                        points = 12;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((letters[counter1] == letters[counter2] & letters[counter1] != letters[counter3]) | (letters[counter1] != letters[counter2] & letters[counter1] == letters[counter3]) | (letters[counter1] != letters[counter2] & letters[counter2] == letters[counter3])) & ((colors[counter1] != colors[counter2] & colors[counter1] != colors[counter3]) & (colors[counter2] != colors[counter3])))
                    {
                        points = 10;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else
                    {
                        Console.Write("   " + points + "     ");
                    }
                    Console.WriteLine();
                    w -= 2;
                    line_skip = 0;
                    points = 0;
                    counter1++;
                    counter2++;
                    counter3++;
                }
                if (colors[w] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (colors[w] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (colors[w] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(letters[w] + " ");
                line_skip++;
                Console.ResetColor();
                if (w == 8)
                {
                    if ((items[counter1] == letters[counter2] & letters[counter1] == letters[counter3]) & (colors[counter1] == colors[counter2] & colors[counter1] == colors[counter3]))
                    {
                        points = 33;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if ((items[counter1] == letters[counter2] & letters[counter1] == letters[counter3]) & ((colors[counter1] != colors[counter2] & colors[counter1] != colors[counter3]) & (colors[counter2] != colors[counter3])))
                    {
                        points = 28;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if ((items[counter1] == letters[counter2] & letters[counter1] == letters[counter3]) & ((colors[counter1] == colors[counter2] & colors[counter1] != colors[counter3]) | (colors[counter1] != colors[counter2] & colors[counter1] == colors[counter3]) | (colors[counter1] != colors[counter2] & colors[counter2] == colors[counter3])))
                    {
                        points = 22;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((items[counter1] != letters[counter2] & letters[counter1] != letters[counter3]) & (letters[counter2] != letters[counter3]) & (colors[counter1] == colors[counter2] & colors[counter1] == colors[counter3])))
                    {
                        points = 18;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((items[counter1] != letters[counter2] & letters[counter1] != letters[counter3]) & (letters[counter2] != letters[counter3])) & ((colors[counter1] != colors[counter2] & colors[counter1] != colors[counter3]) & (colors[counter2] != colors[counter3])))
                    {
                        points = 16;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((items[counter1] != letters[counter2] & letters[counter1] != letters[counter3]) & (letters[counter2] != letters[counter3])) & ((colors[counter1] == colors[counter2] & colors[counter1] != colors[counter3]) | (colors[counter1] != colors[counter2] & colors[counter1] == colors[counter3]) | (colors[counter1] != colors[counter2] & colors[counter2] == colors[counter3])))
                    {
                        points = 14;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((items[counter1] != letters[counter2] & letters[counter1] != letters[counter3]) & (letters[counter2] != letters[counter3])) & (colors[counter1] == colors[counter2] & colors[counter1] == colors[counter3]))
                    {
                        points = 12;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else if (((letters[counter1] == letters[counter2] & letters[counter1] != letters[counter3]) | (letters[counter1] != letters[counter2] & letters[counter1] == letters[counter3]) | (letters[counter1] != letters[counter2] & letters[counter2] == letters[counter3])) & ((colors[counter1] != colors[counter2] & colors[counter1] != colors[counter3]) & (colors[counter2] != colors[counter3])))
                    {
                        points = 10;
                        result += points;
                        Console.Write("   " + points + "     ");
                    }
                    else
                    {
                        Console.Write("   " + points + "     ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("You have got : " + result + " ponits !!");
            Console.WriteLine("Do you want to play again ? Y or N");
            string answer = Console.ReadLine().ToLower();
            if (answer != "y" & answer != "n")
            {
                while (answer != "y" & answer != "n")
                {
                    Console.WriteLine("Try Y or N");
                    answer = Console.ReadLine().ToLower();
                    if (answer == "y" & answer == "n")
                        break;
                }
            }
            if (answer == "y")
            {
                play = true;
                Console.WriteLine("Done");
            }
            else if (answer == "n")
            {
                play = false;
                Console.WriteLine("Please enter your name :");
                string playerName = Console.ReadLine();

                document.WriteLine(playerName + ";" + result);
                document.Close();
                sorting();
                StreamReader documentR = File.OpenText("D:\\HighScoreTable.txt");
                document.Close();
                for (int k = 0; k < 10; k++)//showing the score table after sorting.
                {
                    Console.WriteLine(documentR.ReadLine());
                }
                documentR.Close();
            }
        }
    }
}
