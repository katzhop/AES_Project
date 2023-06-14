using System;

namespace AES_Project
{

    class Program
    {
        public static string[,] AES = new string[,]{
  {"63","7c","77","7b","f2","6b","6f","c5","30","01","67","2b","fe","d7","ab","76"},
    {"ca","82","c9","7d","fa","59","47","f0","ad","d4","a2","af","9c","a4","72","c0"},
    {"b7","fd","93","26","36","3f","f7","cc","34","a5","e5","f1","71","d8","31","15"},
    {"04","c7","23","c3","18","96","05","9a","07","12","80","e2","eb","27","b2","75"},
    {"09","83","2c","1a","1b","6e","5a","a0","52","3b","d6","b3","29","e3","2f","84"},
    {"53","d1","00","ed","20","fc","b1","5b","6a","cb","be","39","4a","4c","58","cf"},
    {"d0","ef","aa","fb","43","4d","33","85","45","f9","02","7f","50","3c","9f","a8"},
    {"51","a3","40","8f","92","9d","38","f5","bc","b6","da","21","10","ff","f3","d2"},
    {"cd","0c","13","ec","5f","97","44","17","c4","a7","7e","3d","64","5d","19","73"},
    {"60","81","4f","dc","22","2a","90","88","46","ee","b8","14","de","5e","0b","db"},
    {"e0","32","3a","0a","49","06","24","5c","c2","d3","ac","62","91","95","e4","79"},
    {"e7","c8","37","6d","8d","d5","4e","a9","6c","56","f4","ea","65","7a","ae","08"},
    {"ba","78","25","2e","1c","a6","b4","c6","e8","dd","74","1f","4b","bd","8b","8a"},
    {"70","3e","b5","66","48","03","f6","0e","61","35","57","b9","86","c1","1d","9e"},
    {"e1","f8","98","11","69","d9","8e","94","9b","1e","87","e9","ce","55","28","df"},
    {"8c","a1","89","0d","bf","e6","42","68","41","99","2d","0f","b0","54","bb","16"}
  };

        public static string[,] InverseAES = new string[,] {
    {"52","09","6a","d5","30","36","a5","38","bf","40","a3","9e","81","f3","d7","fb"},
    {"7c","e3","39","82","9b","2f","ff","87","34","8e","43","44","c4","de","e9","cb"},
    {"54","7b","94","32","a6","c2","23","3d","ee","4c","95","0b","42","fa","c3","4e"},
    {"08","2e","a1","66","28","d9","24","b2","76","5b","a2","49","6d","8b","d1","25"},
    {"72","f8","f6","64","86","68","98","16","d4","a4","5c","cc","5d","65","b6","92"},
    {"6c","70","48","50","fd","ed","b9","da","5e","15","46","57","a7","8d","9d","84"},
    {"90","d8","ab","00","8c","bc","d3","0a","f7","e4","58","05","b8","b3","45","06"},
    {"d0","2c","1e","8f","ca","3f","0f","02","c1","af","bd","03","01","13","8a","6b"},
    {"3a","91","11","41","4f","67","dc","ea","97","f2","cf","ce","f0","b4","e6","73"},
    {"96","ac","74","22","e7","ad","35","85","e2","f9","37","e8","1c","75","df","6e"},
    {"47","f1","1a","71","1d","29","c5","89","6f","b7","62","0e","aa","18","be","1b"},
    {"fc","56","3e","4b","c6","d2","79","20","9a","db","c0","fe","78","cd","5a","f4"},
    {"1f","dd","a8","33","88","07","c7","31","b1","12","10","59","27","80","ec","5f"},
    {"60","51","7f","a9","19","b5","4a","0d","2d","e5","7a","9f","93","c9","9c","ef"},
    {"a0","e0","3b","4d","ae","2a","f5","b0","c8","eb","bb","3c","83","53","99","61"},
    {"17","2b","04","7e","ba","77","d6","26","e1","69","14","63","55","21","0c","7d"}
  };

        public static int[,] Mix = new int[,] { { 2, 3, 1, 1 }, { 1, 2, 3, 1 }, { 1, 1, 2, 3 }, { 3, 1, 1, 2 } };

        public static char[,] InverseMix = new char[,] { { 'e', 'b', 'd', '9' }, { '9', 'e', 'b', 'd' }, 
            { 'd', '9', 'e', 'b' }, { 'b', 'd', '9', 'e' } };

        public static string[] Rcon = { "00000000", "00000001", "00000010", "00000100", "00001000", 
            "00010000", "00100000", "01000000", "10000000", "00011011", "00110110" };

        public static void Substitution(string[] s)
        {
            for (int i = 0; i < 16; i++)
            {
                //looks at both positions in each byte
                int[] pos = new int[2];
                for (int k = 0; k < 2; k++)
                {
                    if (s[i].Substring(k, 1) == "a")
                    {
                        pos[k] = 10;
                    }
                    else if (s[i].Substring(k, 1) == "b")
                    {
                        pos[k] = 11;
                    }
                    else if (s[i].Substring(k, 1) == "c")
                    {
                        pos[k] = 12;
                    }
                    else if (s[i].Substring(k, 1) == "d")
                    {
                        pos[k] = 13;
                    }
                    else if (s[i].Substring(k, 1) == "e")
                    {
                        pos[k] = 14;
                    }
                    else if (s[i].Substring(k, 1) == "f")
                    {
                        pos[k] = 15;
                    }
                    else
                    {
                        pos[k] = int.Parse(s[i].Substring(k, 1));
                    }
                }
                s[i] = AES[pos[0], pos[1]];
            }
        }

        public static void Inverse(string[] s)
        {
            for (int i = 0; i < 4; i++)
            {
                //looks at both positions in each byte
                int[] pos = new int[2];
                for (int k = 0; k < 2; k++)
                {
                    if (s[i].Substring(k, 1) == "a")
                    {
                        pos[k] = 10;
                    }
                    else if (s[i].Substring(k, 1) == "b")
                    {
                        pos[k] = 11;
                    }
                    else if (s[i].Substring(k, 1) == "c")
                    {
                        pos[k] = 12;
                    }
                    else if (s[i].Substring(k, 1) == "d")
                    {
                        pos[k] = 13;
                    }
                    else if (s[i].Substring(k, 1) == "e")
                    {
                        pos[k] = 14;
                    }
                    else if (s[i].Substring(k, 1) == "f")
                    {
                        pos[k] = 15;
                    }
                    else
                    {
                        pos[k] = int.Parse(s[i].Substring(k, 1));
                    }
                }
                s[i] = InverseAES[pos[0], pos[1]];
            }
        }

        public static void Shift(string[] s)
        {
            string temp = s[4];
            s[4] = s[5];
            s[5] = s[6];
            s[6] = s[7];
            s[7] = temp;
            temp = s[8];
            s[8] = s[10];
            s[10] = temp;
            temp = s[9];
            s[9] = s[11];
            s[11] = temp;
            temp = s[15];
            s[15] = s[14];
            s[14] = s[13];
            s[13] = s[12];
            s[12] = temp;
        }
        public static void MixColumns(string[,] s)
        {
            string[,] binary = new string[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    binary[i, j] = getBinary(s[i, j]);
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string[] needToXOR = new string[4];
                    for (int k = 0; k < 4; k++)
                    {
                        int multiplier = Mix[i, k];
                        string nS = binary[k, j];
                        if (multiplier != 1)
                        {
                            nS += "0";
                            if (nS.Substring(0, 1) == "1")
                            {
                                nS = XOR(nS, "100011011");
                            }
                            nS = nS.Substring(1);
                            if (multiplier == 3)
                            {
                                needToXOR[k] = XOR(nS, binary[k, j]);
                            }
                            else
                            {
                                needToXOR[k] = nS;
                            }
                        }
                        else
                        {
                            needToXOR[k] = nS;
                        }
                    }
                    string XORed = XOR(needToXOR[0], needToXOR[1]);
                    XORed = XOR(XORed, needToXOR[2]);
                    XORed = XOR(XORed, needToXOR[3]);
                    s[i, j] = getHex(XORed);
                }
            }
        }
        public static void InverseMixColumns(string[,] s)
        {
            string[,] binary = new string[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    binary[i, j] = getBinary(s[i, j]);
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string[] needToXOR = new string[4];
                    for (int k = 0; k < 4; k++)
                    {
                        string nS = "";
                        if (InverseMix[i, k] == '9')
                        {
                            nS = XOR(binary[k, j] + "000", "000" + binary[k, j]);

                        }
                        else if (InverseMix[i, k] == 'e')
                        {
                            nS = XOR("0" + binary[k, j] + "0", binary[k, j] + "00");
                            nS = XOR("0" + nS, binary[k, j] + "000");

                        }
                        else if (InverseMix[i, k] == 'b')
                        {
                            nS = XOR("00" + binary[k, j] + "0", binary[k, j] + "000");
                            nS = XOR(nS, "000" + binary[k, j]);


                        }
                        else if (InverseMix[i, k] == 'd')
                        {
                            nS = XOR("0" + binary[k, j] + "00", binary[k, j] + "000");
                            nS = XOR(nS, "000" + binary[k, j]);

                        }
                        while (nS.Substring(0, 1) == "0" && nS.Length > 8)
                        {
                            nS = nS.Substring(1);
                        }
                        while (nS.Length - 8 > 0)
                        {
                            string GF = "100011011";

                            int extra = nS.Length - 8;
                            for (int x = 0; x < extra; x++)
                            {
                                GF += "0";
                            }
                            nS = XOR(nS, GF);
                            while (nS.Substring(0, 1) == "0" && nS.Length > 8)
                            {
                                nS = nS.Substring(1);
                            }
                        }
                        needToXOR[k] = nS;
                    }
                    string XORed = XOR(needToXOR[0], needToXOR[1]);
                    XORed = XOR(XORed, needToXOR[2]);
                    XORed = XOR(XORed, needToXOR[3]);
                    s[i, j] = getHex(XORed);
                }
            }
        }

        public static void keyExpansion(string[] key, string[,] w)
        {
            string[] temp = new string[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    w[i, j] = getBinary(key[4 * i + j]);
                }
            }
            for (int i = 4; i < 44; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp[j] = w[i - 1, j];

                }
                if (i % 4 == 0)
                {
                    temp = SubWord(RotWord(temp));
                    temp[0] = XOR(temp[0], Rcon[i / 4]);
                }
                for (int j = 0; j < 4; j++)
                {
                    w[i, j] = XOR(w[i - 4, j], temp[j]);

                }
            }
            for (int i = 0; i < 44; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    w[i, j] = getHex(w[i, j]);
                }
            }
        }

        public static string[] RotWord(string[] s)
        {
            string[] nS = new string[4];
            nS[0] = getHex(s[1]);
            nS[1] = getHex(s[2]);
            nS[2] = getHex(s[3]);
            nS[3] = getHex(s[0]);
            return nS;
        }

        public static string[] SubWord(string[] s)
        {
            string[] sub = new string[4];
            //looks at both positions in the byte
            int[] pos = new int[2];
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 2; k++)
                {
                    if (s[i].Substring(k, 1) == "a")
                    {
                        pos[k] = 10;
                    }
                    else if (s[i].Substring(k, 1) == "b")
                    {
                        pos[k] = 11;
                    }
                    else if (s[i].Substring(k, 1) == "c")
                    {
                        pos[k] = 12;
                    }
                    else if (s[i].Substring(k, 1) == "d")
                    {
                        pos[k] = 13;
                    }
                    else if (s[i].Substring(k, 1) == "e")
                    {
                        pos[k] = 14;
                    }
                    else if (s[i].Substring(k, 1) == "f")
                    {
                        pos[k] = 15;
                    }
                    else
                    {
                        pos[k] = int.Parse(s[i].Substring(k, 1));
                    }
                }
                sub[i] = getBinary(AES[pos[0], pos[1]]);
            }
            return sub;
        }



        public static string XOR(string s1, string s2)
        {
            string output = "";
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1.Substring(i, 1) != s2.Substring(i, 1))
                {
                    output += "1";
                }
                else
                {
                    output += "0";
                }
            }
            return output;
        }

        public static string getBinary(string s)
        {
            string output = "";
            string[] binary = new string[] { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111",
                "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            for (int k = 0; k < 2; k++)
            {
                if (s.Substring(k, 1) == "a")
                {
                    output += binary[10];
                }
                else if (s.Substring(k, 1) == "b")
                {
                    output += binary[11];
                }
                else if (s.Substring(k, 1) == "c")
                {
                    output += binary[12];
                }
                else if (s.Substring(k, 1) == "d")
                {
                    output += binary[13];
                }
                else if (s.Substring(k, 1) == "e")
                {
                    output += binary[14];
                }
                else if (s.Substring(k, 1) == "f")
                {
                    output += binary[15];
                }
                else
                {
                    output += binary[int.Parse(s.Substring(k, 1))];
                }
            }
            return output;
        }
        public static string getHex(string s)
        {
            string output = "";
            string[] binary = new string[] { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            for (int l = 0; l < 5; l = l + 4)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (s.Substring(l, 4) == binary[i])
                    {
                        if (i == 10)
                        {
                            output += "a";
                        }
                        else if (i == 11)
                        {
                            output += "b";
                        }
                        else if (i == 12)
                        {
                            output += "c";
                        }
                        else if (i == 13)
                        {
                            output += "d";
                        }
                        else if (i == 14)
                        {
                            output += "e";
                        }
                        else if (i == 15)
                        {
                            output += "f";
                        }
                        else
                        {
                            output += i;
                        }
                    }
                }
            }
            return output;

        }

        public static void Main(string[] args)
        {
            bool stop = false;
            int choice = 0;
            string[] output = new string[16];
            string[,] nOutput = new string[4, 4];
            while (!stop)
            {
                int mainchoice = 0;
                Console.WriteLine("---------------MAIN MENU---------------\n1. AES S-Boxes\n" +
                                  "2. AES Shift Rows\n3. AES Mix Columns\n4. Key Expansion\n" +
                                  "5. Exit program\nEnter option number:");
                mainchoice = int.Parse(Console.ReadLine());
                switch (mainchoice)
                {
                    case 1:
                        output = new string[16];
                        while (!stop && choice != 4)
                        {
                            Console.WriteLine("---------------AES S-Box MENU---------------\n1. Input Array\n" +
                                          "2. Substitution\n3. Inverse\n4. Return to Main Menu\n" +
                                          "5. Exit program\nEnter option number:");
                            choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Input Array of 16 bytes seperated by commas(,) w/o spaces:");
                                    string input = Console.ReadLine();
                                    output = input.Split(",");
                                    break;
                                case 2:
                                    Substitution(output);
                                    for (int i = 0; i < 16; i++)
                                    {
                                        Console.Write(output[i] + " ");
                                    }
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Inverse(output);
                                    for (int i = 0; i < 16; i++)
                                    {
                                        Console.Write(output[i] + " ");
                                    }
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    stop = true;
                                    break;
                                default:
                                    Console.WriteLine("Enter a Valid Option (1-5):");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        output = new string[16];
                        while (!stop && choice != 3)
                        {
                            Console.WriteLine("---------------Shift Rows MENU---------------\n1. Input Array\n" +
                                          "2. Shift Rows\n3. Return to Main Menu\n" +
                                          "4. Exit program\nEnter option number:");
                            choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Input Array of 16 bytes seperated by commas(,) w/o spaces:");
                                    string input = Console.ReadLine();
                                    output = input.Split(",");
                                    break;
                                case 2:
                                    Shift(output);
                                    for (int i = 0; i < 16; i++)
                                    {
                                        Console.Write(output[i] + " ");
                                    }
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    stop = true;
                                    break;
                                default:
                                    Console.WriteLine("Enter a Valid Option (1-3):");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        output = new string[16];
                        while (!stop && choice != 4)
                        {
                            Console.WriteLine("---------------AES Mix Columns MENU---------------\n1. Input Array\n" +
                                          "2. Mix Columns\n3. InverseMic Columns\n4. Return to Main Menu\n" +
                                          "5. Exit program\nEnter option number:");
                            choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Input Array of 16 bytes seperated by commas(,) w/o spaces:");
                                    string input = Console.ReadLine();
                                    output = input.Split(",");
                                    for (int i = 0; i < 4; i++)
                                    {
                                        nOutput[i, 0] = output[i * 4];
                                        nOutput[i, 1] = output[i * 4 + 1];
                                        nOutput[i, 2] = output[i * 4 + 2];
                                        nOutput[i, 3] = output[i * 4 + 3];
                                    }
                                    break;
                                case 2:
                                    MixColumns(nOutput);
                                    for (int i = 0; i < 4; i++)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            Console.Write(nOutput[i, j] + " ");
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    InverseMixColumns(nOutput);
                                    for (int i = 0; i < 4; i++)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            Console.Write(nOutput[i, j] + " ");
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    stop = true;
                                    break;
                                default:
                                    Console.WriteLine("Enter a Valid Option (1-5):");
                                    break;
                            }
                        }
                        break;
                    case 4:
                        output = new string[16];
                        string[,] words = new string[44, 4];
                        while (!stop && choice != 3)
                        {
                            Console.WriteLine("---------------Key Expansion MENU---------------\n1. Input Array\n" +
                                          "2. Key Expansion\n3. Return to Main Menu\n" +
                                          "4. Exit program\nEnter option number:");
                            choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Input Array of 16 bytes seperated by commas(,) w/o spaces:");
                                    string input = Console.ReadLine();
                                    output = input.Split(",");
                                    break;
                                case 2:
                                    keyExpansion(output, words);
                                    for (int i = 0; i < 44; i++)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            Console.Write(words[i, j]);
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    stop = true;
                                    break;
                                default:
                                    Console.WriteLine("Enter a Valid Option (1-3):");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Enter a Valid Option (1-5):");
                        break;
                }
            }
        }
    }
}