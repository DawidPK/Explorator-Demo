using System.IO;
using System.Linq.Expressions;

string path = @"c:\";
DirectoryInfo Dic = new DirectoryInfo(path);
ConsoleKeyInfo cki;
int index = 0;
List<string> opcje = new List<string>();

write(opcje);
while (true) 
{
    cki = Console.ReadKey();
    switch (cki.Key) 
    {
        case ConsoleKey.DownArrow:
            
            index += 1;
            clamp(ref index);
            write(opcje);

            break;
        case ConsoleKey.UpArrow:
            
            index -= 1;
            clamp(ref index);
            write(opcje);
            break ;
        case ConsoleKey.Enter:
            string add = opcje.ElementAt(index) + "\\";
            bool dziad = false;
            try
            {
                Dic = new DirectoryInfo(path + add);
                Dic.GetDirectories();
            }
            catch(System.IO.IOException e)
            {
                Console.WriteLine("Nie ma opcji otwierania plików jeszcze :< ");
                dziad = true;
                Dic = new DirectoryInfo(path);
                break;
            }
            if(dziad == false) 
            {
                path += add;
                Dic = new DirectoryInfo(path);
                index = 0;
                write(opcje);
            }
            
            
            break;
        case ConsoleKey.Backspace:
            
            break;
    }

}

 

void write(List<string> l) 
{
    Console.Clear();
    l.Clear();
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Twoja aktualna ścieżka to: " + Dic.FullName);
    foreach (var dir in Dic.GetDirectories())
    {
        l.Add(dir.Name);
    }
    foreach (var file in Dic.GetFiles())
    {
        l.Add(file.Name);
    }
    for(int i = 0; i < l.Count; i++) 
    {
        if(i == index) 
        {
            Console.WriteLine("→ " + l.ElementAt(i) );
        }
        else
        {
            Console.WriteLine("  " + l.ElementAt(i));          
        }
    }
    Console.WriteLine(index);
}
void clamp(ref int i) 
{
    if(i < 0) 
    {
        i = 0;
    }
    if(i > opcje.Count - 1) 
    {
        i = opcje.Count - 1;    
    }
}